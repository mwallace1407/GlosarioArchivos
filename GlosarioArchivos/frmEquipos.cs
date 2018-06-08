using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GlosarioArchivos
{
    public partial class frmEquipos : Form
    {
        #region Variables

        private const int MaxLog = 10000;
        private const string ArchivoLog = "LogEventos.log";
        private frmMain frm = new frmMain();
        private frmEspecial frmE = new frmEspecial();

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

        public frmEquipos()
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

        private void CargarLista()
        {
            chklEquipos.Items.Clear();
            chklEquipos.Items.AddRange(ObtenerEquipos(null).ToArray());
        }

        #endregion Metodos

        #region Eventos

        private void frmEquipos_Load(object sender, EventArgs e)
        {
            CargarLista();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            for (int w = 0; w < chklEquipos.Items.Count; w++)
                chklEquipos.SetItemChecked(w, true);
        }

        private void btnNone_Click(object sender, EventArgs e)
        {
            for (int w = 0; w < chklEquipos.Items.Count; w++)
                chklEquipos.SetItemChecked(w, false);
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (chklEquipos.CheckedItems.Count > 0)
            {
                List<string> Equipos = new List<string> { };

                for (int w = 0; w < chklEquipos.Items.Count; w++)
                {
                    if (chklEquipos.GetItemCheckState(w) == CheckState.Checked)
                        Equipos.Add(chklEquipos.Items[w].ToString());
                }

                frm.ExcluirCarpetas = chkExcluir.Checked;
                frm.ListaEquipos = Equipos;
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Debe seleccionar por lo menos un equipo de la lista.", "Elementos insuficientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnEspecial_Click(object sender, EventArgs e)
        {
            frmE.Show();
            this.Hide();
        }

        private void frmEquipos_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnAdminEquipos_Click(object sender, EventArgs e)
        {
            frmAdminEquipos frmA = new frmAdminEquipos();

            if (frmA.ShowDialog(this) != DialogResult.Cancel)
                CargarLista();
        }

        #endregion Eventos
    }
}