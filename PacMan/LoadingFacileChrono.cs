using JeuBibliotheque;
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
    public partial class LoadingFacileChrono : Form
    {
        public LoadingFacileChrono()
        {
            InitializeComponent();
        }

        private void LoadingFacileChrono_Load(object sender, EventArgs e)
        {
            timer4.Start();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.Value += 2;

                lblTime.Text = progressBar1.Value.ToString() + "%";
            }
            else
            {
                timer4.Stop();

                {

                }
                JeuFacileChrono jeuFacileChronoForm = new JeuFacileChrono(30, 30);
                jeuFacileChronoForm.Show();


                this.Hide(); // Cacher le formulaire de chargement
            }
        }
    }
}
