using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace tPanel
{
    public partial class tPanel : Panel
    {
        public tPanel()
        {
            InitializeComponent();
        }

        protected void TickHandler(object sender, EventArgs e)
        {
            this.InvalidateEx();
        }

        protected void InvalidateEx()
        {
            if (Parent == null)
            {
                return;
            }

            Rectangle rc = new Rectangle(this.Location, this.Size);

            Parent.Invalidate(rc, true);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x20;
                return cp;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(128, SystemColors.Control)), this.ClientRectangle);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
        }
    }
}
