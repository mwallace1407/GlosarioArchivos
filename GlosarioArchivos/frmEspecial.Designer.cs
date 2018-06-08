namespace GlosarioArchivos
{
    partial class frmEspecial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEspecial));
            this.ddlEquipos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chklUnidades = new System.Windows.Forms.CheckedListBox();
            this.chkExcluir = new System.Windows.Forms.CheckBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.btnNone = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ddlEquipos
            // 
            this.ddlEquipos.BackColor = System.Drawing.Color.White;
            this.ddlEquipos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlEquipos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ddlEquipos.FormattingEnabled = true;
            this.ddlEquipos.Location = new System.Drawing.Point(16, 35);
            this.ddlEquipos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ddlEquipos.Name = "ddlEquipos";
            this.ddlEquipos.Size = new System.Drawing.Size(233, 26);
            this.ddlEquipos.TabIndex = 0;
            this.ddlEquipos.SelectedIndexChanged += new System.EventHandler(this.ddlEquipos_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Equipos:";
            // 
            // chklUnidades
            // 
            this.chklUnidades.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chklUnidades.BackColor = System.Drawing.Color.White;
            this.chklUnidades.CheckOnClick = true;
            this.chklUnidades.FormattingEnabled = true;
            this.chklUnidades.HorizontalScrollbar = true;
            this.chklUnidades.Location = new System.Drawing.Point(16, 72);
            this.chklUnidades.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chklUnidades.Name = "chklUnidades";
            this.chklUnidades.Size = new System.Drawing.Size(233, 130);
            this.chklUnidades.TabIndex = 2;
            // 
            // chkExcluir
            // 
            this.chkExcluir.AutoSize = true;
            this.chkExcluir.Checked = true;
            this.chkExcluir.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExcluir.Location = new System.Drawing.Point(15, 209);
            this.chkExcluir.Name = "chkExcluir";
            this.chkExcluir.Size = new System.Drawing.Size(193, 22);
            this.chkExcluir.TabIndex = 8;
            this.chkExcluir.Text = "Excluir carpetas de sistema";
            this.chkExcluir.UseVisualStyleBackColor = true;
            // 
            // btnGo
            // 
            this.btnGo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnGo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnGo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGo.Image = global::GlosarioArchivos.Properties.Resources.play_27;
            this.btnGo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGo.Location = new System.Drawing.Point(15, 309);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(233, 30);
            this.btnGo.TabIndex = 7;
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
            this.btnNone.Location = new System.Drawing.Point(15, 273);
            this.btnNone.Name = "btnNone";
            this.btnNone.Size = new System.Drawing.Size(233, 30);
            this.btnNone.TabIndex = 6;
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
            this.btnAll.Location = new System.Drawing.Point(15, 237);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(233, 30);
            this.btnAll.TabIndex = 5;
            this.btnAll.Text = "Seleccionar todos";
            this.btnAll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // frmEspecial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(264, 356);
            this.Controls.Add(this.chkExcluir);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.btnNone);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.chklUnidades);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ddlEquipos);
            this.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmEspecial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ejecución especial";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEspecial_FormClosing);
            this.Load += new System.EventHandler(this.frmEspecial_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ddlEquipos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox chklUnidades;
        private System.Windows.Forms.CheckBox chkExcluir;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnNone;
        private System.Windows.Forms.Button btnAll;
    }
}