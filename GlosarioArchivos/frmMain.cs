using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Windows.Forms;

namespace GlosarioArchivos
{
    public partial class frmMain : Form
    {
        #region Variables

        private delegate void tsControl(System.Windows.Forms.Control target, string value);

        private tsControl updateControl;
        public List<string> ListaEquipos = new List<string> { };
        public List<string> ListaEspUnidades = new List<string> { };
        public bool ExcluirCarpetas = true;
        public bool EjecucionEspecial = false;

        private const int MaxStrEquipo = 25;
        private const int MaxStrRuta = 500;
        private const int MaxStrObjeto = 256;
        private const int MaxStrExtension = 100;
        private const int MaxStrMensaje = 1000;
        private int ConteoEquipos = 0;
        private int ConteoUnidades = 0;

        private const int MaxLog = 1000000;
        private const string ArchivoLog = "LogEventos.log";

        private enum EstadosProceso
        {
            Iniciar = 1,
            Actualizar = 2,
            Finalizar = 3,
            ActualizarEdo = 4
        }

        #endregion Variables

        #region Medodos

        public frmMain()
        {
            InitializeComponent();
            updateControl = new tsControl(UpdateControlCall);
            InicializarPieEquipos();
            InicializarPieUnidades();
            InicializarPieArchivos();
        }

        #region Chart

        private void InicializarPieEquipos()
        {
            try
            {
                pieEquipos.LeftMargin = 10;
                pieEquipos.RightMargin = 10;
                pieEquipos.TopMargin = 10;
                pieEquipos.BottomMargin = 10;
                pieEquipos.FitChart = false;
                pieEquipos.SliceRelativeHeight = .10f;
                pieEquipos.InitialAngle = 90;
                pieEquipos.EdgeLineWidth = 1;
                pieEquipos.EdgeColorType = System.Drawing.PieChart.EdgeColorType.Contrast;

                pieEquipos.Colors = new Color[] { Color.FromArgb(120, Color.LightGreen), Color.FromArgb(120, Color.LightBlue), Color.FromArgb(120, Color.IndianRed) };
                pieEquipos.SliceRelativeDisplacements = new float[] { .05f, .05f, .05f };
                pieEquipos.Texts = new string[] { "", "", "" };
            }
            catch { }
        }

        private void CrearPieEquipos(int TotalEquipos, int EquiposProcesados, string EquipoActual)
        {
            try
            {
                if (TotalEquipos - EquiposProcesados >= 2)
                    pieEquipos.Values = new decimal[] { EquiposProcesados - 1, 1, TotalEquipos - EquiposProcesados };
                else if (TotalEquipos - EquiposProcesados == 1)
                    pieEquipos.Values = new decimal[] { EquiposProcesados - 1, 1, TotalEquipos - EquiposProcesados };
                else
                    pieEquipos.Values = new decimal[] { TotalEquipos, 0, 0 };

                pieEquipos.ToolTips = new string[] { "Procesados: " + (EquiposProcesados - 1).ToString(), "Actual: " + EquipoActual, "Restantes: " + (TotalEquipos - EquiposProcesados).ToString() };
            }
            catch { }
        }

        private void InicializarPieUnidades()
        {
            try
            {
                pieUnidades.LeftMargin = 10;
                pieUnidades.RightMargin = 10;
                pieUnidades.TopMargin = 10;
                pieUnidades.BottomMargin = 10;
                pieUnidades.FitChart = false;
                pieUnidades.SliceRelativeHeight = .10f;
                pieUnidades.InitialAngle = 90;
                pieUnidades.EdgeLineWidth = 1;
                pieUnidades.EdgeColorType = System.Drawing.PieChart.EdgeColorType.Contrast;

                pieUnidades.Colors = new Color[] { Color.FromArgb(120, Color.LightGreen), Color.FromArgb(120, Color.LightBlue), Color.FromArgb(120, Color.IndianRed) };
                pieUnidades.SliceRelativeDisplacements = new float[] { .05f, .05f, .05f };
                pieUnidades.Texts = new string[] { "", "", "" };
            }
            catch { }
        }

        private void CrearPieUnidades(int TotalUnidades, int UnidadesProcesadas, string UnidadActual)
        {
            try
            {
                if (TotalUnidades - UnidadesProcesadas >= 2)
                    pieUnidades.Values = new decimal[] { UnidadesProcesadas - 1, 1, TotalUnidades - UnidadesProcesadas };
                else if (TotalUnidades - UnidadesProcesadas == 1)
                    pieUnidades.Values = new decimal[] { UnidadesProcesadas - 1, 1, TotalUnidades - UnidadesProcesadas };
                else
                    pieUnidades.Values = new decimal[] { TotalUnidades, 0, 0 };

                pieUnidades.ToolTips = new string[] { "Procesadas: " + (UnidadesProcesadas - 1).ToString(), "Actual: " + UnidadActual, "Restantes: " + (TotalUnidades - UnidadesProcesadas).ToString() };
            }
            catch { }
        }

        private void InicializarPieArchivos()
        {
            try
            {
                pieArchivos.LeftMargin = 10;
                pieArchivos.RightMargin = 10;
                pieArchivos.TopMargin = 10;
                pieArchivos.BottomMargin = 10;
                pieArchivos.FitChart = false;
                pieArchivos.SliceRelativeHeight = .10f;
                pieArchivos.InitialAngle = 90;
                pieArchivos.EdgeLineWidth = 1;
                pieArchivos.EdgeColorType = System.Drawing.PieChart.EdgeColorType.Contrast;

                pieArchivos.Colors = new Color[] { Color.FromArgb(120, Color.LightGreen), Color.FromArgb(120, Color.IndianRed) };
                pieArchivos.SliceRelativeDisplacements = new float[] { .05f, .05f };
                pieArchivos.Texts = new string[] { "", "" };
            }
            catch { }
        }

        private void CrearPieArchivos(decimal TotalArchivos, decimal ArchivosProcesados)
        {
            try
            {
                if (TotalArchivos - ArchivosProcesados >= 1)
                    pieArchivos.Values = new decimal[] { ArchivosProcesados, TotalArchivos - ArchivosProcesados };
                else
                    pieArchivos.Values = new decimal[] { ArchivosProcesados, 0 };

                pieArchivos.ToolTips = new string[] { "Procesado: " + ArchivosProcesados.ToString() + "%", "Restante: " + (TotalArchivos - ArchivosProcesados).ToString() + "%" };
            }
            catch { }
        }

        #endregion Chart

        #region Threading

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

        #region IO

        #region ComunesIO

        private List<string> ObtenerUnidades(string Equipo, string Usuario, string Pass)
        {
            List<string> Resultados = new List<string> { };

            try
            {
                //Usuario y pass null para utulizar cuenta actual
                ConnectionOptions options = new ConnectionOptions { Username = Usuario, Password = Pass };
                ManagementScope scope = new ManagementScope(@"\\" + Equipo + @"\root\cimv2", options);
                ObjectQuery query = new ObjectQuery("select Name, Size, FreeSpace from Win32_LogicalDisk where drivetype <> '5'");
                ManagementObjectSearcher worker = new ManagementObjectSearcher(scope, query);
                ManagementObjectCollection results = worker.Get();

                foreach (ManagementObject item in results)
                    Resultados.Add(item["Name"].ToString().Replace(":", ""));
            }
            catch (Exception ex)
            {
                RegistrarLogLocal("ObtenerUnidades", ex.Message + "->" + ex.StackTrace, Equipo, "N/A");
            }

            Resultados = Resultados.OrderBy(q => q).ToList();

            return Resultados;
        }

        private TimeSpan CalculateDateDiff(DateTime ini, DateTime fin)
        {
            TimeSpan diff = (fin - ini);
            return diff;
        }

        #endregion ComunesIO

        #region UsandoBulkInsert

        #region BD

        private void ProcesarExclusionesBulk(Guid ProcesoId, string Equipo, string Unidad)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            SqlParameter param;

            try
            {
                cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Sistema"].ConnectionString);
                cmd = new SqlCommand("stpD_GlosarioExclusiones", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                param = new SqlParameter("@GAT_Id", SqlDbType.UniqueIdentifier);
                param.Value = ProcesoId;
                cmd.Parameters.Add(param);

                cn.Open();
                cmd.CommandTimeout = 600;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                RegistrarLogLocal("ProcesarExclusionesBulk", ex.Message + "->" + ex.StackTrace, Equipo, Unidad);
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
        }

        private void LimpiarTemporal(Guid ProcesoId, string Equipo, string Unidad)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            SqlParameter param;

            try
            {
                cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Sistema"].ConnectionString);
                cmd = new SqlCommand("stpD_GlosarioTemp", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                param = new SqlParameter("@GAT_Id", SqlDbType.UniqueIdentifier);
                param.Value = ProcesoId;
                cmd.Parameters.Add(param);

                cn.Open();
                cmd.CommandTimeout = 600;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                RegistrarLogLocal("LimpiarTemporal", ex.Message + "->" + ex.StackTrace, Equipo, Unidad);
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
        }

        private int ObtenerConteoArchivos(Guid id)
        {
            int Conteo = 0;
            DataTable MsjBD = new DataTable();
            SqlConnection cn = null;
            SqlCommand cmd = null;
            SqlParameter param;

            try
            {
                cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Sistema"].ConnectionString);
                cmd = new SqlCommand("stpS_GlosarioTemporalC", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                param = new SqlParameter("@GAT_Id", SqlDbType.UniqueIdentifier);
                param.Value = id;
                cmd.Parameters.Add(param);

                cn.Open();
                cmd.CommandTimeout = 10;
                MsjBD.Load(cmd.ExecuteReader());

                for (int w = 0; w < MsjBD.Rows.Count; w++)
                {
                    int.TryParse(MsjBD.Rows[w][0].ToString(), out Conteo);
                }
            }
            catch (Exception ex)
            {
                RegistrarLogLocal("ObtenerEquipos", ex.Message + "->" + ex.StackTrace, "N/A", "N/A");
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }

            return Conteo;
        }

        #endregion BD

        #region IO

        private IEnumerable<SqlBulkCopyColumnMapping> GetColumnMappings()
        {
            yield return new SqlBulkCopyColumnMapping("Id", "GAT_Id");
            yield return new SqlBulkCopyColumnMapping("Ruta", "GAT_Ruta");
            yield return new SqlBulkCopyColumnMapping("Tipo", "GAT_Tipo");
        }

        private void ProcesarUnidad(string Equipo, string Unidad, int TotalEquipos, int TotalUnidades, List<string> Exclusiones, Guid? ProcesoId)
        {
            try
            {
                //Crear Glosario en bruto
                Guid id;
                string Cnx = System.Configuration.ConfigurationManager.ConnectionStrings["Sistema"].ConnectionString;

                ActualizarControles("Analizando unidad " + Unidad + " del equipo " + Equipo + "...", "", "", "", "", "");
                id = new Guid(ProcesoId.ToString());

                IEnumerable<SqlBulkCopyColumnMapping> mappings = GetColumnMappings();

                BulkCopy bulkCopy = new BulkCopy()
                {
                    BatchSize = 10000,
                    ConnectionString = Cnx,
                    DestinationTableName = "dbo.GlosarioArchivos_Temporal"
                };

                bulkCopy.WriteToServer(SafeFileEnumerator.GetFilesAdv(@"\\" + Equipo + @"\" + Unidad + "$", "*.*", id), SqlBulkCopyOptions.Default, mappings);

                //Limpiar glosario de exclusiones
                if (ExcluirCarpetas)
                {
                    ActualizarControles("Procesando exclusiones de la unidad " + Unidad + " del equipo " + Equipo + "...", "", "", "", "", "");
                    ProcesarExclusionesBulk(id, Equipo, Unidad);
                }

                #region ProcesarListaArchivos

                List<string> ExclusionesL = new List<string> { };
                DataTable MsjBD = new DataTable();
                SqlConnection cn = null;
                SqlCommand cmd = null;
                SqlParameter param;

                try
                {
                    cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Sistema"].ConnectionString);
                    cmd = new SqlCommand("stpS_GlosarioTemporal", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cn.Open();
                    cmd.CommandTimeout = 6000;

                    param = new SqlParameter("@GAT_Id", SqlDbType.UniqueIdentifier);
                    param.Value = id;
                    cmd.Parameters.Add(param);

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        int ConteoActual = 0;
                        int TotalArchivos = ObtenerConteoArchivos(id);

                        try
                        {
                            UpdateControlCall(pnlPieCover, "false");
                        }
                        catch { }

                        while (rdr.Read())
                        {
                            try
                            {
                                string sArchivo = rdr.GetString(0);
                                string sTipo = rdr.GetString(1);

                                ConteoActual++;

                                try
                                {
                                    CrearPieArchivos(100, Convert.ToDecimal(Math.Round(Convert.ToDouble(ConteoActual * 100) / TotalArchivos, 2)));
                                }
                                catch { }

                                if (sTipo == "A") //Procesar archivos
                                {
                                    try
                                    {
                                        Archivo file = new Archivo(Equipo, Unidad, new Delimon.Win32.IO.FileInfo(sArchivo));

                                        ActualizarControles("Generando glosario...", "Archivo: " + file.NombreArchivo, "Progreso: " + Math.Round(Convert.ToDouble(ConteoActual * 100) / TotalArchivos, 2).ToString() + "% (" + ConteoActual.ToString() + " de " + TotalArchivos.ToString() + ")", Equipo + " (" + ConteoEquipos + " de " + TotalEquipos + ")", "Ruta: " + file.Ruta, Unidad + " (" + ConteoUnidades + " de " + TotalUnidades + ")");
                                        IngresarArchivo(EstadosProceso.Actualizar, Equipo, file.Ruta, "A", file.NombreArchivo, Unidad, file.Extension, file.Tamanno, file.FechaCreacion, file.FechaModificacion, "Progreso archivos Unidad " + Unidad + ": " + Math.Round(Convert.ToDouble(ConteoActual * 100) / TotalArchivos, 2).ToString() + "% (" + ConteoActual.ToString() + " de " + TotalArchivos.ToString() + ")" + ", ruta: " + file.Ruta + ", archivo: " + file.NombreArchivo + ".", ProcesoId);
                                    }
                                    catch (Exception ex)
                                    {
                                        RegistrarLogLocal("ProcesarUnidadMainA", ex.Message + "->" + ex.StackTrace, Equipo, sArchivo);
                                    }
                                }
                                else if (sTipo == "C") //Procesar carpetas
                                {
                                    try
                                    {
                                        Carpeta folder = new Carpeta(Equipo, Unidad, new Delimon.Win32.IO.DirectoryInfo(sArchivo));

                                        ActualizarControles("Generando glosario...", "Carpeta: " + folder.NombreArchivo, "Progreso: " + Math.Round(Convert.ToDouble(ConteoActual * 100) / TotalArchivos, 2).ToString() + "% (" + ConteoActual.ToString() + " de " + TotalArchivos.ToString() + ")", Equipo + " (" + ConteoEquipos + " de " + TotalEquipos + ")", "Ruta: " + folder.Ruta, Unidad + " (" + ConteoUnidades + " de " + TotalUnidades + ")");
                                        IngresarArchivo(EstadosProceso.Actualizar, Equipo, folder.Ruta, "C", folder.NombreArchivo, Unidad, folder.Extension, folder.Tamanno, folder.FechaCreacion, folder.FechaModificacion, "Progreso carpetas Unidad " + Unidad + ": " + Math.Round(Convert.ToDouble(ConteoActual * 100) / TotalArchivos, 2).ToString() + "% (" + ConteoActual.ToString() + " de " + TotalArchivos.ToString() + ")" + ", ruta: " + folder.Ruta + ", carpeta: " + folder.NombreArchivo + ".", ProcesoId);
                                    }
                                    catch (Exception ex)
                                    {
                                        RegistrarLogLocal("ProcesarUnidadMainC", ex.Message + "->" + ex.StackTrace, Equipo, sArchivo);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                RegistrarLogLocal("ProcesarUnidadMain", ex.Message + "->" + ex.StackTrace, Equipo, Unidad);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    RegistrarLogLocal("ProcesarUnidadSQLTemp", ex.Message + "->" + ex.StackTrace, Equipo, Unidad);
                }
                finally
                {
                    if (cn.State != ConnectionState.Closed)
                    {
                        cn.Close();
                    }
                }

                #endregion ProcesarListaArchivos

                LimpiarTemporal(id, Equipo, Unidad);
            }
            catch (Exception ex)
            {
                RegistrarLogLocal("ProcesarUnidad", ex.Message + "->" + ex.StackTrace, Equipo, "N/A");
            }
        }

        #endregion IO

        #endregion UsandoBulkInsert

        #region UsandoIEnumerables

        //private IEnumerable<string> ProcesarExclusionesOptimizado(IEnumerable<string> Archivos, IEnumerable<string> Exclusiones, string Equipo, string Unidad)
        //{
        //    IEnumerable<string> Resultados = Enumerable.Empty<string>();

        //    try
        //    {
        //        foreach (string sArchivo in Archivos)
        //        {
        //            foreach (string Excl in Exclusiones)
        //            {
        //                if (sArchivo.Contains(Excl))
        //                {
        //                    Resultados = Resultados.Append(sArchivo);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        RegistrarLogLocal("ProcesarExclusiones", ex.Message + "->" + ex.StackTrace, Equipo, "N/A");
        //    }

        //    return Archivos.Except(Resultados);
        //}
        //private void EnlistarArchivosOptimizado(string Equipo, string Unidad, int TotalEquipos, int TotalUnidades, IEnumerable<string> Exclusiones, Guid? ProcesoId)
        //{
        //    try
        //    {
        //        IEnumerable<string> Archivos;
        //        IEnumerable<string> Carpetas = Enumerable.Empty<string>();
        //        IEnumerable<string> ArchivosFiltrados;
        //        int TotalArchivos = 0;
        //        int TotalCarpetas = 0;
        //        int ConteoActual = 0;

        //        ActualizarControles("Analizando unidad " + Unidad + " del equipo " + Equipo + "...", "", "", "", "", "");
        //        Archivos = SafeFileEnumerator.GetFiles(@"\\" + Equipo + @"\" + Unidad + "$", "*.*").ToList();
        //        ActualizarControles("Procesando exclusiones en la unidad " + Unidad + " del equipo " + Equipo + "...", "", "", "", "", "");

        //        if (ExcluirCarpetas)
        //            ArchivosFiltrados = ProcesarExclusionesOptimizado(Archivos, Exclusiones, Equipo, Unidad);
        //        else
        //            ArchivosFiltrados = Archivos;

        //        TotalArchivos = ArchivosFiltrados.Count();
        //        GC.Collect();

        //        foreach (string sArchivo in ArchivosFiltrados)
        //        {
        //            try
        //            {
        //                ConteoActual++;

        //                try
        //                {
        //                    CrearPieArchivos(100, Convert.ToDecimal(Math.Round(Convert.ToDouble(ConteoActual * 100) / TotalArchivos, 2)));
        //                    UpdateControlCall(pnlPieCover, "false");
        //                }
        //                catch { }

        //                string CarpetaActual = Path.GetDirectoryName(sArchivo);
        //                Carpetas.Append(CarpetaActual);

        //                FileInfo Arch = new FileInfo(sArchivo);

        //                try
        //                {
        //                    Archivo file = new Archivo(Equipo, Unidad, Arch);

        //                    ActualizarControles("Generando glosario...", "Archivo: " + file.NombreArchivo, "Progreso: " + Math.Round(Convert.ToDouble(ConteoActual * 100) / TotalArchivos, 2).ToString() + "% (" + ConteoActual.ToString() + " de " + TotalArchivos.ToString() + ")", Equipo + " (" + ConteoEquipos + " de " + TotalEquipos + ")", "Ruta: " + file.Ruta, Unidad + " (" + ConteoUnidades + " de " + TotalUnidades + ")");
        //                    IngresarArchivo(EstadosProceso.Actualizar, Equipo, file.Ruta, "A", file.NombreArchivo, Unidad, file.Extension, file.Tamanno, file.FechaCreacion, file.FechaModificacion, "Progreso archivos Unidad " + Unidad + ": " + Math.Round(Convert.ToDouble(ConteoActual * 100) / TotalArchivos, 2).ToString() + "% (" + ConteoActual.ToString() + " de " + TotalArchivos.ToString() + ")" + ", ruta: " + file.Ruta + ", archivo: " + file.NombreArchivo + ".", ProcesoId);

        //                }
        //                catch (Exception ex)
        //                {
        //                    RegistrarLogLocal("EnlistarArchivosA", ex.Message + "->" + ex.StackTrace, Equipo, sArchivo);
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                if (ex is PathTooLongException)
        //                {
        //                    try
        //                    {
        //                        Delimon.Win32.IO.FileInfo fi = new Delimon.Win32.IO.FileInfo(sArchivo);

        //                        IngresarArchivo(EstadosProceso.Actualizar, Equipo, Delimon.Win32.IO.Path.GetDirectoryName(sArchivo).Replace(@"\\" + Equipo + @"\" + Unidad + @"$\", Unidad + @":\"), "A", Delimon.Win32.IO.Path.GetFileName(sArchivo).Replace(@"\\" + Equipo + @"\" + Unidad + @"$\", Unidad + @":\"), Unidad, Delimon.Win32.IO.Path.GetExtension(sArchivo), Convert.ToInt64(Math.Round(Convert.ToDouble(fi.Length) / 1024, 0)), fi.CreationTime, fi.LastWriteTime, "Progreso archivos Unidad " + Unidad + ": " + Math.Round(Convert.ToDouble(ConteoActual * 100) / TotalArchivos, 2).ToString() + "% (" + ConteoActual.ToString() + " de " + TotalArchivos.ToString() + ")" + ", archivo: " + sArchivo + ".", ProcesoId);
        //                    }
        //                    catch (Exception _ex)
        //                    {
        //                        RegistrarLogLocal("EnlistarArchivosGE", _ex.Message + "->" + _ex.StackTrace, Equipo, sArchivo);
        //                    }
        //                }
        //                else
        //                {
        //                    RegistrarLogLocal("EnlistarArchivosG", ex.Message + "->" + ex.StackTrace, Equipo, sArchivo);
        //                }
        //            }
        //        }

        //        IEnumerable<string> CarpetasF = Carpetas.Distinct();
        //        //Carpetas.Clear();
        //        //CarpetasF.Sort();
        //        TotalCarpetas = CarpetasF.Count();
        //        ConteoActual = 0;

        //        foreach (string Carpeta in CarpetasF)
        //        {
        //            try
        //            {
        //                ConteoActual++;

        //                try
        //                {
        //                    CrearPieArchivos(100, Convert.ToDecimal(Math.Round(Convert.ToDouble(ConteoActual * 100) / TotalCarpetas, 2)));
        //                    UpdateControlCall(pnlPieCover, "false");
        //                }
        //                catch { }

        //                DirectoryInfo Dir = new DirectoryInfo(Carpeta);
        //                Carpeta folder = new Carpeta(Equipo, Unidad, Dir);

        //                ActualizarControles("Generando glosario...", "Carpeta: " + folder.NombreArchivo, "Progreso: " + Math.Round(Convert.ToDouble(ConteoActual * 100) / TotalCarpetas, 2).ToString() + "% (" + ConteoActual.ToString() + " de " + TotalCarpetas.ToString() + ")", Equipo + " (" + ConteoEquipos + " de " + TotalEquipos + ")", "Ruta: " + folder.Ruta, Unidad + " (" + ConteoUnidades + " de " + TotalUnidades + ")");
        //                IngresarArchivo(EstadosProceso.Actualizar, Equipo, folder.Ruta, "C", folder.NombreArchivo, Unidad, folder.Extension, folder.Tamanno, folder.FechaCreacion, folder.FechaModificacion, "Progreso carpetas Unidad " + Unidad + ": " + Math.Round(Convert.ToDouble(ConteoActual * 100) / TotalCarpetas, 2).ToString() + "% (" + ConteoActual.ToString() + " de " + TotalCarpetas.ToString() + ")" + ", ruta: " + folder.Ruta + ", carpeta: " + folder.NombreArchivo + ".", ProcesoId);
        //            }
        //            catch (Exception ex)
        //            {
        //                if (ex is PathTooLongException)
        //                {
        //                    try
        //                    {
        //                        Delimon.Win32.IO.DirectoryInfo di = new Delimon.Win32.IO.DirectoryInfo(Carpeta);

        //                        IngresarArchivo(EstadosProceso.Actualizar, Equipo, Delimon.Win32.IO.Path.GetDirectoryName(Carpeta).Replace(@"\\" + Equipo + @"\" + Unidad + @"$\", Unidad + @":\"), "C", Delimon.Win32.IO.Path.GetFileName(Carpeta).Replace(@"\\" + Equipo + @"\" + Unidad + @"$\", Unidad + @":\"), Unidad, "", 0, di.CreationTime, di.LastWriteTime, "Progreso carpetas Unidad " + Unidad + ": " + Math.Round(Convert.ToDouble(ConteoActual * 100) / TotalArchivos, 2).ToString() + "% (" + ConteoActual.ToString() + " de " + TotalArchivos.ToString() + ")" + ", carpeta: " + Carpeta + ".", ProcesoId);
        //                    }
        //                    catch (Exception _ex)
        //                    {
        //                        RegistrarLogLocal("EnlistarArchivosCE", _ex.Message + "->" + _ex.StackTrace, Equipo, Carpeta);
        //                    }
        //                }
        //                else
        //                {
        //                    RegistrarLogLocal("EnlistarArchivosC", ex.Message + "->" + ex.StackTrace, Equipo, Carpeta);
        //                }
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        RegistrarLogLocal("EnlistarArchivos", ex.Message + "->" + ex.StackTrace, Equipo, "N/A");
        //    }
        //}

        #endregion UsandoIEnumerables

        #region UsandoList

        //private List<string> EnumerarCarpetas(string path, int indent)
        //{
        //    List<string> Carpetas = new List<string> { };

        //    try
        //    {
        //        if ((File.GetAttributes(path) & FileAttributes.ReparsePoint) != FileAttributes.ReparsePoint)
        //        {
        //            foreach (string folder in Directory.GetDirectories(path, "*.*", SearchOption.AllDirectories))
        //            {
        //                //Console.WriteLine(
        //                //    "{0}{1}", new string(' ', indent), Path.GetFileName(folder));
        //                Carpetas.Add(folder);

        //                EnumerarCarpetas(folder, indent + 2);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        RegistrarLogLocal("EnumerarCarpetas", ex.Message);
        //    }

        //    return Carpetas;
        //}

        //private List<string> ProcesarExclusiones(List<string> Archivos, List<string> Exclusiones, string Equipo, string Unidad)
        //{
        //    List<string> Resultados = new List<string> { };

        //    try
        //    {
        //        if (ExcluirCarpetas)
        //        {
        //            foreach (string sArchivo in Archivos)
        //            {
        //                foreach (string Excl in Exclusiones)
        //                {
        //                    if (sArchivo.Contains(Excl))
        //                    {
        //                        Resultados.Add(sArchivo);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        RegistrarLogLocal("ProcesarExclusiones", ex.Message + "->" + ex.StackTrace, Equipo, "N/A");
        //    }

        //    if (ExcluirCarpetas)
        //        return Archivos.Except(Resultados).ToList();
        //    else
        //        return Archivos;
        //}
        //private void EnlistarArchivos(string Equipo, string Unidad, int TotalEquipos, int TotalUnidades, List<string> Exclusiones, Guid? ProcesoId)
        //{
        //    try
        //    {
        //        //using (StreamWriter outfile = File.AppendText(Path.Combine(Environment.CurrentDirectory, "Archivos.txt")))
        //        //{
        //        List<string> Archivos = new List<string> { };
        //        List<string> Carpetas = new List<string> { };
        //        List<string> ArchivosFiltrados = new List<string> { };
        //        int TotalArchivos = 0;
        //        int TotalCarpetas = 0;
        //        int ConteoActual = 0;

        //        ActualizarControles("Analizando unidad " + Unidad + " del equipo " + Equipo + "...", "", "", "", "", "");
        //        Archivos = SafeFileEnumerator.GetFiles(@"\\" + Equipo + @"\" + Unidad + "$", "*.*").ToList();
        //        Archivos.Sort();
        //        ActualizarControles("Procesando exclusiones en la unidad " + Unidad + " del equipo " + Equipo + "...", "", "", "", "", "");
        //        ArchivosFiltrados = ProcesarExclusiones(Archivos, Exclusiones, Equipo, Unidad);
        //        Archivos.Clear();
        //        TotalArchivos = ArchivosFiltrados.Count();
        //        GC.Collect();

        //        foreach (string sArchivo in ArchivosFiltrados)
        //        {
        //            try
        //            {
        //                ConteoActual++;

        //                try
        //                {
        //                    CrearPieArchivos(100, Convert.ToDecimal(Math.Round(Convert.ToDouble(ConteoActual * 100) / TotalArchivos, 2)));
        //                    UpdateControlCall(pnlPieCover, "false");
        //                }
        //                catch { }
        //                /*
        //                string CarpetaActual = Path.GetDirectoryName(sArchivo);

        //                if (!Carpetas.Contains(CarpetaActual))
        //                {
        //                    Carpetas.Add(CarpetaActual);
        //                    DirectoryInfo Dir = new DirectoryInfo(CarpetaActual);

        //                    try
        //                    {
        //                        Carpeta folder = new Carpeta(Equipo, Unidad, Dir);

        //                        ActualizarControles("Generando glosario...", "Carpeta: " + folder.NombreArchivo, "Progreso: " + Math.Round(Convert.ToDouble(ConteoActual * 100) / TotalArchivos, 2).ToString() + "% (" + ConteoActual.ToString() + " de " + TotalArchivos.ToString() + ")", "Equipo: " + Equipo + " (" + ConteoEquipos + " de " + TotalEquipos + ")", "Ruta: " + folder.Ruta, "Unidad: " + Unidad + " (" + ConteoUnidades + " de " + TotalUnidades + ")");
        //                        IngresarArchivo(EstadosProceso.Actualizar, Equipo, folder.Ruta, "C", folder.NombreArchivo, Unidad, folder.Extension, folder.Tamanno, folder.FechaCreacion, folder.FechaModificacion, "Procesando equipo: " + Equipo + ", ruta: " + folder.Ruta + ", carpeta: " + folder.NombreArchivo + ".");
        //                        //outfile.WriteLine(folder.Servidor + "\t" + folder.Unidad + "\t" + folder.NombreArchivo + "\t" + folder.Tipo + "\t" +
        //                        //    folder.RegistroActual + "\t" + folder.Ruta + "\t" + folder.Extension + "\t" + folder.Tamanno.ToString() + "\t" +
        //                        //    folder.FechaCreacion.ToString("dd/MM/yyyy HH:mm:ss") + "\t" + folder.FechaModificacion.ToString("dd/MM/yyyy HH:mm:ss"));
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        RegistrarLogLocal("EnlistarArchivosC", ex.Message + "->" + ex.StackTrace, Equipo, sArchivo);
        //                    }
        //                }
        //                */
        //                string CarpetaActual = Path.GetDirectoryName(sArchivo);
        //                Carpetas.Add(CarpetaActual);

        //                FileInfo Arch = new FileInfo(sArchivo);

        //                try
        //                {
        //                    Archivo file = new Archivo(Equipo, Unidad, Arch);

        //                    ActualizarControles("Generando glosario...", "Archivo: " + file.NombreArchivo, "Progreso: " + Math.Round(Convert.ToDouble(ConteoActual * 100) / TotalArchivos, 2).ToString() + "% (" + ConteoActual.ToString() + " de " + TotalArchivos.ToString() + ")", Equipo + " (" + ConteoEquipos + " de " + TotalEquipos + ")", "Ruta: " + file.Ruta, Unidad + " (" + ConteoUnidades + " de " + TotalUnidades + ")");
        //                    IngresarArchivo(EstadosProceso.Actualizar, Equipo, file.Ruta, "A", file.NombreArchivo, Unidad, file.Extension, file.Tamanno, file.FechaCreacion, file.FechaModificacion, "Progreso archivos Unidad " + Unidad + ": " + Math.Round(Convert.ToDouble(ConteoActual * 100) / TotalArchivos, 2).ToString() + "% (" + ConteoActual.ToString() + " de " + TotalArchivos.ToString() + ")" + ", ruta: " + file.Ruta + ", archivo: " + file.NombreArchivo + ".", ProcesoId);
        //                    //outfile.WriteLine(file.Servidor + "\t" + file.Unidad + "\t" + file.NombreArchivo + "\t" + file.Tipo + "\t" +
        //                    //    file.RegistroActual + "\t" + file.Ruta + "\t" + file.Extension + "\t" + file.Tamanno.ToString() + "\t" +
        //                    //    file.FechaCreacion.ToString("dd/MM/yyyy HH:mm:ss") + "\t" + file.FechaModificacion.ToString("dd/MM/yyyy HH:mm:ss"));

        //                }
        //                catch (Exception ex)
        //                {
        //                    RegistrarLogLocal("EnlistarArchivosA", ex.Message + "->" + ex.StackTrace, Equipo, sArchivo);
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                if (ex is PathTooLongException)
        //                {
        //                    try
        //                    {
        //                        Delimon.Win32.IO.FileInfo fi = new Delimon.Win32.IO.FileInfo(sArchivo);

        //                        IngresarArchivo(EstadosProceso.Actualizar, Equipo, Delimon.Win32.IO.Path.GetDirectoryName(sArchivo).Replace(@"\\" + Equipo + @"\" + Unidad + @"$\", Unidad + @":\"), "A", Delimon.Win32.IO.Path.GetFileName(sArchivo).Replace(@"\\" + Equipo + @"\" + Unidad + @"$\", Unidad + @":\"), Unidad, Delimon.Win32.IO.Path.GetExtension(sArchivo), Convert.ToInt64(Math.Round(Convert.ToDouble(fi.Length) / 1024, 0)), fi.CreationTime, fi.LastWriteTime, "Progreso archivos Unidad " + Unidad + ": " + Math.Round(Convert.ToDouble(ConteoActual * 100) / TotalArchivos, 2).ToString() + "% (" + ConteoActual.ToString() + " de " + TotalArchivos.ToString() + ")" + ", archivo: " + sArchivo + ".", ProcesoId);
        //                    }
        //                    catch (Exception _ex)
        //                    {
        //                        RegistrarLogLocal("EnlistarArchivosGE", _ex.Message + "->" + _ex.StackTrace, Equipo, sArchivo);
        //                    }
        //                }
        //                else
        //                {
        //                    RegistrarLogLocal("EnlistarArchivosG", ex.Message + "->" + ex.StackTrace, Equipo, sArchivo);
        //                }
        //            }
        //        }

        //        List<string> CarpetasF = Carpetas.Distinct().ToList();
        //        Carpetas.Clear();
        //        CarpetasF.Sort();
        //        TotalCarpetas = CarpetasF.Count();
        //        ConteoActual = 0;

        //        foreach (string Carpeta in CarpetasF)
        //        {
        //            try
        //            {
        //                ConteoActual++;

        //                try
        //                {
        //                    CrearPieArchivos(100, Convert.ToDecimal(Math.Round(Convert.ToDouble(ConteoActual * 100) / TotalCarpetas, 2)));
        //                    UpdateControlCall(pnlPieCover, "false");
        //                }
        //                catch { }

        //                DirectoryInfo Dir = new DirectoryInfo(Carpeta);
        //                Carpeta folder = new Carpeta(Equipo, Unidad, Dir);

        //                ActualizarControles("Generando glosario...", "Carpeta: " + folder.NombreArchivo, "Progreso: " + Math.Round(Convert.ToDouble(ConteoActual * 100) / TotalCarpetas, 2).ToString() + "% (" + ConteoActual.ToString() + " de " + TotalCarpetas.ToString() + ")", Equipo + " (" + ConteoEquipos + " de " + TotalEquipos + ")", "Ruta: " + folder.Ruta, Unidad + " (" + ConteoUnidades + " de " + TotalUnidades + ")");
        //                IngresarArchivo(EstadosProceso.Actualizar, Equipo, folder.Ruta, "C", folder.NombreArchivo, Unidad, folder.Extension, folder.Tamanno, folder.FechaCreacion, folder.FechaModificacion, "Progreso carpetas Unidad " + Unidad + ": " + Math.Round(Convert.ToDouble(ConteoActual * 100) / TotalCarpetas, 2).ToString() + "% (" + ConteoActual.ToString() + " de " + TotalCarpetas.ToString() + ")" + ", ruta: " + folder.Ruta + ", carpeta: " + folder.NombreArchivo + ".", ProcesoId);
        //                //outfile.WriteLine(folder.Servidor + "\t" + folder.Unidad + "\t" + folder.NombreArchivo + "\t" + folder.Tipo + "\t" +
        //                //    folder.RegistroActual + "\t" + folder.Ruta + "\t" + folder.Extension + "\t" + folder.Tamanno.ToString() + "\t" +
        //                //    folder.FechaCreacion.ToString("dd/MM/yyyy HH:mm:ss") + "\t" + folder.FechaModificacion.ToString("dd/MM/yyyy HH:mm:ss"));
        //            }
        //            catch (Exception ex)
        //            {
        //                if (ex is PathTooLongException)
        //                {
        //                    try
        //                    {
        //                        Delimon.Win32.IO.DirectoryInfo di = new Delimon.Win32.IO.DirectoryInfo(Carpeta);

        //                        IngresarArchivo(EstadosProceso.Actualizar, Equipo, Delimon.Win32.IO.Path.GetDirectoryName(Carpeta).Replace(@"\\" + Equipo + @"\" + Unidad + @"$\", Unidad + @":\"), "C", Delimon.Win32.IO.Path.GetFileName(Carpeta).Replace(@"\\" + Equipo + @"\" + Unidad + @"$\", Unidad + @":\"), Unidad, "", 0, di.CreationTime, di.LastWriteTime, "Progreso carpetas Unidad " + Unidad + ": " + Math.Round(Convert.ToDouble(ConteoActual * 100) / TotalArchivos, 2).ToString() + "% (" + ConteoActual.ToString() + " de " + TotalArchivos.ToString() + ")" + ", carpeta: " + Carpeta + ".", ProcesoId);
        //                    }
        //                    catch (Exception _ex)
        //                    {
        //                        RegistrarLogLocal("EnlistarArchivosCE", _ex.Message + "->" + _ex.StackTrace, Equipo, Carpeta);
        //                    }
        //                }
        //                else
        //                {
        //                    RegistrarLogLocal("EnlistarArchivosC", ex.Message + "->" + ex.StackTrace, Equipo, Carpeta);
        //                }
        //            }
        //        }
        //        //}

        //    }
        //    catch (Exception ex)
        //    {
        //        RegistrarLogLocal("EnlistarArchivos", ex.Message + "->" + ex.StackTrace, Equipo, "N/A");
        //    }
        //}

        #endregion UsandoList

        #endregion IO

        #region BDGeneral

        private void IngresarArchivo(EstadosProceso Estado, string Equipo, string Ruta, string TipoObjeto, string Objeto, string Unidad, string Extension, Int64 Tamanno, DateTime FechaCreacion, DateTime FechaModificacion, string Mensaje, Guid? ProcesoId)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            SqlParameter param;

            try
            {
                if (Equipo.Length > MaxStrEquipo)
                    Equipo = Equipo.Substring(0, MaxStrEquipo);

                if (Extension.Length > MaxStrExtension)
                    Extension = Extension.Substring(0, MaxStrExtension);

                if (Mensaje.Length > MaxStrMensaje)
                    Mensaje = Mensaje.Substring(0, MaxStrMensaje);

                if (Objeto.Length > MaxStrObjeto)
                    Objeto = Objeto.Substring(0, MaxStrObjeto);

                if (Ruta.Length > MaxStrRuta)
                    Ruta = Ruta.Substring(0, MaxStrRuta);

                //Evitar desbordamiento de SQLDateTime
                if (FechaCreacion.Year < 1900 || FechaCreacion.Year > 2100)
                    FechaCreacion = new DateTime(1900, 1, 1);

                if (FechaModificacion.Year < 1900 || FechaModificacion.Year > 2100)
                    FechaModificacion = new DateTime(1900, 1, 1);

                cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Sistema"].ConnectionString);
                cmd = new SqlCommand("stpI_GlosarioArchivos", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                param = new SqlParameter("@Estado", SqlDbType.SmallInt);
                param.Value = (Int16)Estado;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GA_Equipo", SqlDbType.VarChar);
                param.Value = Equipo;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GA_Ruta", SqlDbType.VarChar);
                param.Value = Ruta;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GA_TipoObjeto", SqlDbType.VarChar);
                param.Value = TipoObjeto;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GA_Objeto", SqlDbType.VarChar);
                param.Value = Objeto;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GA_Unidad", SqlDbType.VarChar);
                param.Value = Unidad;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GA_Extension", SqlDbType.VarChar);
                param.Value = Extension;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GA_Tamanno", SqlDbType.BigInt);
                param.Value = Tamanno;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GA_FechaCreacion", SqlDbType.DateTime);
                param.Value = FechaCreacion;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GA_FechaModificacion", SqlDbType.DateTime);
                param.Value = FechaModificacion;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GAP_Mensaje", SqlDbType.VarChar);
                param.Value = Mensaje;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GAP_Id", SqlDbType.UniqueIdentifier);
                param.Value = ProcesoId;
                cmd.Parameters.Add(param);

                cn.Open();

                if (Estado == EstadosProceso.Actualizar)
                    cmd.CommandTimeout = 10;
                else
                    cmd.CommandTimeout = 600;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                RegistrarLogLocal("IngresarArchivo", ex.Message + "->" + ex.StackTrace, Equipo, Ruta + "\\" + Objeto);
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
        }

        private void IngresarArchivo(SqlConnection cn, EstadosProceso Estado, string Equipo, string Ruta, string TipoObjeto, string Objeto, string Unidad, string Extension, Int64 Tamanno, DateTime FechaCreacion, DateTime FechaModificacion, string Mensaje, Guid? ProcesoId)
        {
            //SqlConnection cn = null;
            SqlCommand cmd = null;
            SqlParameter param;

            try
            {
                if (Equipo.Length > MaxStrEquipo)
                    Equipo = Equipo.Substring(0, MaxStrEquipo);

                if (Extension.Length > MaxStrExtension)
                    Extension = Extension.Substring(0, MaxStrExtension);

                if (Mensaje.Length > MaxStrMensaje)
                    Mensaje = Mensaje.Substring(0, MaxStrMensaje);

                if (Objeto.Length > MaxStrObjeto)
                    Objeto = Objeto.Substring(0, MaxStrObjeto);

                if (Ruta.Length > MaxStrRuta)
                    Ruta = Ruta.Substring(0, MaxStrRuta);

                //Evitar desbordamiento de SQLDateTime
                if (FechaCreacion.Year < 1900 || FechaCreacion.Year > 2100)
                    FechaCreacion = new DateTime(1900, 1, 1);

                if (FechaModificacion.Year < 1900 || FechaModificacion.Year > 2100)
                    FechaModificacion = new DateTime(1900, 1, 1);

                //cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Sistema"].ConnectionString);
                cmd = new SqlCommand("stpI_GlosarioArchivos", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                param = new SqlParameter("@Estado", SqlDbType.SmallInt);
                param.Value = (Int16)Estado;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GA_Equipo", SqlDbType.VarChar);
                param.Value = Equipo;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GA_Ruta", SqlDbType.VarChar);
                param.Value = Ruta;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GA_TipoObjeto", SqlDbType.VarChar);
                param.Value = TipoObjeto;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GA_Objeto", SqlDbType.VarChar);
                param.Value = Objeto;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GA_Unidad", SqlDbType.VarChar);
                param.Value = Unidad;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GA_Extension", SqlDbType.VarChar);
                param.Value = Extension;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GA_Tamanno", SqlDbType.BigInt);
                param.Value = Tamanno;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GA_FechaCreacion", SqlDbType.DateTime);
                param.Value = FechaCreacion;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GA_FechaModificacion", SqlDbType.DateTime);
                param.Value = FechaModificacion;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GAP_Mensaje", SqlDbType.VarChar);
                param.Value = Mensaje;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GAP_Id", SqlDbType.UniqueIdentifier);
                param.Value = ProcesoId;
                cmd.Parameters.Add(param);

                //cn.Open();

                if (Estado == EstadosProceso.Actualizar)
                    cmd.CommandTimeout = 10;
                else
                    cmd.CommandTimeout = 600;

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                RegistrarLogLocal("IngresarArchivo", ex.Message + "->" + ex.StackTrace, Equipo, Ruta + "\\" + Objeto);
            }
            //finally
            //{
            //    if (cn.State != ConnectionState.Closed)
            //    {
            //        cn.Close();
            //    }
            //}
        }

        private List<string> ObtenerEquipos(Int16 Grupo)
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
                RegistrarLogLocal("ObtenerEquipos", ex.Message + "->" + ex.StackTrace, "N/A", "N/A");
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

        private List<string> ObtenerExclusiones()
        {
            List<string> Exclusiones = new List<string> { };
            DataTable MsjBD = new DataTable();
            SqlConnection cn = null;
            SqlCommand cmd = null;

            try
            {
                cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Sistema"].ConnectionString);
                cmd = new SqlCommand("stpS_GlosarioExclusiones", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                cmd.CommandTimeout = 10;
                MsjBD.Load(cmd.ExecuteReader());

                for (int w = 0; w < MsjBD.Rows.Count; w++)
                {
                    Exclusiones.Add(MsjBD.Rows[w][0].ToString());
                }
            }
            catch (Exception ex)
            {
                RegistrarLogLocal("ObtenerExclusiones", ex.Message + "->" + ex.StackTrace, "N/A", "N/A");
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }

            return Exclusiones;
        }

        private Guid? IniciarProceso(string Equipo)
        {
            Guid? Resultado = null;
            DataTable MsjBD = new DataTable();
            SqlConnection cn = null;
            SqlCommand cmd = null;
            SqlParameter param;

            try
            {
                cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Sistema"].ConnectionString);
                cmd = new SqlCommand("stpI_GlosarioProcesos", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                if (Equipo.Length > MaxStrEquipo)
                    Equipo = Equipo.Substring(0, MaxStrEquipo);

                param = new SqlParameter("@Estado", SqlDbType.TinyInt);
                param.Value = 1;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GAP_Equipo", SqlDbType.VarChar);
                param.Value = Equipo;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GAP_Mensaje", SqlDbType.VarChar);
                param.Value = "Iniciando proceso.";
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GAP_Id", SqlDbType.UniqueIdentifier);
                param.Value = new Guid();
                cmd.Parameters.Add(param);

                cn.Open();
                cmd.CommandTimeout = 10;
                MsjBD.Load(cmd.ExecuteReader());

                if (MsjBD.Rows.Count > 0)
                {
                    Resultado = (Guid)MsjBD.Rows[0][0];
                }
            }
            catch (Exception ex)
            {
                RegistrarLogLocal("IniciarProceso", ex.Message + "->" + ex.StackTrace, "N/A", "N/A");
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }

            return Resultado;
        }

        #endregion BDGeneral

        #region General

        private void ActualizarControles(string Accion, string Detalle, string DetalleAccion, string Equipo, string Ruta, string Unidad)
        {
            updateControl(lblAccion, Accion);
            updateControl(lblDetalle, Detalle);
            updateControl(lblDetalleAccion, DetalleAccion);
            updateControl(lblEquipo, Equipo);
            updateControl(lblRuta, Ruta);
            updateControl(lblUnidad, Unidad);
            updateControl(lblFechaAct, "Última actualización: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
        }

        private void Procesar()
        {
            try
            {
                List<string> Unidades = new List<string> { };
                List<string> Exclusiones = new List<string> { };
                Guid? ProcesoId = null;
                int TotalEquipos = 0;
                int TotalUnidades = 0;
                //Int16 Grupo = 0;
                DateTime Inicio = DateTime.Now;

                ActualizarControles("Obteniendo lista de equipos...", "", "", "", "", "");
                //Int16.TryParse(System.Configuration.ConfigurationManager.AppSettings["Grupo"], out Grupo);
                //Equipos = ObtenerEquipos(Grupo);
                ListaEquipos.Sort();
                Exclusiones = ObtenerExclusiones();
                Exclusiones.Sort();
                TotalEquipos = ListaEquipos.Count();

                string Usuario = System.Configuration.ConfigurationManager.AppSettings["Usuario"];
                string Password = System.Configuration.ConfigurationManager.AppSettings["Password"];

                if (string.IsNullOrWhiteSpace(Usuario))
                    Usuario = null;

                if (string.IsNullOrWhiteSpace(Password))
                    Password = null;

                foreach (string Equipo in ListaEquipos)
                {
                    ConteoEquipos++;
                    ConteoUnidades = 0;
                    ProcesoId = IniciarProceso(Equipo);
                    CrearPieEquipos(TotalEquipos, ConteoEquipos, Equipo);
                    UpdateControlCall(lblEq, "true");
                    UpdateControlCall(lblEquipo, "true");

                    if (ProcesoId != null)
                    {
                        ActualizarControles("Buscando unidades lógicas en el equipo " + Equipo, "", "", "", "", "");

                        if (EjecucionEspecial)
                            Unidades = ListaEspUnidades;
                        else
                            Unidades = ObtenerUnidades(Equipo, Usuario, Password);

                        Unidades.Sort();
                        TotalUnidades = Unidades.Count();
                        IngresarArchivo(EstadosProceso.Iniciar, Equipo, "", "", "", "", "", 0, DateTime.Now, DateTime.Now, "Iniciando proceso.", ProcesoId);

                        using (SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Sistema"].ConnectionString))
                        {
                            cn.Open();

                            foreach (string Unidad in Unidades)
                            {
                                ConteoUnidades++;
                                CrearPieUnidades(TotalUnidades, ConteoUnidades, Unidad);
                                UpdateControlCall(pnlPieCover, "true");
                                IngresarArchivo(cn, EstadosProceso.ActualizarEdo, Equipo, "", "", "", "", "", 0, DateTime.Now, DateTime.Now, "Analizando unidad " + Unidad, ProcesoId);
                                //EnlistarArchivos(Equipo, Unidad, TotalEquipos, TotalUnidades, Exclusiones, ProcesoId);
                                //EnlistarArchivosOptimizado(Equipo, Unidad, TotalEquipos, TotalUnidades, Exclusiones, ProcesoId);
                                ProcesarUnidad(Equipo, Unidad, TotalEquipos, TotalUnidades, Exclusiones, ProcesoId);
                                UpdateControlCall(pnlPieCover, "true");
                                GC.Collect();
                            }
                        }

                        IngresarArchivo(EstadosProceso.Finalizar, Equipo, "", "", "", "", "", 0, DateTime.Now, DateTime.Now, "Proceso finalizado" + Equipo + ".", ProcesoId);
                    }
                    else
                    {
                        RegistrarLogLocal("Procesar", "Error al obtener Id de proceso para el equipo \"" + Equipo + "\"", Equipo, "N/A");
                    }
                }

                ActualizarControles("Se ha generado el glosario para todos los equipos. Tiempo de proceso: " + CalculateDateDiff(Inicio, DateTime.Now).Days.ToString() + " día(s), " + CalculateDateDiff(Inicio, DateTime.Now).Hours.ToString() + " hora(s), " + CalculateDateDiff(Inicio, DateTime.Now).Minutes.ToString() + " minuto(s).", "", "", "", "", "");
            }
            catch (Exception ex)
            {
                RegistrarLogLocal("Procesar", ex.Message + "->" + ex.StackTrace, "N/A", "N/A");
            }
        }

        #endregion General

        #endregion Medodos

        #region Eventos

        private void frmMain_Load(object sender, EventArgs e)
        {
            wkrMain.RunWorkerAsync();
        }

        private void wkrMain_DoWork(object sender, DoWorkEventArgs e)
        {
            Procesar();
        }

        private void frmMain_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            GC.Collect();
            Application.Exit();
        }

        #endregion Eventos
    }

    public struct Archivo
    {
        public string Servidor;
        public string RegistroActual;
        public string Ruta;
        public string Unidad;
        public string NombreArchivo;
        public string Extension;
        public string Tipo;
        public Int64 Tamanno;
        public DateTime FechaCreacion;
        public DateTime FechaModificacion;

        public Archivo(string Srv, string LetraUnidad, Delimon.Win32.IO.FileInfo Arch)
        {
            Servidor = "";
            RegistroActual = "";
            Unidad = "";
            Ruta = "";
            NombreArchivo = "";
            Extension = "";
            Tipo = "A";
            Tamanno = 0;
            FechaCreacion = DateTime.Now;
            FechaModificacion = DateTime.Now;

            try
            {
                Servidor = Srv;
                RegistroActual = "";
                Unidad = LetraUnidad;
                Ruta = Arch.FullName.Replace(@"\\" + Srv + @"\" + Unidad + @"$\", Unidad + @":\");
                Ruta = Delimon.Win32.IO.Path.GetDirectoryName(Ruta);
                NombreArchivo = Arch.Name;
                Extension = Delimon.Win32.IO.Path.GetExtension(Arch.FullName);
                Tamanno = Convert.ToInt64(Math.Round(Convert.ToDouble(Arch.Length) / 1024, 0));
                FechaCreacion = Arch.CreationTime;
                FechaModificacion = Arch.LastWriteTime;
            }
            catch { }
        }
    }

    public struct Carpeta
    {
        public string Servidor;
        public string RegistroActual;
        public string Ruta;
        public string Unidad;
        public string NombreArchivo;
        public string Extension;
        public string Tipo;
        public Int64 Tamanno;
        public DateTime FechaCreacion;
        public DateTime FechaModificacion;

        public Carpeta(string Srv, string LetraUnidad, Delimon.Win32.IO.DirectoryInfo Fldr)
        {
            Servidor = "";
            RegistroActual = "";
            Unidad = "";
            Ruta = "";
            NombreArchivo = "";
            Extension = "";
            Tipo = "C";
            Tamanno = 0;
            FechaCreacion = DateTime.Now;
            FechaModificacion = DateTime.Now;

            try
            {
                Servidor = Srv;
                RegistroActual = "";
                Unidad = LetraUnidad;
                Ruta = Fldr.FullName.Replace(@"\\" + Srv + @"\" + Unidad + @"$\", Unidad + @":\");
                NombreArchivo = Fldr.Name;
                Extension = Delimon.Win32.IO.Path.GetExtension(Fldr.FullName);
                Tamanno = 0;
                FechaCreacion = Fldr.CreationTime;
                FechaModificacion = Fldr.LastWriteTime;
            }
            catch { }
        }
    }

    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Append<T>(
            this IEnumerable<T> source, params T[] tail)
        {
            return source.Concat(tail);
        }
    }
}