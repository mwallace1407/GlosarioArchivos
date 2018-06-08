using BrightIdeasSoftware;

namespace GlosarioArchivos
{
    partial class frmExtractor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            PresentationControls.CheckBoxProperties checkBoxProperties1 = new PresentationControls.CheckBoxProperties();
            PresentationControls.CheckBoxProperties checkBoxProperties2 = new PresentationControls.CheckBoxProperties();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExtractor));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.herramientasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbrirBusqueda = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGuardarBusqueda = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.accionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopiarArchivos = new System.Windows.Forms.ToolStripMenuItem();
            this.tabFiltros = new System.Windows.Forms.TabControl();
            this.tabP_General = new System.Windows.Forms.TabPage();
            this.ddlBusquedaMultiple = new System.Windows.Forms.ComboBox();
            this.lblMaxResT = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.numMaxResultados = new System.Windows.Forms.NumericUpDown();
            this.btnNone = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.ddlEquipos = new PresentationControls.CheckBoxComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKeywords = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabP_Fecha = new System.Windows.Forms.TabPage();
            this.gbFechasModificacion = new System.Windows.Forms.GroupBox();
            this.chkUsarFechasM = new System.Windows.Forms.CheckBox();
            this.chkHayErrorFFM = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblErrorFFM = new System.Windows.Forms.Label();
            this.dtIniM = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.dtFinM = new System.Windows.Forms.DateTimePicker();
            this.gbFechasCreacion = new System.Windows.Forms.GroupBox();
            this.chkUsarFechas = new System.Windows.Forms.CheckBox();
            this.chkHayErrorFF = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblErrorFF = new System.Windows.Forms.Label();
            this.dtIni = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtFin = new System.Windows.Forms.DateTimePicker();
            this.tabP_Tamanno = new System.Windows.Forms.TabPage();
            this.chkHayErrorFT = new System.Windows.Forms.CheckBox();
            this.lblErrorFT = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ddlTipoTamannoMax = new System.Windows.Forms.ComboBox();
            this.numTamannoMax = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.ddlTipoTamannoMin = new System.Windows.Forms.ComboBox();
            this.numTamannoMin = new System.Windows.Forms.NumericUpDown();
            this.chkUsarTamanno = new System.Windows.Forms.CheckBox();
            this.tabP_Avanzado = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.txtExtensiones = new System.Windows.Forms.TextBox();
            this.chkUsarExtensiones = new System.Windows.Forms.CheckBox();
            this.ddlUnidades = new PresentationControls.CheckBoxComboBox();
            this.chkUsarUnidades = new System.Windows.Forms.CheckBox();
            this.ddlRegAct = new System.Windows.Forms.ComboBox();
            this.chkUsarRegAct = new System.Windows.Forms.CheckBox();
            this.pnlBuscar = new System.Windows.Forms.Panel();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.gbResultados = new System.Windows.Forms.GroupBox();
            this.chkListSelect = new System.Windows.Forms.CheckBox();
            this.lstArchivos = new BrightIdeasSoftware.FastDataListView();
            this.colChk = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colEquipo = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colArchivo = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colRuta = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colTamanno = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colFechaCreacion = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colFechaModificacion = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colUnidad = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colExtension = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colRegAct = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.pbEngine = new System.Windows.Forms.PictureBox();
            this.status01 = new System.Windows.Forms.StatusStrip();
            this.lblEncontrados = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTamanno = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTiempo = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlEngine = new System.Windows.Forms.Panel();
            this.pbFile = new System.Windows.Forms.ProgressBar();
            this.pb01 = new System.Windows.Forms.ProgressBar();
            this.wkrBusqueda = new System.ComponentModel.BackgroundWorker();
            this.ofd01 = new System.Windows.Forms.OpenFileDialog();
            this.sfd01 = new System.Windows.Forms.SaveFileDialog();
            this.wkrCopia = new System.ComponentModel.BackgroundWorker();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.pnlProgreso = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.tabFiltros.SuspendLayout();
            this.tabP_General.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxResultados)).BeginInit();
            this.tabP_Fecha.SuspendLayout();
            this.gbFechasModificacion.SuspendLayout();
            this.gbFechasCreacion.SuspendLayout();
            this.tabP_Tamanno.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTamannoMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTamannoMin)).BeginInit();
            this.tabP_Avanzado.SuspendLayout();
            this.pnlBuscar.SuspendLayout();
            this.gbResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstArchivos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEngine)).BeginInit();
            this.status01.SuspendLayout();
            this.pnlEngine.SuspendLayout();
            this.pnlProgreso.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.herramientasToolStripMenuItem,
            this.accionesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(884, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // herramientasToolStripMenuItem
            // 
            this.herramientasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAbrirBusqueda,
            this.mnuGuardarBusqueda,
            this.toolStripMenuItem1,
            this.mnuExit});
            this.herramientasToolStripMenuItem.Name = "herramientasToolStripMenuItem";
            this.herramientasToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.herramientasToolStripMenuItem.Text = "&Herramientas";
            // 
            // mnuAbrirBusqueda
            // 
            this.mnuAbrirBusqueda.Name = "mnuAbrirBusqueda";
            this.mnuAbrirBusqueda.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuAbrirBusqueda.Size = new System.Drawing.Size(211, 22);
            this.mnuAbrirBusqueda.Text = "&Abrir búsqueda";
            this.mnuAbrirBusqueda.Click += new System.EventHandler(this.mnuAbrirBusqueda_Click);
            // 
            // mnuGuardarBusqueda
            // 
            this.mnuGuardarBusqueda.Name = "mnuGuardarBusqueda";
            this.mnuGuardarBusqueda.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuGuardarBusqueda.Size = new System.Drawing.Size(211, 22);
            this.mnuGuardarBusqueda.Text = "&Guardar búsqueda";
            this.mnuGuardarBusqueda.Click += new System.EventHandler(this.mnuGuardarBusqueda_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(208, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.mnuExit.Size = new System.Drawing.Size(211, 22);
            this.mnuExit.Text = "&Salir";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // accionesToolStripMenuItem
            // 
            this.accionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCopiarArchivos});
            this.accionesToolStripMenuItem.Name = "accionesToolStripMenuItem";
            this.accionesToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.accionesToolStripMenuItem.Text = "&Acciones";
            // 
            // mnuCopiarArchivos
            // 
            this.mnuCopiarArchivos.Name = "mnuCopiarArchivos";
            this.mnuCopiarArchivos.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.mnuCopiarArchivos.Size = new System.Drawing.Size(252, 22);
            this.mnuCopiarArchivos.Text = "&Copiar archivos seleccionados";
            this.mnuCopiarArchivos.Click += new System.EventHandler(this.mnuCopiarArchivos_Click);
            // 
            // tabFiltros
            // 
            this.tabFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabFiltros.Controls.Add(this.tabP_General);
            this.tabFiltros.Controls.Add(this.tabP_Fecha);
            this.tabFiltros.Controls.Add(this.tabP_Tamanno);
            this.tabFiltros.Controls.Add(this.tabP_Avanzado);
            this.tabFiltros.Location = new System.Drawing.Point(12, 27);
            this.tabFiltros.Name = "tabFiltros";
            this.tabFiltros.SelectedIndex = 0;
            this.tabFiltros.Size = new System.Drawing.Size(713, 155);
            this.tabFiltros.TabIndex = 1;
            // 
            // tabP_General
            // 
            this.tabP_General.BackColor = System.Drawing.Color.GhostWhite;
            this.tabP_General.Controls.Add(this.ddlBusquedaMultiple);
            this.tabP_General.Controls.Add(this.lblMaxResT);
            this.tabP_General.Controls.Add(this.label9);
            this.tabP_General.Controls.Add(this.label8);
            this.tabP_General.Controls.Add(this.numMaxResultados);
            this.tabP_General.Controls.Add(this.btnNone);
            this.tabP_General.Controls.Add(this.btnAll);
            this.tabP_General.Controls.Add(this.ddlEquipos);
            this.tabP_General.Controls.Add(this.label2);
            this.tabP_General.Controls.Add(this.txtKeywords);
            this.tabP_General.Controls.Add(this.label1);
            this.tabP_General.Location = new System.Drawing.Point(4, 23);
            this.tabP_General.Name = "tabP_General";
            this.tabP_General.Padding = new System.Windows.Forms.Padding(3);
            this.tabP_General.Size = new System.Drawing.Size(705, 128);
            this.tabP_General.TabIndex = 0;
            this.tabP_General.Text = "Búsqueda";
            // 
            // ddlBusquedaMultiple
            // 
            this.ddlBusquedaMultiple.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlBusquedaMultiple.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlBusquedaMultiple.Enabled = false;
            this.ddlBusquedaMultiple.FormattingEnabled = true;
            this.ddlBusquedaMultiple.Items.AddRange(new object[] {
            "Todas (Y)",
            "Cualquiera (O)"});
            this.ddlBusquedaMultiple.Location = new System.Drawing.Point(602, 6);
            this.ddlBusquedaMultiple.Name = "ddlBusquedaMultiple";
            this.ddlBusquedaMultiple.Size = new System.Drawing.Size(97, 22);
            this.ddlBusquedaMultiple.TabIndex = 11;
            // 
            // lblMaxResT
            // 
            this.lblMaxResT.BackColor = System.Drawing.Color.White;
            this.lblMaxResT.Location = new System.Drawing.Point(113, 64);
            this.lblMaxResT.Name = "lblMaxResT";
            this.lblMaxResT.Size = new System.Drawing.Size(96, 18);
            this.lblMaxResT.TabIndex = 10;
            this.lblMaxResT.Text = "Todos";
            this.lblMaxResT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMaxResT.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(235, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(333, 14);
            this.label9.TabIndex = 9;
            this.label9.Text = "(El valor cero indica que se mostrarán todos los resultados)";
            this.label9.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 14);
            this.label8.TabIndex = 8;
            this.label8.Text = "Max. resultados:";
            // 
            // numMaxResultados
            // 
            this.numMaxResultados.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numMaxResultados.Location = new System.Drawing.Point(109, 62);
            this.numMaxResultados.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numMaxResultados.Name = "numMaxResultados";
            this.numMaxResultados.Size = new System.Drawing.Size(120, 22);
            this.numMaxResultados.TabIndex = 7;
            this.numMaxResultados.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numMaxResultados.ThousandsSeparator = true;
            this.numMaxResultados.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numMaxResultados.ValueChanged += new System.EventHandler(this.numMaxResultados_ValueChanged);
            // 
            // btnNone
            // 
            this.btnNone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNone.FlatAppearance.BorderSize = 0;
            this.btnNone.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.btnNone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNone.Image = global::GlosarioArchivos.Properties.Resources.select_none_20;
            this.btnNone.Location = new System.Drawing.Point(676, 33);
            this.btnNone.Name = "btnNone";
            this.btnNone.Size = new System.Drawing.Size(23, 23);
            this.btnNone.TabIndex = 6;
            this.toolTip1.SetToolTip(this.btnNone, "Seleccionar ningún equipo");
            this.btnNone.UseVisualStyleBackColor = true;
            this.btnNone.Click += new System.EventHandler(this.btnNone_Click);
            // 
            // btnAll
            // 
            this.btnAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAll.FlatAppearance.BorderSize = 0;
            this.btnAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.btnAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAll.Image = global::GlosarioArchivos.Properties.Resources.select_all_20;
            this.btnAll.Location = new System.Drawing.Point(647, 33);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(23, 23);
            this.btnAll.TabIndex = 5;
            this.toolTip1.SetToolTip(this.btnAll, "Seleccionar todos los equipos");
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // ddlEquipos
            // 
            this.ddlEquipos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            checkBoxProperties1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ddlEquipos.CheckBoxProperties = checkBoxProperties1;
            this.ddlEquipos.DisplayMemberSingleItem = global::GlosarioArchivos.Properties.Resources.QueryBaseBusqueda;
            this.ddlEquipos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlEquipos.FormattingEnabled = true;
            this.ddlEquipos.Location = new System.Drawing.Point(109, 34);
            this.ddlEquipos.Name = "ddlEquipos";
            this.ddlEquipos.Size = new System.Drawing.Size(532, 22);
            this.ddlEquipos.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Equipos:";
            // 
            // txtKeywords
            // 
            this.txtKeywords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKeywords.Location = new System.Drawing.Point(109, 6);
            this.txtKeywords.Name = "txtKeywords";
            this.txtKeywords.Size = new System.Drawing.Size(487, 22);
            this.txtKeywords.TabIndex = 1;
            this.txtKeywords.Text = "*.*";
            this.txtKeywords.TextChanged += new System.EventHandler(this.txtKeywords_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Palabras clave:";
            // 
            // tabP_Fecha
            // 
            this.tabP_Fecha.BackColor = System.Drawing.Color.GhostWhite;
            this.tabP_Fecha.Controls.Add(this.gbFechasModificacion);
            this.tabP_Fecha.Controls.Add(this.gbFechasCreacion);
            this.tabP_Fecha.Location = new System.Drawing.Point(4, 23);
            this.tabP_Fecha.Name = "tabP_Fecha";
            this.tabP_Fecha.Padding = new System.Windows.Forms.Padding(3);
            this.tabP_Fecha.Size = new System.Drawing.Size(705, 128);
            this.tabP_Fecha.TabIndex = 1;
            this.tabP_Fecha.Text = "Fitros por fecha";
            // 
            // gbFechasModificacion
            // 
            this.gbFechasModificacion.Controls.Add(this.chkUsarFechasM);
            this.gbFechasModificacion.Controls.Add(this.chkHayErrorFFM);
            this.gbFechasModificacion.Controls.Add(this.label10);
            this.gbFechasModificacion.Controls.Add(this.lblErrorFFM);
            this.gbFechasModificacion.Controls.Add(this.dtIniM);
            this.gbFechasModificacion.Controls.Add(this.label12);
            this.gbFechasModificacion.Controls.Add(this.dtFinM);
            this.gbFechasModificacion.Location = new System.Drawing.Point(239, 6);
            this.gbFechasModificacion.Name = "gbFechasModificacion";
            this.gbFechasModificacion.Size = new System.Drawing.Size(225, 119);
            this.gbFechasModificacion.TabIndex = 11;
            this.gbFechasModificacion.TabStop = false;
            this.gbFechasModificacion.Text = "Fecha de modificación";
            // 
            // chkUsarFechasM
            // 
            this.chkUsarFechasM.AutoSize = true;
            this.chkUsarFechasM.Location = new System.Drawing.Point(6, 21);
            this.chkUsarFechasM.Name = "chkUsarFechasM";
            this.chkUsarFechasM.Size = new System.Drawing.Size(204, 18);
            this.chkUsarFechasM.TabIndex = 4;
            this.chkUsarFechasM.Text = "Utilizar filtro por rango de fechas";
            this.chkUsarFechasM.UseVisualStyleBackColor = true;
            this.chkUsarFechasM.CheckedChanged += new System.EventHandler(this.chkUsarFechasM_CheckedChanged);
            // 
            // chkHayErrorFFM
            // 
            this.chkHayErrorFFM.AutoSize = true;
            this.chkHayErrorFFM.Location = new System.Drawing.Point(228, 21);
            this.chkHayErrorFFM.Name = "chkHayErrorFFM";
            this.chkHayErrorFFM.Size = new System.Drawing.Size(15, 14);
            this.chkHayErrorFFM.TabIndex = 9;
            this.chkHayErrorFFM.UseVisualStyleBackColor = true;
            this.chkHayErrorFFM.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 14);
            this.label10.TabIndex = 0;
            this.label10.Text = "Fecha inicial:";
            // 
            // lblErrorFFM
            // 
            this.lblErrorFFM.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorFFM.ForeColor = System.Drawing.Color.DarkRed;
            this.lblErrorFFM.Location = new System.Drawing.Point(3, 98);
            this.lblErrorFFM.Name = "lblErrorFFM";
            this.lblErrorFFM.Size = new System.Drawing.Size(207, 18);
            this.lblErrorFFM.TabIndex = 8;
            // 
            // dtIniM
            // 
            this.dtIniM.CustomFormat = "dd/MM/yyyy";
            this.dtIniM.Enabled = false;
            this.dtIniM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtIniM.Location = new System.Drawing.Point(101, 45);
            this.dtIniM.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtIniM.Name = "dtIniM";
            this.dtIniM.Size = new System.Drawing.Size(97, 22);
            this.dtIniM.TabIndex = 1;
            this.dtIniM.ValueChanged += new System.EventHandler(this.dtIniM_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 79);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 14);
            this.label12.TabIndex = 2;
            this.label12.Text = "Fecha final:";
            // 
            // dtFinM
            // 
            this.dtFinM.CustomFormat = "dd/MM/yyyy";
            this.dtFinM.Enabled = false;
            this.dtFinM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFinM.Location = new System.Drawing.Point(101, 73);
            this.dtFinM.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtFinM.Name = "dtFinM";
            this.dtFinM.Size = new System.Drawing.Size(97, 22);
            this.dtFinM.TabIndex = 3;
            this.dtFinM.ValueChanged += new System.EventHandler(this.dtFinM_ValueChanged);
            // 
            // gbFechasCreacion
            // 
            this.gbFechasCreacion.Controls.Add(this.chkUsarFechas);
            this.gbFechasCreacion.Controls.Add(this.chkHayErrorFF);
            this.gbFechasCreacion.Controls.Add(this.label3);
            this.gbFechasCreacion.Controls.Add(this.lblErrorFF);
            this.gbFechasCreacion.Controls.Add(this.dtIni);
            this.gbFechasCreacion.Controls.Add(this.label4);
            this.gbFechasCreacion.Controls.Add(this.dtFin);
            this.gbFechasCreacion.Location = new System.Drawing.Point(8, 6);
            this.gbFechasCreacion.Name = "gbFechasCreacion";
            this.gbFechasCreacion.Size = new System.Drawing.Size(225, 119);
            this.gbFechasCreacion.TabIndex = 10;
            this.gbFechasCreacion.TabStop = false;
            this.gbFechasCreacion.Text = "Fecha de creación";
            // 
            // chkUsarFechas
            // 
            this.chkUsarFechas.AutoSize = true;
            this.chkUsarFechas.Location = new System.Drawing.Point(6, 21);
            this.chkUsarFechas.Name = "chkUsarFechas";
            this.chkUsarFechas.Size = new System.Drawing.Size(204, 18);
            this.chkUsarFechas.TabIndex = 4;
            this.chkUsarFechas.Text = "Utilizar filtro por rango de fechas";
            this.chkUsarFechas.UseVisualStyleBackColor = true;
            this.chkUsarFechas.CheckedChanged += new System.EventHandler(this.chkUsarFechas_CheckedChanged);
            // 
            // chkHayErrorFF
            // 
            this.chkHayErrorFF.AutoSize = true;
            this.chkHayErrorFF.Location = new System.Drawing.Point(228, 21);
            this.chkHayErrorFF.Name = "chkHayErrorFF";
            this.chkHayErrorFF.Size = new System.Drawing.Size(15, 14);
            this.chkHayErrorFF.TabIndex = 9;
            this.chkHayErrorFF.UseVisualStyleBackColor = true;
            this.chkHayErrorFF.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "Fecha inicial:";
            // 
            // lblErrorFF
            // 
            this.lblErrorFF.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorFF.ForeColor = System.Drawing.Color.DarkRed;
            this.lblErrorFF.Location = new System.Drawing.Point(3, 98);
            this.lblErrorFF.Name = "lblErrorFF";
            this.lblErrorFF.Size = new System.Drawing.Size(207, 18);
            this.lblErrorFF.TabIndex = 8;
            // 
            // dtIni
            // 
            this.dtIni.CustomFormat = "dd/MM/yyyy";
            this.dtIni.Enabled = false;
            this.dtIni.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtIni.Location = new System.Drawing.Point(101, 45);
            this.dtIni.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtIni.Name = "dtIni";
            this.dtIni.Size = new System.Drawing.Size(97, 22);
            this.dtIni.TabIndex = 1;
            this.dtIni.ValueChanged += new System.EventHandler(this.dtIni_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 14);
            this.label4.TabIndex = 2;
            this.label4.Text = "Fecha final:";
            // 
            // dtFin
            // 
            this.dtFin.CustomFormat = "dd/MM/yyyy";
            this.dtFin.Enabled = false;
            this.dtFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFin.Location = new System.Drawing.Point(101, 73);
            this.dtFin.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtFin.Name = "dtFin";
            this.dtFin.Size = new System.Drawing.Size(97, 22);
            this.dtFin.TabIndex = 3;
            this.dtFin.ValueChanged += new System.EventHandler(this.dtFin_ValueChanged);
            // 
            // tabP_Tamanno
            // 
            this.tabP_Tamanno.BackColor = System.Drawing.Color.GhostWhite;
            this.tabP_Tamanno.Controls.Add(this.chkHayErrorFT);
            this.tabP_Tamanno.Controls.Add(this.lblErrorFT);
            this.tabP_Tamanno.Controls.Add(this.label6);
            this.tabP_Tamanno.Controls.Add(this.ddlTipoTamannoMax);
            this.tabP_Tamanno.Controls.Add(this.numTamannoMax);
            this.tabP_Tamanno.Controls.Add(this.label5);
            this.tabP_Tamanno.Controls.Add(this.ddlTipoTamannoMin);
            this.tabP_Tamanno.Controls.Add(this.numTamannoMin);
            this.tabP_Tamanno.Controls.Add(this.chkUsarTamanno);
            this.tabP_Tamanno.Location = new System.Drawing.Point(4, 23);
            this.tabP_Tamanno.Name = "tabP_Tamanno";
            this.tabP_Tamanno.Size = new System.Drawing.Size(705, 128);
            this.tabP_Tamanno.TabIndex = 2;
            this.tabP_Tamanno.Text = "Filtros por tamaño";
            // 
            // chkHayErrorFT
            // 
            this.chkHayErrorFT.AutoSize = true;
            this.chkHayErrorFT.Location = new System.Drawing.Point(284, 8);
            this.chkHayErrorFT.Name = "chkHayErrorFT";
            this.chkHayErrorFT.Size = new System.Drawing.Size(15, 14);
            this.chkHayErrorFT.TabIndex = 10;
            this.chkHayErrorFT.UseVisualStyleBackColor = true;
            this.chkHayErrorFT.Visible = false;
            // 
            // lblErrorFT
            // 
            this.lblErrorFT.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorFT.ForeColor = System.Drawing.Color.DarkRed;
            this.lblErrorFT.Location = new System.Drawing.Point(6, 83);
            this.lblErrorFT.Name = "lblErrorFT";
            this.lblErrorFT.Size = new System.Drawing.Size(476, 18);
            this.lblErrorFT.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 14);
            this.label6.TabIndex = 6;
            this.label6.Text = "Tamaño máximo:";
            // 
            // ddlTipoTamannoMax
            // 
            this.ddlTipoTamannoMax.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlTipoTamannoMax.Enabled = false;
            this.ddlTipoTamannoMax.FormattingEnabled = true;
            this.ddlTipoTamannoMax.Items.AddRange(new object[] {
            "KB",
            "MB",
            "GB"});
            this.ddlTipoTamannoMax.Location = new System.Drawing.Point(235, 58);
            this.ddlTipoTamannoMax.Name = "ddlTipoTamannoMax";
            this.ddlTipoTamannoMax.Size = new System.Drawing.Size(45, 22);
            this.ddlTipoTamannoMax.TabIndex = 5;
            this.ddlTipoTamannoMax.SelectedIndexChanged += new System.EventHandler(this.ddlTipoTamannoMax_SelectedIndexChanged);
            // 
            // numTamannoMax
            // 
            this.numTamannoMax.Enabled = false;
            this.numTamannoMax.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numTamannoMax.Location = new System.Drawing.Point(109, 58);
            this.numTamannoMax.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numTamannoMax.Name = "numTamannoMax";
            this.numTamannoMax.Size = new System.Drawing.Size(120, 22);
            this.numTamannoMax.TabIndex = 4;
            this.numTamannoMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numTamannoMax.ThousandsSeparator = true;
            this.numTamannoMax.ValueChanged += new System.EventHandler(this.numTamannoMax_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 14);
            this.label5.TabIndex = 3;
            this.label5.Text = "Tamaño mínimo:";
            // 
            // ddlTipoTamannoMin
            // 
            this.ddlTipoTamannoMin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlTipoTamannoMin.Enabled = false;
            this.ddlTipoTamannoMin.FormattingEnabled = true;
            this.ddlTipoTamannoMin.Items.AddRange(new object[] {
            "KB",
            "MB",
            "GB"});
            this.ddlTipoTamannoMin.Location = new System.Drawing.Point(235, 30);
            this.ddlTipoTamannoMin.Name = "ddlTipoTamannoMin";
            this.ddlTipoTamannoMin.Size = new System.Drawing.Size(45, 22);
            this.ddlTipoTamannoMin.TabIndex = 2;
            this.ddlTipoTamannoMin.SelectedIndexChanged += new System.EventHandler(this.ddlTipoTamannoMin_SelectedIndexChanged);
            // 
            // numTamannoMin
            // 
            this.numTamannoMin.Enabled = false;
            this.numTamannoMin.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numTamannoMin.Location = new System.Drawing.Point(109, 30);
            this.numTamannoMin.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numTamannoMin.Name = "numTamannoMin";
            this.numTamannoMin.Size = new System.Drawing.Size(120, 22);
            this.numTamannoMin.TabIndex = 1;
            this.numTamannoMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numTamannoMin.ThousandsSeparator = true;
            this.numTamannoMin.ValueChanged += new System.EventHandler(this.numTamannoMin_ValueChanged);
            // 
            // chkUsarTamanno
            // 
            this.chkUsarTamanno.AutoSize = true;
            this.chkUsarTamanno.Location = new System.Drawing.Point(9, 6);
            this.chkUsarTamanno.Name = "chkUsarTamanno";
            this.chkUsarTamanno.Size = new System.Drawing.Size(269, 18);
            this.chkUsarTamanno.TabIndex = 0;
            this.chkUsarTamanno.Text = "Utilizar filtro por rango de tamaño de archivo";
            this.chkUsarTamanno.UseVisualStyleBackColor = true;
            this.chkUsarTamanno.CheckedChanged += new System.EventHandler(this.chkUsarTamanno_CheckedChanged);
            // 
            // tabP_Avanzado
            // 
            this.tabP_Avanzado.BackColor = System.Drawing.Color.GhostWhite;
            this.tabP_Avanzado.Controls.Add(this.label7);
            this.tabP_Avanzado.Controls.Add(this.txtExtensiones);
            this.tabP_Avanzado.Controls.Add(this.chkUsarExtensiones);
            this.tabP_Avanzado.Controls.Add(this.ddlUnidades);
            this.tabP_Avanzado.Controls.Add(this.chkUsarUnidades);
            this.tabP_Avanzado.Controls.Add(this.ddlRegAct);
            this.tabP_Avanzado.Controls.Add(this.chkUsarRegAct);
            this.tabP_Avanzado.Location = new System.Drawing.Point(4, 23);
            this.tabP_Avanzado.Name = "tabP_Avanzado";
            this.tabP_Avanzado.Size = new System.Drawing.Size(705, 128);
            this.tabP_Avanzado.TabIndex = 3;
            this.tabP_Avanzado.Text = "Avanzado";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(351, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(265, 14);
            this.label7.TabIndex = 8;
            this.label7.Text = "(Se pueden colocar varias separadas por coma)";
            // 
            // txtExtensiones
            // 
            this.txtExtensiones.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtExtensiones.Enabled = false;
            this.txtExtensiones.Location = new System.Drawing.Point(210, 60);
            this.txtExtensiones.Name = "txtExtensiones";
            this.txtExtensiones.Size = new System.Drawing.Size(135, 22);
            this.txtExtensiones.TabIndex = 7;
            this.txtExtensiones.TextChanged += new System.EventHandler(this.txtExtensiones_TextChanged);
            this.txtExtensiones.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtExtensiones_KeyPress);
            // 
            // chkUsarExtensiones
            // 
            this.chkUsarExtensiones.AutoSize = true;
            this.chkUsarExtensiones.Location = new System.Drawing.Point(9, 62);
            this.chkUsarExtensiones.Name = "chkUsarExtensiones";
            this.chkUsarExtensiones.Size = new System.Drawing.Size(183, 18);
            this.chkUsarExtensiones.TabIndex = 6;
            this.chkUsarExtensiones.Text = "Utilizar filtro de extensiones:";
            this.chkUsarExtensiones.UseVisualStyleBackColor = true;
            this.chkUsarExtensiones.CheckedChanged += new System.EventHandler(this.chkUsarExtensiones_CheckedChanged);
            // 
            // ddlUnidades
            // 
            this.ddlUnidades.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            checkBoxProperties2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ddlUnidades.CheckBoxProperties = checkBoxProperties2;
            this.ddlUnidades.DisplayMemberSingleItem = global::GlosarioArchivos.Properties.Resources.QueryBaseBusqueda;
            this.ddlUnidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlUnidades.Enabled = false;
            this.ddlUnidades.FormattingEnabled = true;
            this.ddlUnidades.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"});
            this.ddlUnidades.Location = new System.Drawing.Point(210, 32);
            this.ddlUnidades.Name = "ddlUnidades";
            this.ddlUnidades.Size = new System.Drawing.Size(135, 22);
            this.ddlUnidades.TabIndex = 5;
            // 
            // chkUsarUnidades
            // 
            this.chkUsarUnidades.AutoSize = true;
            this.chkUsarUnidades.Location = new System.Drawing.Point(9, 34);
            this.chkUsarUnidades.Name = "chkUsarUnidades";
            this.chkUsarUnidades.Size = new System.Drawing.Size(155, 18);
            this.chkUsarUnidades.TabIndex = 2;
            this.chkUsarUnidades.Text = "Utilizar filtro de unidad:";
            this.chkUsarUnidades.UseVisualStyleBackColor = true;
            this.chkUsarUnidades.CheckedChanged += new System.EventHandler(this.chkUsarUnidades_CheckedChanged);
            // 
            // ddlRegAct
            // 
            this.ddlRegAct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlRegAct.Enabled = false;
            this.ddlRegAct.FormattingEnabled = true;
            this.ddlRegAct.Items.AddRange(new object[] {
            "Registros actuales",
            "Registros pasados"});
            this.ddlRegAct.Location = new System.Drawing.Point(210, 4);
            this.ddlRegAct.Name = "ddlRegAct";
            this.ddlRegAct.Size = new System.Drawing.Size(135, 22);
            this.ddlRegAct.TabIndex = 1;
            // 
            // chkUsarRegAct
            // 
            this.chkUsarRegAct.AutoSize = true;
            this.chkUsarRegAct.Location = new System.Drawing.Point(9, 6);
            this.chkUsarRegAct.Name = "chkUsarRegAct";
            this.chkUsarRegAct.Size = new System.Drawing.Size(195, 18);
            this.chkUsarRegAct.TabIndex = 0;
            this.chkUsarRegAct.Text = "Utilizar filtro de registro actual:";
            this.chkUsarRegAct.UseVisualStyleBackColor = true;
            this.chkUsarRegAct.CheckedChanged += new System.EventHandler(this.chkUsarRegAct_CheckedChanged);
            // 
            // pnlBuscar
            // 
            this.pnlBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBuscar.BackColor = System.Drawing.Color.GhostWhite;
            this.pnlBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBuscar.Controls.Add(this.btnBuscar);
            this.pnlBuscar.Location = new System.Drawing.Point(731, 48);
            this.pnlBuscar.Name = "pnlBuscar";
            this.pnlBuscar.Size = new System.Drawing.Size(141, 134);
            this.pnlBuscar.TabIndex = 2;
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Image = global::GlosarioArchivos.Properties.Resources.Buscar_90;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBuscar.Location = new System.Drawing.Point(11, 6);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(117, 120);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.btnBuscar, "Iniciar la búsqueda de archivos");
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // gbResultados
            // 
            this.gbResultados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbResultados.BackColor = System.Drawing.SystemColors.Control;
            this.gbResultados.Controls.Add(this.chkListSelect);
            this.gbResultados.Controls.Add(this.lstArchivos);
            this.gbResultados.Location = new System.Drawing.Point(12, 188);
            this.gbResultados.Name = "gbResultados";
            this.gbResultados.Size = new System.Drawing.Size(860, 299);
            this.gbResultados.TabIndex = 3;
            this.gbResultados.TabStop = false;
            this.gbResultados.Text = "Resultados";
            // 
            // chkListSelect
            // 
            this.chkListSelect.AutoSize = true;
            this.chkListSelect.Location = new System.Drawing.Point(12, 28);
            this.chkListSelect.Name = "chkListSelect";
            this.chkListSelect.Size = new System.Drawing.Size(15, 14);
            this.chkListSelect.TabIndex = 1;
            this.chkListSelect.UseVisualStyleBackColor = true;
            this.chkListSelect.CheckedChanged += new System.EventHandler(this.chkListSelect_CheckedChanged);
            // 
            // lstArchivos
            // 
            this.lstArchivos.AllColumns.Add(this.colChk);
            this.lstArchivos.AllColumns.Add(this.colEquipo);
            this.lstArchivos.AllColumns.Add(this.colArchivo);
            this.lstArchivos.AllColumns.Add(this.colRuta);
            this.lstArchivos.AllColumns.Add(this.colTamanno);
            this.lstArchivos.AllColumns.Add(this.colFechaCreacion);
            this.lstArchivos.AllColumns.Add(this.colFechaModificacion);
            this.lstArchivos.AllColumns.Add(this.colUnidad);
            this.lstArchivos.AllColumns.Add(this.colExtension);
            this.lstArchivos.AllColumns.Add(this.colRegAct);
            this.lstArchivos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstArchivos.CheckBoxes = true;
            this.lstArchivos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colChk,
            this.colEquipo,
            this.colArchivo,
            this.colRuta,
            this.colTamanno,
            this.colFechaCreacion,
            this.colFechaModificacion,
            this.colUnidad,
            this.colExtension,
            this.colRegAct});
            this.lstArchivos.DataSource = null;
            this.lstArchivos.FullRowSelect = true;
            this.lstArchivos.GridLines = true;
            this.lstArchivos.Location = new System.Drawing.Point(6, 21);
            this.lstArchivos.Name = "lstArchivos";
            this.lstArchivos.ShowGroups = false;
            this.lstArchivos.ShowImagesOnSubItems = true;
            this.lstArchivos.Size = new System.Drawing.Size(848, 272);
            this.lstArchivos.TabIndex = 0;
            this.lstArchivos.UseCompatibleStateImageBehavior = false;
            this.lstArchivos.View = System.Windows.Forms.View.Details;
            this.lstArchivos.VirtualMode = true;
            this.lstArchivos.SelectionChanged += new System.EventHandler(this.lstArchivos_SelectionChanged);
            this.lstArchivos.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lstArchivos_ItemChecked);
            this.lstArchivos.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lstArchivos_ItemSelectionChanged);
            this.lstArchivos.SelectedIndexChanged += new System.EventHandler(this.lstArchivos_SelectedIndexChanged);
            // 
            // colChk
            // 
            this.colChk.IsEditable = false;
            this.colChk.Text = ".";
            this.colChk.Width = 25;
            // 
            // colEquipo
            // 
            this.colEquipo.AspectName = "Equipo";
            this.colEquipo.Text = "Equipo";
            this.colEquipo.Width = 82;
            // 
            // colArchivo
            // 
            this.colArchivo.AspectName = "Archivo";
            this.colArchivo.Text = "Archivo";
            this.colArchivo.Width = 144;
            // 
            // colRuta
            // 
            this.colRuta.AspectName = "Ruta";
            this.colRuta.Text = "Ruta";
            this.colRuta.Width = 192;
            // 
            // colTamanno
            // 
            this.colTamanno.AspectName = "Tamanno";
            this.colTamanno.Text = "Tamaño (KB)";
            this.colTamanno.Width = 82;
            // 
            // colFechaCreacion
            // 
            this.colFechaCreacion.AspectName = "FC";
            this.colFechaCreacion.Text = "Fecha creación";
            // 
            // colFechaModificacion
            // 
            this.colFechaModificacion.AspectName = "FM";
            this.colFechaModificacion.Text = "Fecha modificación";
            // 
            // colUnidad
            // 
            this.colUnidad.AspectName = "Unidad";
            this.colUnidad.Text = "Unidad";
            // 
            // colExtension
            // 
            this.colExtension.AspectName = "Extension";
            this.colExtension.Text = "Extensíon";
            this.colExtension.Width = 71;
            // 
            // colRegAct
            // 
            this.colRegAct.AspectName = "RegAct";
            this.colRegAct.Text = "Actual";
            // 
            // pbEngine
            // 
            this.pbEngine.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbEngine.Image = global::GlosarioArchivos.Properties.Resources.gears_animated_t1;
            this.pbEngine.Location = new System.Drawing.Point(360, 21);
            this.pbEngine.Name = "pbEngine";
            this.pbEngine.Size = new System.Drawing.Size(141, 141);
            this.pbEngine.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbEngine.TabIndex = 0;
            this.pbEngine.TabStop = false;
            // 
            // status01
            // 
            this.status01.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblEncontrados,
            this.lblTamanno,
            this.lblTiempo});
            this.status01.Location = new System.Drawing.Point(0, 490);
            this.status01.Name = "status01";
            this.status01.Size = new System.Drawing.Size(884, 22);
            this.status01.TabIndex = 4;
            this.status01.Text = "statusStrip1";
            // 
            // lblEncontrados
            // 
            this.lblEncontrados.Font = new System.Drawing.Font("Calibri", 8F);
            this.lblEncontrados.Name = "lblEncontrados";
            this.lblEncontrados.Size = new System.Drawing.Size(289, 17);
            this.lblEncontrados.Spring = true;
            this.lblEncontrados.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTamanno
            // 
            this.lblTamanno.Font = new System.Drawing.Font("Calibri", 8F);
            this.lblTamanno.Name = "lblTamanno";
            this.lblTamanno.Size = new System.Drawing.Size(289, 17);
            this.lblTamanno.Spring = true;
            this.lblTamanno.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTiempo
            // 
            this.lblTiempo.Font = new System.Drawing.Font("Calibri", 8F);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new System.Drawing.Size(289, 17);
            this.lblTiempo.Spring = true;
            this.lblTiempo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlEngine
            // 
            this.pnlEngine.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlEngine.Controls.Add(this.pnlProgreso);
            this.pnlEngine.Controls.Add(this.pbEngine);
            this.pnlEngine.Location = new System.Drawing.Point(1600, 188);
            this.pnlEngine.Name = "pnlEngine";
            this.pnlEngine.Size = new System.Drawing.Size(860, 263);
            this.pnlEngine.TabIndex = 5;
            this.pnlEngine.Visible = false;
            // 
            // pbFile
            // 
            this.pbFile.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbFile.Location = new System.Drawing.Point(6, 22);
            this.pbFile.Name = "pbFile";
            this.pbFile.Size = new System.Drawing.Size(141, 23);
            this.pbFile.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbFile.TabIndex = 2;
            this.pbFile.Visible = false;
            // 
            // pb01
            // 
            this.pb01.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pb01.Location = new System.Drawing.Point(6, 65);
            this.pb01.Name = "pb01";
            this.pb01.Size = new System.Drawing.Size(141, 23);
            this.pb01.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pb01.TabIndex = 1;
            this.pb01.Visible = false;
            // 
            // wkrBusqueda
            // 
            this.wkrBusqueda.DoWork += new System.ComponentModel.DoWorkEventHandler(this.wkrBusqueda_DoWork);
            this.wkrBusqueda.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.wkrBusqueda_RunWorkerCompleted);
            // 
            // ofd01
            // 
            this.ofd01.DefaultExt = "rbg";
            this.ofd01.Filter = "Resultados de búsqueda|*.rbg";
            // 
            // sfd01
            // 
            this.sfd01.DefaultExt = "rbg";
            this.sfd01.Filter = "Resultados de búsqueda|*.rbg";
            // 
            // wkrCopia
            // 
            this.wkrCopia.WorkerReportsProgress = true;
            this.wkrCopia.DoWork += new System.ComponentModel.DoWorkEventHandler(this.wkrCopia_DoWork);
            this.wkrCopia.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.wkrCopia_ProgressChanged);
            this.wkrCopia.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.wkrCopia_RunWorkerCompleted);
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 14);
            this.label11.TabIndex = 3;
            this.label11.Text = "Progreso total:";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 5);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(120, 14);
            this.label13.TabIndex = 4;
            this.label13.Text = "Progreso del archivo:";
            // 
            // pnlProgreso
            // 
            this.pnlProgreso.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlProgreso.Controls.Add(this.label13);
            this.pnlProgreso.Controls.Add(this.pb01);
            this.pnlProgreso.Controls.Add(this.label11);
            this.pnlProgreso.Controls.Add(this.pbFile);
            this.pnlProgreso.Location = new System.Drawing.Point(355, 166);
            this.pnlProgreso.Name = "pnlProgreso";
            this.pnlProgreso.Size = new System.Drawing.Size(153, 94);
            this.pnlProgreso.TabIndex = 5;
            this.pnlProgreso.Visible = false;
            // 
            // frmExtractor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 512);
            this.Controls.Add(this.pnlEngine);
            this.Controls.Add(this.status01);
            this.Controls.Add(this.gbResultados);
            this.Controls.Add(this.pnlBuscar);
            this.Controls.Add(this.tabFiltros);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(680, 400);
            this.Name = "frmExtractor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Extractor del glosario";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmExtractor_FormClosing);
            this.Load += new System.EventHandler(this.frmExtractor_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabFiltros.ResumeLayout(false);
            this.tabP_General.ResumeLayout(false);
            this.tabP_General.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxResultados)).EndInit();
            this.tabP_Fecha.ResumeLayout(false);
            this.gbFechasModificacion.ResumeLayout(false);
            this.gbFechasModificacion.PerformLayout();
            this.gbFechasCreacion.ResumeLayout(false);
            this.gbFechasCreacion.PerformLayout();
            this.tabP_Tamanno.ResumeLayout(false);
            this.tabP_Tamanno.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTamannoMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTamannoMin)).EndInit();
            this.tabP_Avanzado.ResumeLayout(false);
            this.tabP_Avanzado.PerformLayout();
            this.pnlBuscar.ResumeLayout(false);
            this.gbResultados.ResumeLayout(false);
            this.gbResultados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstArchivos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEngine)).EndInit();
            this.status01.ResumeLayout(false);
            this.status01.PerformLayout();
            this.pnlEngine.ResumeLayout(false);
            this.pnlEngine.PerformLayout();
            this.pnlProgreso.ResumeLayout(false);
            this.pnlProgreso.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem herramientasToolStripMenuItem;
        private System.Windows.Forms.TabControl tabFiltros;
        private System.Windows.Forms.TabPage tabP_General;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKeywords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabP_Fecha;
        private System.Windows.Forms.TabPage tabP_Tamanno;
        private System.Windows.Forms.TabPage tabP_Avanzado;
        private System.Windows.Forms.Panel pnlBuscar;
        private System.Windows.Forms.Button btnAll;
        private PresentationControls.CheckBoxComboBox ddlEquipos;
        private System.Windows.Forms.Button btnNone;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox gbResultados;
        private System.Windows.Forms.StatusStrip status01;
        private System.Windows.Forms.ToolStripStatusLabel lblEncontrados;
        private System.Windows.Forms.ToolStripStatusLabel lblTiempo;
        private System.Windows.Forms.PictureBox pbEngine;
        private System.Windows.Forms.Panel pnlEngine;
        private System.Windows.Forms.ToolStripStatusLabel lblTamanno;
        private System.Windows.Forms.CheckBox chkUsarFechas;
        private System.Windows.Forms.DateTimePicker dtFin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtIni;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox ddlTipoTamannoMax;
        private System.Windows.Forms.NumericUpDown numTamannoMax;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ddlTipoTamannoMin;
        private System.Windows.Forms.NumericUpDown numTamannoMin;
        private System.Windows.Forms.CheckBox chkUsarTamanno;
        private System.Windows.Forms.Label lblErrorFF;
        private System.Windows.Forms.Label lblErrorFT;
        private System.Windows.Forms.CheckBox chkHayErrorFF;
        private System.Windows.Forms.CheckBox chkHayErrorFT;
        private System.ComponentModel.BackgroundWorker wkrBusqueda;
        private System.Windows.Forms.CheckBox chkUsarRegAct;
        private System.Windows.Forms.ComboBox ddlRegAct;
        private PresentationControls.CheckBoxComboBox ddlUnidades;
        private System.Windows.Forms.CheckBox chkUsarUnidades;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtExtensiones;
        private System.Windows.Forms.CheckBox chkUsarExtensiones;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numMaxResultados;
        private System.Windows.Forms.ToolStripMenuItem mnuAbrirBusqueda;
        private System.Windows.Forms.ToolStripMenuItem mnuGuardarBusqueda;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem accionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuCopiarArchivos;
        private System.Windows.Forms.OpenFileDialog ofd01;
        private System.Windows.Forms.SaveFileDialog sfd01;
        private System.Windows.Forms.Label lblMaxResT;
        private FastDataListView lstArchivos;
        private OLVColumn colChk;
        private OLVColumn colEquipo;
        private OLVColumn colArchivo;
        private OLVColumn colRuta;
        private OLVColumn colTamanno;
        private OLVColumn colFechaCreacion;
        private OLVColumn colFechaModificacion;
        private OLVColumn colUnidad;
        private OLVColumn colExtension;
        private OLVColumn colRegAct;
        private System.Windows.Forms.CheckBox chkListSelect;
        private System.ComponentModel.BackgroundWorker wkrCopia;
        private System.Windows.Forms.ProgressBar pb01;
        private System.Windows.Forms.GroupBox gbFechasCreacion;
        private System.Windows.Forms.GroupBox gbFechasModificacion;
        private System.Windows.Forms.CheckBox chkUsarFechasM;
        private System.Windows.Forms.CheckBox chkHayErrorFFM;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblErrorFFM;
        private System.Windows.Forms.DateTimePicker dtIniM;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtFinM;
        private System.Windows.Forms.ComboBox ddlBusquedaMultiple;
        private System.Windows.Forms.ProgressBar pbFile;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel pnlProgreso;
    }
}