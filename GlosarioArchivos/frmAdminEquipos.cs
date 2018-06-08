using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Delimon.Win32.IO;

namespace GlosarioArchivos
{
    public partial class frmAdminEquipos : Form
    {
        #region Variables

        private const int MaxLog = 10000;
        private const string ArchivoLog = "LogEventos.log";

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

        public frmAdminEquipos()
        {
            InitializeComponent();
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

        private void RegistrarEquipos(string Equipo, bool Activo)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            SqlParameter param;

            try
            {
                cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Sistema"].ConnectionString);
                cmd = new SqlCommand("stpU_GlosarioEquipos", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                param = new SqlParameter("@GAE_Nombre", SqlDbType.VarChar);
                param.Value = Equipo;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@GAE_Procesar", SqlDbType.Bit);
                param.Value = Activo;
                cmd.Parameters.Add(param);

                cn.Open();
                cmd.CommandTimeout = 10;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                RegistrarLogLocal("RegistrarEquipos", ex.Message + "->" + ex.StackTrace, "N/A", "N/A");
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
        }

        #endregion Metodos

        #region Eventos

        private void frmAdminEquipos_Load(object sender, EventArgs e)
        {
            ddlEquipos.Items.AddRange(ObtenerEquipos(0).ToArray());
            ddlEquipos.Focus();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            RegistrarEquipos(ddlEquipos.Text, true);
            MessageBox.Show("El equipo " + ddlEquipos.Text + " ha sido agregado al catálogo", "Administrar equipos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            RegistrarEquipos(ddlEquipos.Text, false);
            MessageBox.Show("El equipo " + ddlEquipos.Text + " ha sido eliminado del catálogo", "Administrar equipos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        #endregion Eventos
    }
}