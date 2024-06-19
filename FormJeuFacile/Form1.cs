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

            // Abonnez-vous à l'événement Load du formulaire
            this.Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Le formulaire est maintenant chargé, commencez le jeu ici

            // Créer une instance de JeuFacile avec les dimensions souhaitées
            jeuFacile = new JeuFacile(10, 10); // Exemple de dimensions, ajustez selon votre jeu

            // Ajouter JeuFacile à la collection de contrôles du formulaire principal
            this.Controls.Add(jeuFacile);

            // Optionnel : ajustez la taille et la position de jeuFacile dans MainForm
            jeuFacile.Dock = DockStyle.Fill; // Remplit MainForm avec JeuFacile
        }
    }
}
