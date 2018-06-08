using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Windows.Forms;

namespace GlosarioArchivos
{
    public partial class frmEspecial : Form
    {
        #region Variables

        private const int MaxLog = 10000;
        private const string ArchivoLog = "LogEventos.log";
        private frmMain frm = new frmMain();

        #endregion Variables

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

        #region Metodos

        public frmEspecial()
        {
            InitializeComponent();
        }

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

        #endregion Metodos

        #region Eventos

        private void frmEspecial_Load(object sender, EventArgs e)
        {
            ddlEquipos.Items.AddRange(ObtenerEquipos(null).ToArray());
        }

        private void frmEspecial_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            for (int w = 0; w < chklUnidades.Items.Count; w++)
                chklUnidades.SetItemChecked(w, true);
        }

        private void btnNone_Click(object sender, EventArgs e)
        {
            for (int w = 0; w < chklUnidades.Items.Count; w++)
                chklUnidades.SetItemChecked(w, false);
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ddlEquipos.Text) && chklUnidades.CheckedItems.Count > 0)
            {
                List<string> Unidades = new List<string> { };
                List<string> Equipos = new List<string> { ddlEquipos.Text };

                for (int w = 0; w < chklUnidades.Items.Count; w++)
                {
                    if (chklUnidades.GetItemCheckState(w) == CheckState.Checked)
                        Unidades.Add(chklUnidades.Items[w].ToString());
                }

                frm.EjecucionEspecial = true;
                frm.ExcluirCarpetas = chkExcluir.Checked;
                frm.ListaEquipos = Equipos;
                frm.ListaEspUnidades = Unidades;
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Debe seleccionar por lo menos un equipo de la lista.", "Elementos insuficientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ddlEquipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            chklUnidades.Items.Clear();

            if (!string.IsNullOrWhiteSpace(ddlEquipos.Text))
            {
                string Usuario = System.Configuration.ConfigurationManager.AppSettings["Usuario"];
                string Password = System.Configuration.ConfigurationManager.AppSettings["Password"];

                if (string.IsNullOrWhiteSpace(Usuario))
                    Usuario = null;

                if (string.IsNullOrWhiteSpace(Password))
                    Password = null;

                chklUnidades.Items.AddRange(ObtenerUnidades(ddlEquipos.Text, Usuario, Password).ToArray());
            }
        }

        #endregion Eventos
    }
}