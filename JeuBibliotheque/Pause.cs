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

namespace JeuBibliotheque
{

    public partial class Pause : Form
    {
        private JeuFacile parentForm;

        public Pause(JeuFacile parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;


        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);


        }

        private void btnReprendre_Click(object sender, EventArgs e)
        {
            parentForm.DemarrerMinuterie(); // Redémarrer la minuterie dans JeuFacile
            this.Close(); // Fermer le formulaire Pause
        }


    }
}
