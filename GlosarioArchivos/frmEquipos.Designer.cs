namespace GlosarioArchivos
{
    partial class frmEquipos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEquipos));
            this.chklEquipos = new System.Windows.Forms.CheckedListBox();
            this.chkExcluir = new System.Windows.Forms.CheckBox();
            this.btnEspecial = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.btnNone = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnAdminEquipos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chklEquipos
            // 
            this.chklEquipos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chklEquipos.BackColor = System.Drawing.Color.White;
            this.chklEquipos.CheckOnClick = true;
            this.chklEquipos.FormattingEnabled = true;
            this.chklEquipos.HorizontalScrollbar = true;
            this.chklEquipos.Location = new System.Drawing.Point(12, 62);
            this.chklEquipos.Name = "chklEquipos";
            this.chklEquipos.Size = new System.Drawing.Size(233, 256);
            this.chklEquipos.TabIndex = 0;
            // 
            // chkExcluir
            // 
            this.chkExcluir.AutoSize = true;
            this.chkExcluir.Checked = true;
            this.chkExcluir.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExcluir.Location = new System.Drawing.Point(12, 370);
            this.chkExcluir.Name = "chkExcluir";
            this.chkExcluir.Size = new System.Drawing.Size(193, 22);
            this.chkExcluir.TabIndex = 4;
            this.chkExcluir.Text = "Excluir carpetas de sistema";
            this.chkExcluir.UseVisualStyleBackColor = true;
            // 
            // btnEspecial
            // 
            this.btnEspecial.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightYellow;
            this.btnEspecial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEspecial.Image = global::GlosarioArchivos.Properties.Resources.floppy_disk_27;
            this.btnEspecial.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEspecial.Location = new System.Drawing.Point(12, 12);
            this.btnEspecial.Name = "btnEspecial";
            this.btnEspecial.Size = new System.Drawing.Size(233, 30);
            this.btnEspecial.TabIndex = 5;
            this.btnEspecial.Text = "Ejecución especial";
            this.btnEspecial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEspecial.UseVisualStyleBackColor = true;
            this.btnEspecial.Click += new System.EventHandler(this.btnEspecial_Click);
            // 
            // btnGo
            // 
            this.btnGo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnGo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnGo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGo.Image = global::GlosarioArchivos.Properties.Resources.play_27;
            this.btnGo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGo.Location = new System.Drawing.Point(12, 470);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(233, 30);
            this.btnGo.TabIndex = 3;
            this.btnGo.Text = "Iniciar escaneo";
            this.btnGo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnNone
            // 
            this.btnNone.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNone.Image = global::GlosarioArchivos.Properties.Resources.select_none_27;
            this.btnNone.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNone.Location = new System.Drawing.Point(12, 434);
            this.btnNone.Name = "btnNone";
            this.btnNone.Size = new System.Drawing.Size(233, 30);
            this.btnNone.TabIndex = 2;
            this.btnNone.Text = "Seleccionar ninguno";
            this.btnNone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNone.UseVisualStyleBackColor = true;
            this.btnNone.Click += new System.EventHandler(this.btnNone_Click);
            // 
            // btnAll
            // 
            this.btnAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAll.Image = global::GlosarioArchivos.Properties.Resources.select_all_27;
            this.btnAll.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAll.Location = new System.Drawing.Point(12, 398);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(233, 30);
            this.btnAll.TabIndex = 1;
            this.btnAll.Text = "Seleccionar todos";
            this.btnAll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnAdminEquipos
            // 
            this.btnAdminEquipos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.NavajoWhite;
            this.btnAdminEquipos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdminEquipos.Image = global::GlosarioArchivos.Properties.Resources.pc_add_plus_27;
            this.btnAdminEquipos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdminEquipos.Location = new System.Drawing.Point(12, 324);
            this.btnAdminEquipos.Name = "btnAdminEquipos";
            this.btnAdminEquipos.Size = new System.Drawing.Size(233, 30);
            this.btnAdminEquipos.TabIndex = 6;
            this.btnAdminEquipos.Text = "Administrar equipos";
            this.btnAdminEquipos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdminEquipos.UseVisualStyleBackColor = true;
            this.btnAdminEquipos.Click += new System.EventHandler(this.btnAdminEquipos_Click);
            // 
            // frmEquipos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(257, 515);
            this.Controls.Add(this.btnAdminEquipos);
            this.Controls.Add(this.btnEspecial);
            this.Controls.Add(this.chkExcluir);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.btnNone);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.chklEquipos);
            this.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEquipos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccione los equipos a escanear";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEquipos_FormClosing);
            this.Load += new System.EventHandler(this.frmEquipos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox chklEquipos;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnNone;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.CheckBox chkExcluir;
        private System.Windows.Forms.Button btnEspecial;
        private System.Windows.Forms.Button btnAdminEquipos;
    }
}