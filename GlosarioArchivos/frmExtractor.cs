using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Delimon.Win32.IO;

namespace GlosarioArchivos
{
    public partial class frmExtractor : Form
    {
        #region Variables

        private delegate void tsControl(System.Windows.Forms.Control target, string value);

        private delegate void tsControlProgress(System.Windows.Forms.ProgressBar target, int value);

        private tsControl updateControl;
        private tsControlProgress updateProgress;

        private const int MaxLog = 1000000;
        private const string ArchivoLog = "LogEventos.log";

        private const int cSel = 0;
        private const int cEquipo = 1;
        private const int cArchivo = 2;
        private const int cRuta = 3;
        private const int cTamanno = 4;
        private const int cUnidad = 7;

        private DateTime FechaIni;
        private DataTable DTResultados;
        private bool ProcesarChk = true;
        private List<ArchivoCopia> ListaArchivosCopia = new List<ArchivoCopia> { };
        private string RutaCopia = "";

        //Variables de búsqueda
        private int vbMaxResultados;

        private string vbPalabrasClave;
        private string vbEquipos;
        private bool vbUsarFechas;
        private bool vbUsarFechasM;
        private DateTime vbFechaIni;
        private DateTime vbFechaFin;
        private DateTime vbFechaIniM;
        private DateTime vbFechaFinM;
        private bool vbUsarTamanno;
        private Int64 vbTamannoMin;
        private Int64 vbTamannoMax;
        private bool vbUsarRegAct;
        private string vbRegAct;
        private bool vbUsarUnidades;
        private string vbUnidades;
        private bool vbUsarExtensiones;
        private string vbExtensiones;
        private string vbBusquedaMult;

        #endregion Variables

        #region Metodos

        #region Threading

        public void ActualizarProgressBar(ProgressBar pb, int Valor)
        {
            if (pb.InvokeRequired)
                pb.Invoke(updateProgress, new object[] { pb, Valor });
            else
                pb.Value = Valor;
        }

        public void UpdateControlCall(System.Windows.Forms.Control targetControl, string targetValue)
        {
            if (targetControl.InvokeRequired) //Invoke Method
            {
                targetControl.Invoke(updateControl, new object[] { targetControl, targetValue });
            }
            else
            {
                if (targetControl.GetType() == typeof(Label) && (targetValue == "true" || targetValue == "false"))
                {
                    targetControl.Visible = Convert.ToBoolean(targetValue);
                }
                else if (targetControl.GetType() == typeof(Button) && (targetValue == "true" || targetValue == "false"))
                {
                    targetControl.Visible = Convert.ToBoolean(targetValue);
                }
                else if (targetControl.GetType() == typeof(Label) && targetValue != "true" && targetValue != "false")
                {
                    targetControl.Text = targetValue;
                }
                else if (targetControl.GetType() == typeof(ProgressBar) && (targetValue == "true" || targetValue == "false"))
                {
                    ProgressBar tmpControl = new ProgressBar();
                    tmpControl = (ProgressBar)targetControl;
                    tmpControl.Visible = Convert.ToBoolean(targetValue);
                }
                else if (targetControl.GetType() == typeof(ProgressBar) && targetValue != "true" && targetValue != "false")
                {
                    ProgressBar tmpControl = new ProgressBar();
                    tmpControl = (ProgressBar)targetControl;
                    tmpControl.Value = Convert.ToInt32(targetValue);
                }
                else if (targetControl.GetType() == typeof(PictureBox))
                {
                    PictureBox tmpControl = new PictureBox();
                    tmpControl = (PictureBox)targetControl;
                    tmpControl.Visible = Convert.ToBoolean(targetValue);
                }
                else if (targetControl.GetType() == typeof(Panel))
                {
                    Panel tmpControl = new Panel();
                    tmpControl = (Panel)targetControl;
                    tmpControl.Visible = Convert.ToBoolean(targetValue);
                }
            }
        }

        #endregion Threading

        #region Log

        private void RegistrarLogLocal(string Modulo, string Mensaje, string Equipo, string ArchivoStr)
        {
            try
            {
                string Archivo = Path.Combine(Environment.CurrentDirectory, ArchivoLog);

                Mensaje = Mensaje.Replace("\n", ";").Replace("\r", ";");
                File.AppendAllText(Archivo, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.ffff") + "\t" + Modulo + "\t" + Mensaje + "\t" + Equipo + "\t" + ArchivoStr + Environment.NewLine, Encoding.UTF8);

                int LineasSobrantes = File.ReadAllLines(Archivo).Count() - MaxLog;

                if (LineasSobrantes > 0)
                {
                    List<string> linesList = File.ReadAllLines(Archivo).ToList();

                    for (int w = 0; w < LineasSobrantes; w++)
                        linesList.RemoveAt(w);

                    File.WriteAllLines(Archivo, linesList.ToArray(), Encoding.UTF8);
                }
            }
            catch { }
        }

        #endregion Log

        #region BDGeneral

        private List<string> ObtenerEquipos(Int16? Grupo)
        {
            List<string> Equipos = new List<string> { };
            DataTable MsjBD = new DataTable();
            SqlConnection cn = null;
            SqlCommand cmd = null;
            SqlParameter param;

            try
            {
                cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Sistema"].ConnectionString);
                cmd = new SqlCommand("stpS_GlosarioEquipos", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                param = new SqlParameter("@GAE_Grupo", SqlDbType.TinyInt);
                param.Value = Grupo;
                cmd.Parameters.Add(param);

                cn.Open();
                cmd.CommandTimeout = 10;
                MsjBD.Load(cmd.ExecuteReader());

                for (int w = 0; w < MsjBD.Rows.Count; w++)
                {
                    Equipos.Add(MsjBD.Rows[w][0].ToString());
                }
            }
            catch (Exception ex)
            {
                RegistrarLogLocal("ObtenerEquiposEsp", ex.Message + "->" + ex.StackTrace, "N/A", "N/A");
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }

            return Equipos;
        }

        private void BuscarArchivos(int MaxRes,
            string PalabrasClave,
            string Equipos,
            bool UsarFechas,
            bool UsarFechasM,
            DateTime FechaIni,
            DateTime FechaFin,
            DateTime FechaIniM,
            DateTime FechaFinM,
            bool UsarTamanno,
            Int64 TamannoMin,
            Int64 TamannoMax,
            bool UsarRegAct,
            string RegAct,
            bool UsarUnidades,
            string Unidades,
            bool UsarExtensiones,
            string Extensiones,
            string BusquedaMult)
        {
            DTResultados = new DataTable("Resultados");
            SqlConnection cn = null;
            SqlCommand cmd = null;
            string QueryResultante = "";

            try
            {
                QueryResultante = GlosarioArchivos.Properties.Resources.QueryBaseBusqueda;
                QueryResultante += Environment.NewLine;

                if (MaxRes > 0)
                    QueryResultante = QueryResultante.Replace("SELECT", "SELECT TOP " + MaxRes.ToString());

                if (PalabrasClave != "*.*")
                {
                    string[] Palabras = PalabrasClave.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                    if (Palabras.Length == 1)
                    {
                        QueryResultante += "AND (GA_Ruta LIKE '%" + PalabrasClave + "%' COLLATE modern_spanish_ci_ai OR GA_Objeto LIKE '%" + PalabrasClave + "%' COLLATE modern_spanish_ci_ai) " + Environment.NewLine;
                    }
                    else
                    {
                        QueryResultante += "AND (";

                        foreach (string Palabra in Palabras)
                            QueryResultante += "(GA_Ruta LIKE '%" + Palabra + "%' COLLATE modern_spanish_ci_ai OR GA_Objeto LIKE '%" + Palabra + "%' COLLATE modern_spanish_ci_ai) " + vbBusquedaMult + " " + Environment.NewLine;

                        QueryResultante = QueryResultante.Remove(QueryResultante.Length - (vbBusquedaMult.Length + 3));
                        QueryResultante += ")" + Environment.NewLine;
                    }
                }

                if (!string.IsNullOrWhiteSpace(Equipos))
                    QueryResultante += "AND GA_Equipo IN (" + Equipos + ")" + Environment.NewLine;

                if (UsarFechas)
                {
                    QueryResultante += "AND (GA_FechaCreacion >= '" + FechaIni.ToString("dd/MM/yyyy") + " 00:00:00' AND GA_FechaCreacion <= '" + FechaFin.ToString("dd/MM/yyyy") + " 23:59:59')" + Environment.NewLine;
                }

                if (UsarFechasM)
                {
                    QueryResultante += "AND (GA_FechaModificacion >= '" + FechaIniM.ToString("dd/MM/yyyy") + " 00:00:00' AND GA_FechaModificacion <= '" + FechaFinM.ToString("dd/MM/yyyy") + " 23:59:59')" + Environment.NewLine;
                }

                if (UsarTamanno)
                {
                    QueryResultante += "AND GA_Tamanno >= " + TamannoMin.ToString() + Environment.NewLine;
                    QueryResultante += "AND GA_Tamanno <= " + TamannoMax.ToString() + Environment.NewLine;
                }

                if (UsarRegAct)
                {
                    if (!string.IsNullOrWhiteSpace(RegAct))
                        QueryResultante += "AND GA_RegistroActual = '" + RegAct + "'" + Environment.NewLine;
                }

                if (UsarUnidades)
                {
                    if (!string.IsNullOrWhiteSpace(Unidades))
                        QueryResultante += "AND GA_Unidad IN (" + Unidades + ")" + Environment.NewLine;
                }

                if (UsarExtensiones)
                {
                    if (!string.IsNullOrWhiteSpace(Extensiones))
                        QueryResultante += "AND GA_Extension IN (" + Extensiones + ")" + Environment.NewLine;
                }

                QueryResultante += " ORDER BY GA_Tamanno DESC, GA_Objeto ASC ";

                cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Sistema"].ConnectionString);
                cmd = new SqlCommand(QueryResultante, cn);
                cmd.CommandType = CommandType.Text;
                //Clipboard.SetText(QueryResultante);

                cn.Open();
                cmd.CommandTimeout = 18000;
                DTResultados.Load(cmd.ExecuteReader());
            }
            catch (Exception ex)
            {
                RegistrarLogLocal("BuscarArchivos", ex.Message + "->" + QueryResultante, "N/A", "N/A");
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
        }

        #endregion BDGeneral

        private string GeneraNombreArchivoRnd(string Prefijo, string Extension)
        {
            Random rnd = new Random();
            string Nombre = "";

            if (string.IsNullOrEmpty(Prefijo))
                Prefijo = "";

            if (string.IsNullOrEmpty(Extension))
                Extension = "";

            Extension = Extension.Replace(".", "");

            Nombre = Prefijo + DateTime.Now.ToString("yyyyMMddHHmmss") + rnd.Next(1000).ToString().PadLeft(4, Convert.ToChar("0")) + "." + Extension;

            return Nombre;
        }

        public frmExtractor()
        {
            InitializeComponent();
            updateControl = new tsControl(UpdateControlCall);
            updateProgress = new tsControlProgress(ActualizarProgressBar);
        }

        private string ProcesarUnidades()
        {
            string Unidades = "";

            for (int w = 0; w < ddlUnidades.CheckBoxItems.Count; w++)
            {
                if (ddlUnidades.CheckBoxItems[w].Checked)
                    Unidades += "'" + ddlUnidades.CheckBoxItems[w].Text + "',";
            }

            if (Unidades.Length > 0)
                Unidades = Unidades.Remove(Unidades.Length - 1);

            return Unidades;
        }

        private string ProcesarEquipos()
        {
            string Equipos = "";

            for (int w = 0; w < ddlEquipos.CheckBoxItems.Count; w++)
            {
                if (ddlEquipos.CheckBoxItems[w].Checked && !string.IsNullOrWhiteSpace(ddlEquipos.CheckBoxItems[w].Text))
                    Equipos += "'" + ddlEquipos.CheckBoxItems[w].Text + "',";
            }

            if (Equipos.Length > 0)
                Equipos = Equipos.Remove(Equipos.Length - 1);

            return Equipos;
        }

        private string ProcesarExtensiones()
        {
            string Extensiones = "";

            foreach (string Ext in txtExtensiones.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                Extensiones += "'." + Ext + "',";

            if (Extensiones.Length > 0)
                Extensiones = Extensiones.Remove(Extensiones.Length - 1);

            return Extensiones;
        }

        private string ProcesarRegAct()
        {
            string RegAct = "";

            if (ddlRegAct.SelectedIndex > -1)
            {
                if (ddlRegAct.SelectedIndex == 0)
                    RegAct = "S";

                if (ddlRegAct.SelectedIndex == 1)
                    RegAct = "N";
            }

            return RegAct;
        }

        private string ProcesarBusquedaMultiple()
        {
            string BusqM = "OR";

            if (ddlBusquedaMultiple.SelectedIndex > -1)
            {
                if (ddlBusquedaMultiple.SelectedIndex == 0)
                    BusqM = "AND";
            }

            return BusqM;
        }

        private void Des_HabilitarControles(bool Activo)
        {
            foreach (Control c in this.Controls)
                c.Enabled = Activo;
        }

        private Int64 ObtenerBytes(string Tipo, decimal ValorOriginal)
        {
            Int64 Res = 0;

            switch (Tipo)
            {
                case "KB":
                    Res = Convert.ToInt64(ValorOriginal * 1024);
                    break;

                case "MB":
                    Res = Convert.ToInt64(ValorOriginal * 1024 * 1024);
                    break;

                case "GB":
                    Res = Convert.ToInt64(ValorOriginal * 1024 * 1024 * 1024);
                    break;
            }

            return Res;
        }

        private void ValidarTamanno()
        {
            Int64 vMin = 0;
            Int64 vMax = 0;

            vMin = ObtenerBytes(ddlTipoTamannoMin.Text, numTamannoMin.Value);
            vMax = ObtenerBytes(ddlTipoTamannoMax.Text, numTamannoMax.Value);

            if (vMin > vMax)
            {
                lblErrorFT.Text = "Valores incorrectos. Se ignorará el filtro.";
                chkHayErrorFT.Checked = true;
            }
            else
            {
                lblErrorFT.Text = "";
                chkHayErrorFT.Checked = false;
            }
        }

        private void ValidarFechas()
        {
            if (dtFin.Value < dtIni.Value)
            {
                lblErrorFF.Text = "Valores incorrectos. Se ignorará el filtro.";
                chkHayErrorFF.Checked = true;
            }
            else
            {
                lblErrorFF.Text = "";
                chkHayErrorFF.Checked = false;
            }
        }

        private void ValidarFechasM()
        {
            if (dtFinM.Value < dtIniM.Value)
            {
                lblErrorFFM.Text = "Valores incorrectos. Se ignorará el filtro.";
                chkHayErrorFFM.Checked = true;
            }
            else
            {
                lblErrorFFM.Text = "";
                chkHayErrorFFM.Checked = false;
            }
        }

        private DataTable TestDT()
        {
            DataTable Res = new DataTable();

            Res.Columns.Add("Archivo");
            Res.Columns.Add("Ruta");
            Res.Columns.Add("Tamanno");
            Res.Columns.Add("FC");
            Res.Columns.Add("FM");

            DataRow dr;
            Random rnd = new Random();

            for (int w = 0; w < 20; w++)
            {
                dr = Res.NewRow();
                dr[0] = "archivo";
                dr[1] = "ruta";
                dr[2] = rnd.Next(999999);
                dr[3] = "fc";
                dr[4] = "fm";

                Res.Rows.Add(dr);
            }

            return Res;
        }

        private string CalcularDateDiffStr(DateTime ini, DateTime fin, string TextoIni, string Separador, bool ContarCeros)
        {
            string Res = "";
            TimeSpan diff = (fin - ini);

            Res += TextoIni;

            //Días
            if (diff.Days > 0)
            {
                if (diff.Days == 1)
                    Res += diff.Days + " día" + Separador;
                else
                    Res += diff.Days + " días" + Separador;
            }

            if (ContarCeros && diff.Days == 0)
                Res += "0 días" + Separador;

            //Horas
            if (diff.Hours > 0)
            {
                if (diff.Hours == 1)
                    Res += diff.Hours + " hora" + Separador;
                else
                    Res += diff.Hours + " horas" + Separador;
            }

            if (ContarCeros && diff.Hours == 0)
                Res += "0 horas" + Separador;

            //Minutos
            if (diff.Minutes > 0)
            {
                if (diff.Minutes == 1)
                    Res += diff.Minutes + " minuto" + Separador;
                else
                    Res += diff.Minutes + " minutos" + Separador;
            }

            if (ContarCeros && diff.Minutes == 0)
                Res += "0 minutos" + Separador;

            //Segundos
            if (diff.Seconds > 0)
            {
                if (diff.Seconds == 1)
                    Res += diff.Seconds + " segundo" + Separador;
                else
                    Res += diff.Seconds + " segundos" + Separador;
            }

            if (ContarCeros && diff.Seconds == 0)
                Res += "0 segundos" + Separador;
            else if (!ContarCeros && diff.Seconds == 0 && diff.TotalMinutes < 1)
                Res += "<1 segundo" + Separador;

            return Res;
        }

        private DataTable ResultadosNulos()
        {
            DataTable Resultados = new DataTable();

            Resultados.Columns.Add("Equipo");
            Resultados.Columns.Add("Archivo");
            Resultados.Columns.Add("Ruta");
            Resultados.Columns.Add("Tamanno");
            Resultados.Columns.Add("FC");
            Resultados.Columns.Add("FM");
            Resultados.Columns.Add("Unidad");
            Resultados.Columns.Add("Extension");
            Resultados.Columns.Add("RegAct");

            Resultados.AcceptChanges();

            return Resultados;
        }

        private void ProcesarDatosAlt(DataTable Datos, DateTime FechaIni)
        {
            double TamannoKBTemp = 0;
            double TamannoKB = 0;
            lstArchivos.DataSource = Datos;

            for (int w = 0; w < Datos.Rows.Count; w++)
            {
                DataRow dr = Datos.Rows[w];

                double.TryParse(dr["Tamanno"].ToString(), out TamannoKBTemp);
                TamannoKB += TamannoKBTemp;
            }

            lblEncontrados.Text = "Archivos encontrados: " + Datos.Rows.Count.ToString();
            lblTamanno.Text = "Tamaño total: " + ObtenerTamannoEstado(TamannoKB * 1024);
            lblTiempo.Text = CalcularDateDiffStr(FechaIni, DateTime.Now, "Tiempo de proceso: ", " ", false);
        }

        private void ReProcesarEstados(bool Procesar)
        {
            if (Procesar)
            {
                int Conteo = 0;
                double TamannoKBTemp = 0;
                double TamannoKB = 0;

                for (int w = 0; w < lstArchivos.Items.Count; w++)
                {
                    if (lstArchivos.Items[w].Checked)
                    {
                        Conteo++;
                        double.TryParse(lstArchivos.Items[w].SubItems[cTamanno].Text, out TamannoKBTemp);
                        TamannoKB += TamannoKBTemp;
                    }
                }

                lblEncontrados.Text = "Archivos seleccionados: " + Conteo.ToString();
                lblTamanno.Text = "Tamaño total: " + ObtenerTamannoEstado(TamannoKB * 1024);
            }
        }

        private string ObtenerTamannoEstado(double Tamanno)
        {
            string[] tipos = { "B", "KB", "MB", "GB" };
            int orden = 0;

            while (Tamanno >= 1024 && orden + 1 < tipos.Length)
            {
                orden++;
                Tamanno = Tamanno / 1024;
            }

            return String.Format("{0:0.##} {1}", Tamanno, tipos[orden]);
        }

        public static bool ValidateInput(KeyPressEventArgs e)
        {
            bool blDiscardUserInput = true;

            //A-Z
            if (e.KeyChar >= 60 && e.KeyChar <= 90)
                blDiscardUserInput = false;

            // a-z
            if (e.KeyChar >= 97 && e.KeyChar <= 122)
                blDiscardUserInput = false;

            // 0-9
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                blDiscardUserInput = false;

            // Backspace
            if (e.KeyChar == 8)
                blDiscardUserInput = false;

            // Comma
            if (e.KeyChar == 44)
                blDiscardUserInput = false;

            // Single Quote
            if (e.KeyChar == 39)
                blDiscardUserInput = true;

            // Space
            if (e.KeyChar == 32)
                blDiscardUserInput = true;

            // Hyphen
            if (e.KeyChar == 45)
                blDiscardUserInput = true;

            // Dot
            if (e.KeyChar == 46)
                blDiscardUserInput = true;

            // Enter
            if (e.KeyChar == 13)
                blDiscardUserInput = true;

            return blDiscardUserInput;
        }

        private string ObtenerRutaCopia(string Equipo, string Ruta, string Archivo, string Unidad)
        {
            string RutaArchivo = "";
            //Arch.FullName.Replace(@"\\" + Srv + @"\" + Unidad + @"$\", Unidad + @":\");
            RutaArchivo = Path.Combine(Ruta.Replace(Unidad + @":\", @"\\" + Equipo + @"\" + Unidad + @"$\"), Archivo);

            return RutaArchivo;
        }

        private void CopiaRapida(string source, string destination, bool BorrarOrigen = false)
        {
            int array_length = (int)Math.Pow(2, 19);
            byte[] dataArray = new byte[array_length];

            using (System.IO.FileStream fsread = new System.IO.FileStream
            (source, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.None, array_length))
            {
                using (System.IO.BinaryReader bwread = new System.IO.BinaryReader(fsread))
                {
                    using (System.IO.FileStream fswrite = new System.IO.FileStream
                    (destination, System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.None, array_length))
                    {
                        using (System.IO.BinaryWriter bwwrite = new System.IO.BinaryWriter(fswrite))
                        {
                            for (; ; )
                            {
                                int read = bwread.Read(dataArray, 0, array_length);
                                if (0 == read)
                                    break;
                                bwwrite.Write(dataArray, 0, read);
                            }
                        }
                    }
                }
            }

            if (BorrarOrigen)
                File.Delete(source);
        }

        #endregion Metodos

        #region Eventos

        private void frmExtractor_Load(object sender, EventArgs e)
        {
            ddlEquipos.Items.AddRange(ObtenerEquipos(null).ToArray());

            for (int w = 0; w < ddlEquipos.Items.Count; w++)
                ddlEquipos.CheckBoxItems[w].Checked = true;

            ddlTipoTamannoMin.SelectedIndex = 0;
            ddlTipoTamannoMax.SelectedIndex = 0;
            ddlRegAct.SelectedIndex = 0;
            ddlBusquedaMultiple.SelectedIndex = 0;
        }

        private void frmExtractor_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            for (int w = 0; w < ddlEquipos.Items.Count; w++)
                ddlEquipos.CheckBoxItems[w].Checked = true;
        }

        private void btnNone_Click(object sender, EventArgs e)
        {
            for (int w = 0; w < ddlEquipos.Items.Count; w++)
                ddlEquipos.CheckBoxItems[w].Checked = false;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Bloquear controles
            Des_HabilitarControles(false);
            pnlEngine.Visible = true;
            pnlEngine.Enabled = true;
            pbEngine.Enabled = true;
            pnlEngine.Location = gbResultados.Location;
            pnlEngine.Size = gbResultados.Size;
            pnlEngine.BringToFront();

            //Iniciar búsqueda
            //txtKeywords.Text = txtKeywords.Text.Trim();

            if (txtKeywords.Text.Length >= 3)
            {
                vbMaxResultados = Convert.ToInt32(numMaxResultados.Value);
                vbPalabrasClave = txtKeywords.Text;
                vbEquipos = ProcesarEquipos();
                vbUsarFechas = chkUsarFechas.Checked;
                vbUsarFechasM = chkUsarFechasM.Checked;
                vbFechaIni = dtIni.Value;
                vbFechaFin = dtFin.Value;
                vbFechaIniM = dtIniM.Value;
                vbFechaFinM = dtFinM.Value;
                vbUsarTamanno = chkUsarTamanno.Checked;
                vbTamannoMin = Convert.ToInt64(ObtenerBytes(ddlTipoTamannoMin.Text, numTamannoMin.Value) / 1024);
                vbTamannoMax = Convert.ToInt64(ObtenerBytes(ddlTipoTamannoMax.Text, numTamannoMax.Value) / 1024);
                vbUsarRegAct = chkUsarRegAct.Checked;
                vbRegAct = ProcesarRegAct();
                vbUsarUnidades = chkUsarUnidades.Checked;
                vbUnidades = ProcesarUnidades();
                vbUsarExtensiones = chkUsarExtensiones.Checked;
                vbExtensiones = ProcesarExtensiones();
                vbBusquedaMult = ProcesarBusquedaMultiple();

                if (chkHayErrorFT.Checked)
                    vbUsarTamanno = false;

                if (chkHayErrorFF.Checked)
                    vbUsarFechas = false;

                if (chkHayErrorFFM.Checked)
                    vbUsarFechasM = false;

                lstArchivos.Items.Clear();
                chkListSelect.Checked = false;
                DTResultados = new DataTable("Resultados");
                pnlProgreso.Visible = false;
                wkrBusqueda.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("El término de búsqueda debe contener al menos tres caracteres.", "Palabras clave incorrectas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void chkUsarFechas_CheckedChanged(object sender, EventArgs e)
        {
            dtIni.Enabled = chkUsarFechas.Checked;
            dtFin.Enabled = chkUsarFechas.Checked;
            dtIni.Focus();
        }

        private void chkUsarFechasM_CheckedChanged(object sender, EventArgs e)
        {
            dtIniM.Enabled = chkUsarFechasM.Checked;
            dtFinM.Enabled = chkUsarFechasM.Checked;
            dtIniM.Focus();
        }

        private void dtIni_ValueChanged(object sender, EventArgs e)
        {
            ValidarFechas();
        }

        private void dtFin_ValueChanged(object sender, EventArgs e)
        {
            ValidarFechas();
        }

        private void dtIniM_ValueChanged(object sender, EventArgs e)
        {
            ValidarFechasM();
        }

        private void dtFinM_ValueChanged(object sender, EventArgs e)
        {
            ValidarFechasM();
        }

        private void chkUsarTamanno_CheckedChanged(object sender, EventArgs e)
        {
            numTamannoMin.Enabled = chkUsarTamanno.Checked;
            numTamannoMax.Enabled = chkUsarTamanno.Checked;
            ddlTipoTamannoMin.Enabled = chkUsarTamanno.Checked;
            ddlTipoTamannoMax.Enabled = chkUsarTamanno.Checked;
            numTamannoMin.Focus();
        }

        private void numTamannoMin_ValueChanged(object sender, EventArgs e)
        {
            ValidarTamanno();
        }

        private void numTamannoMax_ValueChanged(object sender, EventArgs e)
        {
            ValidarTamanno();
        }

        private void ddlTipoTamannoMin_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidarTamanno();
        }

        private void ddlTipoTamannoMax_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidarTamanno();
        }

        private void chkListSelect_CheckedChanged(object sender, EventArgs e)
        {
            ProcesarChk = false;

            if (chkListSelect.Checked)
                lstArchivos.CheckAll();
            else
                lstArchivos.UncheckAll();

            ProcesarChk = true;
            ReProcesarEstados(ProcesarChk);
        }

        private void lstArchivos_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void lstArchivos_ItemSelectionChanged(object sender, System.Windows.Forms.ListViewItemSelectionChangedEventArgs e)
        {
            if (lstArchivos.SelectedObjects.Count > 1)
                lstArchivos.ToggleCheckObject(lstArchivos.GetModelObject(e.ItemIndex));
        }

        private void lstArchivos_SelectionChanged(object sender, System.EventArgs e)
        {
            //Deshabilitado para mejorar desempeño
            //for (int w = 0; w < lstArchivos.Items.Count; w++)
            //{
            //    if (lstArchivos.Items[w].Selected)
            //    {
            //        lstArchivos.ToggleCheckObject(lstArchivos.GetModelObject(w));
            //    }
            //}
        }

        private void chkUsarRegAct_CheckedChanged(object sender, EventArgs e)
        {
            ddlRegAct.Enabled = chkUsarRegAct.Checked;
            ddlRegAct.Focus();
        }

        private void lstArchivos_ItemChecked(object sender, System.Windows.Forms.ItemCheckedEventArgs e)
        {
            ReProcesarEstados(ProcesarChk);
        }

        private void chkUsarUnidades_CheckedChanged(object sender, EventArgs e)
        {
            ddlUnidades.Enabled = chkUsarUnidades.Checked;
            ddlUnidades.Focus();
        }

        private void chkUsarExtensiones_CheckedChanged(object sender, EventArgs e)
        {
            txtExtensiones.Enabled = chkUsarExtensiones.Checked;
            txtExtensiones.Focus();
        }

        private void txtExtensiones_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = ValidateInput(e);
        }

        private void txtExtensiones_TextChanged(object sender, EventArgs e)
        {
        }

        private void wkrBusqueda_DoWork(object sender, DoWorkEventArgs e)
        {
            FechaIni = DateTime.Now;

            BuscarArchivos(vbMaxResultados,
                vbPalabrasClave,
                vbEquipos,
                vbUsarFechas,
                vbUsarFechasM,
                vbFechaIni,
                vbFechaFin,
                vbFechaIniM,
                vbFechaFinM,
                vbUsarTamanno,
                vbTamannoMin,
                vbTamannoMax,
                vbUsarRegAct,
                vbRegAct,
                vbUsarUnidades,
                vbUnidades,
                vbUsarExtensiones,
                vbExtensiones,
                vbBusquedaMult);
        }

        private void wkrBusqueda_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (DTResultados.Rows.Count == 0)
            {
                DTResultados = new DataTable("Resultados");
                DTResultados = ResultadosNulos();
                MessageBox.Show("No se obtuvieron resultados para su búsqueda.", "Búsqueda de archivos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ProcesarDatosAlt(DTResultados, FechaIni);
            }

            //Desbloquear controles
            Des_HabilitarControles(true);
            pnlEngine.Visible = false;
            pnlEngine.Enabled = false;
            pbEngine.Enabled = false;
        }

        private void mnuGuardarBusqueda_Click(object sender, EventArgs e)
        {
            sfd01.ShowDialog(this);

            if (Directory.Exists(Path.GetDirectoryName(sfd01.FileName)))
            {
                try
                {
                    DTResultados.WriteXml(sfd01.FileName);
                    MessageBox.Show("Se ha guardado la búsqueda.", "Extractor del glosario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("El directorio destino no existe.", "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void mnuAbrirBusqueda_Click(object sender, EventArgs e)
        {
            ofd01.ShowDialog(this);

            if (File.Exists(ofd01.FileName))
            {
                try
                {
                    FechaIni = DateTime.Now;
                    DTResultados = new DataTable("Resultados");
                    DTResultados.ReadXmlSchema(ofd01.FileName);
                    DTResultados.ReadXml(ofd01.FileName);

                    ProcesarDatosAlt(DTResultados, FechaIni);

                    MessageBox.Show("Se ha cargado completamente la búsqueda.", "Extractor del glosario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al abrir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("El archivo no existe.", "Error al abrir", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void numMaxResultados_ValueChanged(object sender, EventArgs e)
        {
            if (numMaxResultados.Value == 0)
                lblMaxResT.Visible = true;
            else
                lblMaxResT.Visible = false;
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuCopiarArchivos_Click(object sender, EventArgs e)
        {
            Ookii.Dialogs.VistaFolderBrowserDialog fbd = new Ookii.Dialogs.VistaFolderBrowserDialog();

            fbd.ShowDialog(this);

            if (Directory.Exists(fbd.SelectedPath))
            {
                RutaCopia = fbd.SelectedPath;

                //Bloquear controles
                Des_HabilitarControles(false);
                pnlEngine.Visible = true;
                pnlEngine.Enabled = true;
                pbEngine.Enabled = true;
                pnlEngine.Location = gbResultados.Location;
                pnlEngine.Size = gbResultados.Size;
                pnlEngine.BringToFront();

                //Preparar copia
                FechaIni = DateTime.Now;
                ListaArchivosCopia = new List<ArchivoCopia> { };
                ArchivoCopia archivoC = new ArchivoCopia();

                for (int w = 0; w < lstArchivos.Items.Count; w++)
                {
                    if (lstArchivos.Items[w].Checked)
                    {
                        archivoC = new ArchivoCopia(lstArchivos.Items[w].SubItems[cEquipo].Text,
                            lstArchivos.Items[w].SubItems[cRuta].Text,
                            lstArchivos.Items[w].SubItems[cArchivo].Text,
                            lstArchivos.Items[w].SubItems[cUnidad].Text);

                        ListaArchivosCopia.Add(archivoC);
                    }
                }

                pb01.Visible = true;
                pb01.Value = 0;

                pbFile.Visible = true;
                pbFile.Value = 0;

                pnlProgreso.Visible = true;

                wkrCopia.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("El directorio no existe.", "Error al copiar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void wkrCopia_DoWork(object sender, DoWorkEventArgs e)
        {
            int TotalArchivos = ListaArchivosCopia.Count;
            string Usuario = System.Configuration.ConfigurationManager.AppSettings["UsuarioS"];
            string Password = System.Configuration.ConfigurationManager.AppSettings["Password"];
            string Dominio = System.Configuration.ConfigurationManager.AppSettings["Dominio"];

            if (string.IsNullOrWhiteSpace(Usuario))
                Usuario = null;

            if (string.IsNullOrWhiteSpace(Password))
                Password = null;

            for (int w = 0; w < TotalArchivos; w++)
            {
                ArchivoCopia archivoC = new ArchivoCopia(ListaArchivosCopia[w].Equipo,
                    ListaArchivosCopia[w].Ruta,
                    ListaArchivosCopia[w].Archivo,
                    ListaArchivosCopia[w].Unidad);

                try
                {
                    archivoC.ArchivoFinal = archivoC.Archivo;
                    ActualizarProgressBar(pb01, Convert.ToInt32(Math.Round(Convert.ToDouble(w * 100) / TotalArchivos, 2)));

                    while (File.Exists(Path.Combine(RutaCopia, archivoC.ArchivoFinal)))
                    {
                        archivoC.ArchivoFinal = Path.GetFileNameWithoutExtension(archivoC.Archivo) + "_" + DateTime.Now.ToString("yyyyMMddff") + Path.GetExtension(archivoC.Archivo);
                    }

                    if (Usuario == null || Password == null)
                    {
                        //File.Copy(ObtenerRutaCopia(archivoC.Equipo, archivoC.Ruta, archivoC.Archivo, archivoC.Unidad), Path.Combine(RutaCopia, archivoC.ArchivoFinal), false);
                        XCopy.Copy(ObtenerRutaCopia(archivoC.Equipo, archivoC.Ruta, archivoC.Archivo, archivoC.Unidad), Path.Combine(RutaCopia, archivoC.ArchivoFinal), false, true, (o, pce) =>
                        {
                            wkrCopia.ReportProgress(pce.ProgressPercentage, archivoC.Archivo);
                        });
                    }
                    else
                    {
                        using (new Impersonator(Usuario, Dominio, Password))
                        {
                            //File.Copy(ObtenerRutaCopia(archivoC.Equipo, archivoC.Ruta, archivoC.Archivo, archivoC.Unidad), Path.Combine(RutaCopia, archivoC.ArchivoFinal), false);
                            XCopy.Copy(ObtenerRutaCopia(archivoC.Equipo, archivoC.Ruta, archivoC.Archivo, archivoC.Unidad), Path.Combine(RutaCopia, archivoC.ArchivoFinal), false, true, (o, pce) =>
                            {
                                wkrCopia.ReportProgress(pce.ProgressPercentage, archivoC.Archivo);
                            });
                        }
                    }

                    ListaArchivosCopia[w] = archivoC;
                }
                catch (Exception ex)
                {
                    archivoC.ArchivoFinal = ex.Message.Replace("\n", ";").Replace("\r", ";");
                    ListaArchivosCopia[w] = archivoC;
                }
            }

            ExportarExcel excel = new ExportarExcel();

            excel.GenerarExcel(ListaArchivosCopia.ToDataTable().CreateDataReader(), RutaCopia, GeneraNombreArchivoRnd("Rpt_", "xlsx"), 500000);
        }

        private void wkrCopia_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            //pd01.ShowDialog();
            //pd01.ReportProgress(e.ProgressPercentage, "Copia de archivos", e.UserState.ToString());
            pbFile.Value = e.ProgressPercentage;
        }

        private void wkrCopia_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            //Desbloquear controles
            Des_HabilitarControles(true);
            pnlEngine.Visible = false;
            pnlEngine.Enabled = false;
            pbEngine.Enabled = false;
            lblTiempo.Text = CalcularDateDiffStr(FechaIni, DateTime.Now, "Tiempo de proceso: ", " ", false);

            MessageBox.Show("Ha finalizado el copiado de los archivos seleccionados.", "Extractor del glosario", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtKeywords_TextChanged(object sender, EventArgs e)
        {
            if (txtKeywords.Text.Contains("|"))
                ddlBusquedaMultiple.Enabled = true;
            else
                ddlBusquedaMultiple.Enabled = false;
        }

        #endregion Eventos
    }

    public struct ArchivoCopia
    {
        public string Equipo;
        public string Ruta;
        public string Archivo;
        public string Unidad;
        public string ArchivoFinal;

        public ArchivoCopia(string vEquipo, string vRuta, string vArchivo, string vUnidad)
        {
            Equipo = vEquipo;
            Ruta = vRuta;
            Archivo = vArchivo;
            Unidad = vUnidad;
            ArchivoFinal = "";
        }

        public string pEquipo
        {
            get { return Equipo; }
        }

        public string pRuta
        {
            get { return Ruta; }
        }

        public string pArchivo
        {
            get { return Archivo; }
        }

        public string pUnidad
        {
            get { return Unidad; }
        }

        public string pArchivoFinal
        {
            get { return ArchivoFinal; }
        }
    }
}