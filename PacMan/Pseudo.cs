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
    public partial class Pseudo : Form
    {
        public Pseudo()
        {
            InitializeComponent();
            btnchangerdepseudo.Visible = false;
            btnSuivant.Visible = false;
            btnSuivant.Enabled = false;
        }

        private void btnretour_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show(this);
            this.Hide();
        }

        private void btnretour_MouseEnter(object sender, EventArgs e)
        {
            btnretour.ForeColor = Color.SandyBrown;
        }

        private void btnretour_MouseLeave(object sender, EventArgs e)
        {
            btnretour.ForeColor = Color.Black;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            btnValiderPseudo.ForeColor = Color.SandyBrown;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            btnValiderPseudo.ForeColor = Color.Black;
        }

        private void btnValiderPseudo_Click(object sender, EventArgs e)
        {

            string pseudo = txtboxPseudo.Text.Trim(); // Supprime les espaces en début et en fin de chaîne

            if (string.IsNullOrWhiteSpace(pseudo))
            {
                MessageBox.Show("Veuillez entrer un pseudo avant de continuer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (pseudo.Length < 3)
            {
                MessageBox.Show("Le pseudo doit contenir au moins 3 lettres.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                txtboxPseudo.Visible = false;
                lblPseudo.Text = "Bienvenue " + pseudo + " \nappuie sur le bouton 'Suivant' \npour commencer !";
                lblPseudo.ForeColor = Color.SandyBrown;
                btnValiderPseudo.Visible = false;
                btnValiderPseudo.Enabled = false;
                btnchangerdepseudo.Visible = true;
                btnSuivant.Visible = true;
                btnSuivant.Enabled = true;
            }

        }

       


        private void button1_MouseEnter_1(object sender, EventArgs e)
        {
            btnchangerdepseudo.ForeColor = Color.SandyBrown;
        }

        private void button1_MouseLeave_1(object sender, EventArgs e)
        {
            btnchangerdepseudo.ForeColor= Color.Black;
        }

        private void btnchangerdepseudo_Click(object sender, EventArgs e)
        {
            btnchangerdepseudo.Visible= false;
            txtboxPseudo.Visible= true;
            lblPseudo.Text = "Pseudo :";
            lblPseudo.ForeColor= Color.Black;
            btnValiderPseudo.Text = "Valider mon pseudo";
            txtboxPseudo.Text = "";
        }

        private void btnSuivant_MouseEnter(object sender, EventArgs e)
        {
            btnSuivant.ForeColor = Color.SandyBrown;
        }

        private void btnSuivant_MouseLeave(object sender, EventArgs e)
        {
            btnSuivant.ForeColor= Color.Black;
        }

        private void btnSuivant_Click(object sender, EventArgs e)
        {
            Difficulte difficulte = new Difficulte();
            difficulte.Show();
            this.Hide();
        }
    }
}
