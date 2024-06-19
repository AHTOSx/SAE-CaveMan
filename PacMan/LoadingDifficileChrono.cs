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
    public partial class LoadingDifficileChrono : Form
    {
        public LoadingDifficileChrono()
        {
            InitializeComponent();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.Value += 2;

                lblTime.Text = progressBar1.Value.ToString() + "%";
            }
            else
            {
                timer3.Stop();

                {

                }
                JeuDifficileChrono jeuFacileChronoForm = new JeuDifficileChrono(30, 30);
                jeuFacileChronoForm.Show();


                this.Hide(); // Cacher le formulaire de chargement
            }
        }

        private void LoadingDifficileChrono_Load(object sender, EventArgs e)
        {
            timer3.Start();
        }
    }
}
