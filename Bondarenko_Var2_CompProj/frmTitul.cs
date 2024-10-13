using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bondarenko_Var2_CompProj
{
    public partial class frmTitul : Form
    {
        public frmTitul()
        {
            InitializeComponent();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            frmMain frmMain = new frmMain();
            frmMain.StartPosition = FormStartPosition.CenterScreen;
            frmMain.ShowDialog();
        }

        private void label13_MouseLeave(object sender, EventArgs e)
        {
            label13.ForeColor = Color.Black;
        }

        private void label13_MouseHover(object sender, EventArgs e)
        {
            label13.ForeColor = Color.Orange;
        }
    }
}
