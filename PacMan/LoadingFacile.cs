using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JeuBibliotheque;

namespace PacMan
{
    public partial class LoadingFacile : Form
    {
        public LoadingFacile()
        {
            InitializeComponent();
        }

        private void Loading_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(progressBar1.Value < 100)
            {
                progressBar1.Value += 2;

                lblTime.Text = progressBar1.Value.ToString() + "%";
            }
            else
            {
                timer1.Stop();
                
                {

                }
                JeuFacile jeuFacileForm = new JeuFacile(30,30);
                jeuFacileForm.Show();

                
                this.Hide(); // Cacher le formulaire de chargement
            }
        }
    }
}



