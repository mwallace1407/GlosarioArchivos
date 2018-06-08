namespace GlosarioArchivos
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.wkrMain = new System.ComponentModel.BackgroundWorker();
            this.lblAccion = new System.Windows.Forms.Label();
            this.lblFechaAct = new System.Windows.Forms.Label();
            this.lblEquipo = new System.Windows.Forms.Label();
            this.lblUnidad = new System.Windows.Forms.Label();
            this.lblRuta = new System.Windows.Forms.Label();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.lblDetalleAccion = new System.Windows.Forms.Label();
            this.pieEquipos = new System.Drawing.PieChart.PieChartControl();
            this.pieUnidades = new System.Drawing.PieChart.PieChartControl();
            this.pieArchivos = new System.Drawing.PieChart.PieChartControl();
            this.pnlPieCover = new System.Windows.Forms.Panel();
            this.lblEq = new System.Windows.Forms.Label();
            this.lblUni = new System.Windows.Forms.Label();
            this.lblObj = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // wkrMain
            // 
            this.wkrMain.WorkerSupportsCancellation = true;
            this.wkrMain.DoWork += new System.ComponentModel.DoWorkEventHandler(this.wkrMain_DoWork);
            // 
            // lblAccion
            // 
            this.lblAccion.AutoSize = true;
            this.lblAccion.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccion.Location = new System.Drawing.Point(13, 9);
            this.lblAccion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAccion.Name = "lblAccion";
            this.lblAccion.Size = new System.Drawing.Size(129, 18);
            this.lblAccion.TabIndex = 0;
            this.lblAccion.Text = "Iniciando proceso...";
            // 
            // lblFechaAct
            // 
            this.lblFechaAct.AutoSize = true;
            this.lblFechaAct.Location = new System.Drawing.Point(12, 323);
            this.lblFechaAct.Name = "lblFechaAct";
            this.lblFechaAct.Size = new System.Drawing.Size(44, 18);
            this.lblFechaAct.TabIndex = 2;
            this.lblFechaAct.Text = "Fecha";
            // 
            // lblEquipo
            // 
            this.lblEquipo.Location = new System.Drawing.Point(13, 269);
            this.lblEquipo.Name = "lblEquipo";
            this.lblEquipo.Size = new System.Drawing.Size(203, 18);
            this.lblEquipo.TabIndex = 3;
            this.lblEquipo.Text = "Equipo";
            this.lblEquipo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblEquipo.Visible = false;
            // 
            // lblUnidad
            // 
            this.lblUnidad.Location = new System.Drawing.Point(219, 269);
            this.lblUnidad.Name = "lblUnidad";
            this.lblUnidad.Size = new System.Drawing.Size(203, 18);
            this.lblUnidad.TabIndex = 4;
            this.lblUnidad.Text = "Unidad";
            this.lblUnidad.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblRuta
            // 
            this.lblRuta.AutoSize = true;
            this.lblRuta.Location = new System.Drawing.Point(12, 305);
            this.lblRuta.Name = "lblRuta";
            this.lblRuta.Size = new System.Drawing.Size(36, 18);
            this.lblRuta.TabIndex = 5;
            this.lblRuta.Text = "Ruta";
            // 
            // lblDetalle
            // 
            this.lblDetalle.AutoSize = true;
            this.lblDetalle.Location = new System.Drawing.Point(12, 287);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(60, 18);
            this.lblDetalle.TabIndex = 6;
            this.lblDetalle.Text = "Detalle2";
            // 
            // lblDetalleAccion
            // 
            this.lblDetalleAccion.AutoSize = true;
            this.lblDetalleAccion.Location = new System.Drawing.Point(12, 27);
            this.lblDetalleAccion.Name = "lblDetalleAccion";
            this.lblDetalleAccion.Size = new System.Drawing.Size(94, 18);
            this.lblDetalleAccion.TabIndex = 1;
            this.lblDetalleAccion.Text = "DetalleAccion";
            // 
            // pieEquipos
            // 
            this.pieEquipos.Location = new System.Drawing.Point(16, 66);
            this.pieEquipos.Name = "pieEquipos";
            this.pieEquipos.Size = new System.Drawing.Size(200, 200);
            this.pieEquipos.TabIndex = 7;
            this.pieEquipos.ToolTips = null;
            // 
            // pieUnidades
            // 
            this.pieUnidades.Location = new System.Drawing.Point(222, 66);
            this.pieUnidades.Name = "pieUnidades";
            this.pieUnidades.Size = new System.Drawing.Size(200, 200);
            this.pieUnidades.TabIndex = 8;
            this.pieUnidades.ToolTips = null;
            // 
            // pieArchivos
            // 
            this.pieArchivos.BackColor = System.Drawing.Color.White;
            this.pieArchivos.Location = new System.Drawing.Point(428, 66);
            this.pieArchivos.Name = "pieArchivos";
            this.pieArchivos.Size = new System.Drawing.Size(200, 200);
            this.pieArchivos.TabIndex = 9;
            this.pieArchivos.ToolTips = null;
            // 
            // pnlPieCover
            // 
            this.pnlPieCover.Location = new System.Drawing.Point(222, 48);
            this.pnlPieCover.Name = "pnlPieCover";
            this.pnlPieCover.Size = new System.Drawing.Size(442, 239);
            this.pnlPieCover.TabIndex = 10;
            // 
            // lblEq
            // 
            this.lblEq.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEq.Location = new System.Drawing.Point(13, 45);
            this.lblEq.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEq.Name = "lblEq";
            this.lblEq.Size = new System.Drawing.Size(203, 18);
            this.lblEq.TabIndex = 11;
            this.lblEq.Text = "Equipos";
            this.lblEq.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblEq.Visible = false;
            // 
            // lblUni
            // 
            this.lblUni.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUni.Location = new System.Drawing.Point(219, 45);
            this.lblUni.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUni.Name = "lblUni";
            this.lblUni.Size = new System.Drawing.Size(203, 18);
            this.lblUni.TabIndex = 12;
            this.lblUni.Text = "Unidades";
            this.lblUni.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblObj
            // 
            this.lblObj.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObj.Location = new System.Drawing.Point(425, 45);
            this.lblObj.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblObj.Name = "lblObj";
            this.lblObj.Size = new System.Drawing.Size(203, 18);
            this.lblObj.TabIndex = 13;
            this.lblObj.Text = "Objetos";
            this.lblObj.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(680, 362);
            this.Controls.Add(this.pnlPieCover);
            this.Controls.Add(this.lblObj);
            this.Controls.Add(this.lblUni);
            this.Controls.Add(this.lblEq);
            this.Controls.Add(this.pieArchivos);
            this.Controls.Add(this.pieUnidades);
            this.Controls.Add(this.pieEquipos);
            this.Controls.Add(this.lblDetalle);
            this.Controls.Add(this.lblRuta);
            this.Controls.Add(this.lblUnidad);
            this.Controls.Add(this.lblEquipo);
            this.Controls.Add(this.lblFechaAct);
            this.Controls.Add(this.lblDetalleAccion);
            this.Controls.Add(this.lblAccion);
            this.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generar glosario de archivos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker wkrMain;
        private System.Windows.Forms.Label lblAccion;
        private System.Windows.Forms.Label lblFechaAct;
        private System.Windows.Forms.Label lblEquipo;
        private System.Windows.Forms.Label lblUnidad;
        private System.Windows.Forms.Label lblRuta;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.Label lblDetalleAccion;
        private System.Drawing.PieChart.PieChartControl pieEquipos;
        private System.Drawing.PieChart.PieChartControl pieUnidades;
        private System.Drawing.PieChart.PieChartControl pieArchivos;
        private System.Windows.Forms.Panel pnlPieCover;
        private System.Windows.Forms.Label lblEq;
        private System.Windows.Forms.Label lblUni;
        private System.Windows.Forms.Label lblObj;
    }
}

