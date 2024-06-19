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
    public partial class Difficulte : Form
    {
        public Difficulte()
        {
            InitializeComponent();
            btnradioVert1.Enabled = false;
          
            btnradioVert3.Enabled = false;
          
            btnradioVertChrono5.Enabled = false;
            btnradioVertChrono6.Enabled = false;
            btnradioVert1.Visible = false;
          
            btnradioVert3.Visible = false;
         
            btnradioVertChrono5.Visible = false;
            btnradioVertChrono6.Visible = false;

            btnJouerDifficile.Visible = false; // Ajoutez cette ligne pour initialement masquer btnJouer
            btnJouerDifficile.Enabled = false; // Ajoutez cette ligne pour initialement désactiver btnJouer
            btnJouerFacile.Visible = false;
            btnJouerFacile.Enabled = false;
            btnJouerFacileChrono.Visible = false;
            btnJouerFacileChrono.Enabled = false;
            btnJouerDifficileChrono.Enabled = false;
            btnJouerDifficileChrono.Visible=false;
        }

        private void Difficulte_Load(object sender, EventArgs e)
        {

        }

        private void btnretour_MouseEnter(object sender, EventArgs e)
        {
            btnretour.ForeColor = Color.SandyBrown;
        }

        private void btnretour_MouseLeave(object sender, EventArgs e)
        {
            btnretour.ForeColor = Color.Black;
        }

        private void btnretour_Click(object sender, EventArgs e)
        {
            Pseudo pseudo = new Pseudo();
            pseudo.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            btnradioVert1.Visible = true;
            btnradioVert1.Enabled = true;
         
            btnradioVert3.Visible = false;
         

            UpdatePlayButtonState();
        }

     

        private void btnradioGris3_Click(object sender, EventArgs e)
        {
            btnradioVert3.Visible = true;
            btnradioVert3.Enabled = true;
            btnradioVert1.Visible = false;
           

            UpdatePlayButtonState();
        }

      

        private void btnradioVert1_Click(object sender, EventArgs e)
        {
            btnradioVert1.Visible = false;
            UpdatePlayButtonState();
        }

     

        private void btnradioVert3_Click(object sender, EventArgs e)
        {
            btnradioVert3.Visible = false;
            UpdatePlayButtonState();
        }

      

        private void btnradioGris5_Click(object sender, EventArgs e)
        {
            btnradioVertChrono5.Visible = true;
            btnradioVertChrono5.Enabled = true;
            btnradioVertChrono6.Visible = false;

            UpdatePlayButtonState();
        }

        private void btnradioGris6_Click(object sender, EventArgs e)
        {
            btnradioVertChrono6.Visible = true;
            btnradioVertChrono6.Enabled = true;
            btnradioVertChrono5.Visible = false;

            UpdatePlayButtonState();
        }

        private void btnradioVert5_Click(object sender, EventArgs e)
        {
            btnradioVertChrono5.Visible = false;
            UpdatePlayButtonState();
        }

        private void btnradioVert6_Click(object sender, EventArgs e)
        {
            btnradioVertChrono6.Visible = false;
            UpdatePlayButtonState();
        }

        private void UpdatePlayButtonState()
        {
            bool vert1Selected = btnradioVert1.Visible && btnradioVert1.Enabled;
            bool vert3Selected = btnradioVert3.Visible && btnradioVert3.Enabled;
            bool vertChrono5Selected = btnradioVertChrono5.Visible && btnradioVertChrono5.Enabled;
            bool vertChrono6Selected = btnradioVertChrono6.Visible && btnradioVertChrono6.Enabled;

            // Afficher les boutons spécifiques selon les conditions
            if (vert3Selected && vertChrono6Selected)
            {
                btnJouerFacile.Visible = false;
                btnJouerFacile.Enabled = false;

                btnJouerFacileChrono.Visible = false;
                btnJouerFacileChrono.Enabled = false;

                btnJouerDifficile.Visible = true;
                btnJouerDifficile.Enabled = true;

                btnJouerDifficileChrono.Visible = false;
                btnJouerDifficileChrono.Enabled = false;
            }
            else
            {
                bool showJouerFacileChrono = vert1Selected && (vertChrono5Selected);
                bool showJouerDifficileChrono = vert3Selected && (vertChrono5Selected || vertChrono6Selected);

                // Afficher les boutons spécifiques aux chronomètres si les conditions sont remplies
                if (showJouerFacileChrono)
                {
                    btnJouerFacileChrono.Visible = true;
                    btnJouerFacileChrono.Enabled = true;

                    btnJouerDifficileChrono.Visible = false;
                    btnJouerDifficileChrono.Enabled = false;

                    // Cacher les autres boutons de jouer si nécessaire
                    btnJouerFacile.Visible = false;
                    btnJouerFacile.Enabled = false;

                    btnJouerDifficile.Visible = false;
                    btnJouerDifficile.Enabled = false;
                }
                else if (showJouerDifficileChrono)
                {
                    btnJouerDifficileChrono.Visible = true;
                    btnJouerDifficileChrono.Enabled = true;

                    btnJouerFacileChrono.Visible = false;
                    btnJouerFacileChrono.Enabled = false;

                    // Cacher les autres boutons de jouer si nécessaire
                    btnJouerFacile.Visible = false;
                    btnJouerFacile.Enabled = false;

                    btnJouerDifficile.Visible = false;
                    btnJouerDifficile.Enabled = false;
                }
                else
                {
                    // Par défaut, afficher les boutons normaux de jouer
                    btnJouerFacile.Visible = vert1Selected && (vertChrono5Selected || vertChrono6Selected);
                    btnJouerFacile.Enabled = vert1Selected && (vertChrono5Selected || vertChrono6Selected);

                    btnJouerDifficile.Visible = vert3Selected && (vertChrono5Selected || vertChrono6Selected);
                    btnJouerDifficile.Enabled = vert3Selected && (vertChrono5Selected || vertChrono6Selected);

                    // Cacher les boutons spécifiques aux chronomètres si les conditions ne sont pas remplies
                    btnJouerFacileChrono.Visible = false;
                    btnJouerFacileChrono.Enabled = false;

                    btnJouerDifficileChrono.Visible = false;
                    btnJouerDifficileChrono.Enabled = false;
                }
            }
        }







        private void btnJouer_MouseEnter(object sender, EventArgs e)
        {
            btnJouerDifficile.ForeColor = Color.SandyBrown;
        }

        private void btnJouer_MouseLeave(object sender, EventArgs e)
        {
            btnJouerDifficile.ForeColor= Color.Black;
        }

        private void btnJouer_Click(object sender, EventArgs e)
        {
            LoadingDifficile loading = new LoadingDifficile();
            loading.Show();
            this.Hide();
        }

        private void btnJoueurFacile_MouseEnter(object sender, EventArgs e)
        {
            btnJouerFacile.ForeColor = Color.SandyBrown;
        }

        private void btnJoueurFacile_MouseLeave(object sender, EventArgs e)
        {
            btnJouerFacile.ForeColor= Color.Black;
        }

        private void btnJouerFacile_Click(object sender, EventArgs e)
        {
            LoadingFacile loading = new LoadingFacile();
            loading.Show();
            this.Hide();
        }

        private void btnJouerDifficileChrono_MouseEnter(object sender, EventArgs e)
        {
            btnJouerDifficileChrono.ForeColor = Color.SandyBrown;
        }

        private void btnJouerDifficileChrono_MouseLeave(object sender, EventArgs e)
        {
            btnJouerDifficileChrono.ForeColor= Color.Black;
        }

        private void btnJouerFacileChrono_MouseEnter(object sender, EventArgs e)
        {
            btnJouerFacileChrono.ForeColor= Color.SandyBrown;
        }

        private void btnJouerFacileChrono_MouseLeave(object sender, EventArgs e)
        {
            btnJouerFacileChrono.ForeColor=Color.Black;
        }

        private void btnJouerFacileChrono_Click(object sender, EventArgs e)
        {
            LoadingFacileChrono loading = new LoadingFacileChrono();
            loading.Show();
            this.Hide();
        }

        private void btnJouerDifficileChrono_Click(object sender, EventArgs e)
        {
            LoadingDifficileChrono loading = new LoadingDifficileChrono();
            loading.Show();
            this.Hide();
        }
    }
}
