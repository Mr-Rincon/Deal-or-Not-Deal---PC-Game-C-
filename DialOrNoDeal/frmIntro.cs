using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DialOrNoDeal
{
    public partial class frmIntro : Form
    {
        public frmIntro()
        {
            InitializeComponent();

            btnStart.MouseEnter += new System.EventHandler(this.btnStart_MouseEnter);

            btnStart.MouseLeave += new System.EventHandler(this.btnStart_MouseLeave);

            Bitmap imagen = new Bitmap(Application.StartupPath + @"\img\buttons\btnStart.png");
            btnStart.Image = imagen;
        }

        private void btnStart_MouseEnter(object sender, EventArgs e)
        {
            this.btnStart.BackColor = System.Drawing.Color.Transparent;
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            Bitmap imagen = new Bitmap(Application.StartupPath + @"\img\buttons\btnStartHover.png");
            btnStart.Image = imagen;
        }

        private void btnStart_MouseLeave(object sender, EventArgs e)
        {
            Bitmap imagen = new Bitmap(Application.StartupPath + @"\img\buttons\btnStart.png");
            btnStart.Image = imagen;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {            
            frmPlay frm = new frmPlay();
            frm.Show();

            this.Hide();
        }
    }
}
