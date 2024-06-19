using System;
using System.Windows.Forms;
using JeuBibliotheque;

namespace VotreProjetWindowsForms
{
    public partial class MainForm : Form
    {
        private JeuFacile jeuFacile;

        public MainForm()
        {
            InitializeComponent();

            // Abonnez-vous � l'�v�nement Load du formulaire
            this.Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Le formulaire est maintenant charg�, commencez le jeu ici

            // Cr�er une instance de JeuFacile avec les dimensions souhait�es
            jeuFacile = new JeuFacile(10, 10); // Exemple de dimensions, ajustez selon votre jeu

            // Ajouter JeuFacile � la collection de contr�les du formulaire principal
            this.Controls.Add(jeuFacile);

            // Optionnel : ajustez la taille et la position de jeuFacile dans MainForm
            jeuFacile.Dock = DockStyle.Fill; // Remplit MainForm avec JeuFacile
        }
    }
}
