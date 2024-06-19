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
    public partial class LoadingDifficile : Form
    {
        public LoadingDifficile()
        {
            InitializeComponent();
        }

        private void LoadingDifficile_Load(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.Value += 2;

                lblTimeD.Text = progressBar1.Value.ToString() + "%";
            }
            else
            {
                timer2.Stop();

                {

                }
                JeuDifficile jeuDiffForm = new JeuDifficile(30, 30);
                jeuDiffForm.Show();


                this.Hide(); 
            }
        }
    }
}
