using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacMan
{
    public partial class Menu : Form
    {

     
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Menu());
        }
        public Menu()
        {
            InitializeComponent();
        }

        private void btnNouvellepartie_MouseEnter(object sender, EventArgs e)
        {
            btnNouvellepartie.ForeColor = Color.SandyBrown;
        }

        private void btnNouvellepartie_MouseLeave(object sender, EventArgs e)
        {
            btnNouvellepartie.ForeColor = Color.Black;
        }

        private void btnClassement_MouseEnter(object sender, EventArgs e)
        {
            btnClassement.ForeColor = Color.SandyBrown;
        }

        private void btnClassement_MouseLeave(object sender, EventArgs e)
        {
            btnClassement.ForeColor = Color.Black;
        }

        private void btnQuitter_MouseEnter(object sender, EventArgs e)
        {
            btnQuitter.ForeColor = Color.SandyBrown;
        }

        private void btnQuitter_MouseLeave(object sender, EventArgs e)
        {
            btnQuitter.ForeColor = Color.Black;
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnClassement_Click(object sender, EventArgs e)
        {
            Classement classement = new Classement();
            classement.Show();
            this.Hide();
        }

        private void btnNouvellepartie_Click(object sender, EventArgs e)
        {
            Pseudo pseudo = new Pseudo();
            pseudo.Show();
            this.Hide();
        }
    }
}
