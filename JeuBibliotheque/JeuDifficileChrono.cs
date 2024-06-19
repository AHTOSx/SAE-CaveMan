using JeuBibliotheque.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace JeuBibliotheque
{
    public partial class JeuDifficileChrono : Form
    {

        // Déclaration du Timer pour le chronomètre
        private Timer chronometre;
        private int secondes = 0;
        private int minutes = 0;

        private const int tailleCase = 30;
        private int hauteurLabyrinthe;
        private int largeurLabyrinthe;
        private int decalageX = 550;
        private int decalageY = 50;
        private int[,] labyrinthe;
        private Timer minuterie;
        private List<Point> gigots;
        private List<Point> fantomes;
        private Point pacman;
        private Random aleatoire;
        private int score;
        private int vies;
        private List<Point> baies;
        private List<Point> kitsDeSoin;
        private Bitmap imagePacman;
        private Bitmap imageMur;
        private Bitmap imageSol;
        private Bitmap imageFantome;
        private Bitmap imageGigot;
        private Bitmap imageKitDeSoin;
        private Bitmap imageBaie;
        private Bitmap imageGourdin;
        private List<Point> gourdinPositions; // Pour stocker les positions des gourdins
        private bool aGourdin = false; // Indique si Pacman a ramassé un gourdin
        private Timer gourdinTimer;
        private int compteurDeplacementFantomes = 0;
        private const int vitesseFantomes = 3; // Nombre de tours de minuterie avant chaque déplacement des fantômes
        private Bitmap imagePacmanDroite;
        private Bitmap imagePacmanGauche;
        private Bitmap imagePacmanHaut;
        private Bitmap imagePacmanBas;
        private Image imagePacmanDroiteAvecGourdin;
        private Image imagePacmanGaucheAvecGourdin;
        private Image imagePacmanHautAvecGourdin;
        private Image imagePacmanBasAvecGourdin;
        private Image coeurPleinImage;
        private Image coeurVideImage;
        private PictureBox pictureBoxGameOver;

        private enum Direction { Haut, Bas, Gauche, Droite }
        private Direction directionActuelle;





        public class Node
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int G { get; set; } // Coût du chemin depuis le départ
            public int H { get; set; } // Heuristique (estimation du coût vers l'arrivée)
            public int F { get { return G + H; } } // Coût total F = G + H
            public Node Parent { get; set; } // Parent dans le chemin optimal

            public Node(int x, int y)
            {
                X = x;
                Y = y;
            }
        }





        public JeuDifficileChrono(int hauteur, int largeur)
        {
            this.hauteurLabyrinthe = hauteur;
            this.largeurLabyrinthe = largeur;

            this.Width = largeurLabyrinthe + decalageX * tailleCase;
            this.Height = hauteurLabyrinthe + decalageY * tailleCase;
            this.Text = "PacMan";
            this.DoubleBuffered = true;
            this.KeyDown += new KeyEventHandler(EnfoncerTouche);
            this.BackgroundImage = Resources.Screenshot_2024_04_14_151646;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            aleatoire = new Random();

            labyrinthe = GenererLabyrintheEnProfondeur(largeurLabyrinthe, hauteurLabyrinthe);

            fantomes = InitialiserFantomes();
            baies = InitialiserBaies();
            kitsDeSoin = InitialiserKitsDeSoin();
            gigots = InitialiserGigots();
            gourdinPositions = InitialiserGourdins(); // Initialiser les positions des gourdins
            pacman = new Point(1, 1); // Pacman commence en haut à gauche
            score = 0;
            vies = 3;
            aGourdin = false; // Initialiser à false

            gourdinTimer = new Timer();
            gourdinTimer.Interval = 10000; // 10 secondes
            gourdinTimer.Tick += new EventHandler(FinGourdin);

            minuterie = new Timer();
            minuterie.Interval = 100;
            minuterie.Tick += new EventHandler(MettreAJourJeu);
            minuterie.Start();



            // Chargement des images
            imagePacman = Resources.PersoBas_removebg_preview;
            imageMur = Resources.Mur;
            imageSol = Resources.Sol;
            imageFantome = Resources.Dino_Gris_removebg_preview;
            imageGigot = Resources.gigot_removebg_preview;
            imageKitDeSoin = Resources.Kit_de_soin_removebg_preview;
            imageBaie = Resources.bai_removebg_preview;
            imageGourdin = Resources.gourdin_removebg_preview;

            imagePacmanDroite = Resources.PersoDroite_removebg_preview;
            imagePacmanGauche = Resources.PersoGauche_removebg_preview;
            imagePacmanHaut = Resources.PersoHaut_removebg_preview;
            imagePacmanBas = Resources.PersoBas_removebg_preview;

            imagePacmanDroiteAvecGourdin = Resources.gourdinDroitev2_removebg_preview;
            imagePacmanGaucheAvecGourdin = Resources.gourdinGauchev2_removebg_preview;
            imagePacmanHautAvecGourdin = Resources.gourdinv3_removebg_preview_removebg_preview;
            imagePacmanBasAvecGourdin = Resources.gourdinBas_removebg_preview;

            coeurPleinImage = Resources.coeurrouge_removebg_preview;
            coeurVideImage = Resources.coeurblanc_removebg_preview;

            pictureBoxGameOver = new PictureBox();
            pictureBoxGameOver.Image = Resources.gameover; // Remplacez Resources.GameOverImage par votre image de Game Over
            pictureBoxGameOver.Size = new Size(700, 100); // Ajustez la taille selon vos besoins

            // Ajustez la position pour décaler la PictureBox vers la droite
            int xOffset = 30; // Décalage horizontal désiré
            pictureBoxGameOver.Location = new Point((this.ClientSize.Width - pictureBoxGameOver.Width) / 2 + xOffset, (this.ClientSize.Height - pictureBoxGameOver.Height) / 2);

            pictureBoxGameOver.Visible = false; // Démarre invisible
            pictureBoxGameOver.BackColor = Color.Transparent;
            pictureBoxGameOver.SizeMode = PictureBoxSizeMode.Zoom;

            this.Controls.Add(pictureBoxGameOver);

            // Initialisation du Timer pour le chronomètre
            chronometre = new Timer();
            chronometre.Interval = 1000; // Interval d'une seconde
            chronometre.Tick += new EventHandler(Chronometre_Tick);
            chronometre.Start();


        }

        // Gestionnaire d'événement pour le Tick du Timer (Chronomètre)
        private void Chronometre_Tick(object sender, EventArgs e)
        {
            secondes++;

            if (secondes == 60)
            {
                secondes = 0;
                minutes++;
            }

            // Vérifier si le joueur a perdu toutes ses vies
            if (vies == 0)
            {
                // Arrêter le Timer du chronomètre
                chronometre.Stop();
            }

            // Mettre à jour l'interface utilisateur pour afficher le chronomètre
            // Vous pouvez redessiner la zone du chronomètre à chaque Tick
            Invalidate();
        }




        private Point InitialiserFantome()
        {
            Point nouvellePosition;

            do
            {
                int x = aleatoire.Next(1, largeurLabyrinthe - 1);
                int y = aleatoire.Next(1, hauteurLabyrinthe - 1);
                nouvellePosition = new Point(x, y);
            }
            while (labyrinthe[nouvellePosition.Y, nouvellePosition.X] != 0 || EstPositionInitialePacman(nouvellePosition));

            return nouvellePosition;
        }



        private void MettreAJourJeu(object sender, EventArgs e)
        {
            compteurDeplacementFantomes++;
            if (compteurDeplacementFantomes >= vitesseFantomes)
            {
                DeplacerFantomes();
                compteurDeplacementFantomes = 0; // Réinitialisation du compteur après chaque déplacement
            }
            VerifierCollisions();
            this.Invalidate();
        }


        private List<Point> TrouverChemin(Point depart, Point arrivee)
        {
            List<Node> listeOuverte = new List<Node>();
            List<Node> listeFermee = new List<Node>();

            Node noeudDepart = new Node(depart.X, depart.Y);
            Node noeudArrivee = new Node(arrivee.X, arrivee.Y);

            listeOuverte.Add(noeudDepart);

            while (listeOuverte.Count > 0)
            {
                Node noeudActuel = listeOuverte.OrderBy(n => n.F).First();

                if (noeudActuel.X == noeudArrivee.X && noeudActuel.Y == noeudArrivee.Y)
                {
                    // Construire et retourner le chemin trouvé
                    List<Point> chemin = new List<Point>();
                    Node noeud = noeudActuel;
                    while (noeud != null)
                    {
                        chemin.Add(new Point(noeud.X, noeud.Y));
                        noeud = noeud.Parent;
                    }
                    chemin.Reverse();
                    return chemin;
                }

                listeOuverte.Remove(noeudActuel);
                listeFermee.Add(noeudActuel);

                List<Node> voisins = ObtenirVoisins(noeudActuel, noeudArrivee);
                foreach (Node voisin in voisins)
                {
                    if (listeFermee.Any(n => n.X == voisin.X && n.Y == voisin.Y))
                        continue;

                    int tentativeG = noeudActuel.G + 1; // Coût de mouvement (1 dans ce cas)

                    if (!listeOuverte.Any(n => n.X == voisin.X && n.Y == voisin.Y) || tentativeG < voisin.G)
                    {
                        voisin.G = tentativeG;
                        voisin.H = Math.Abs(voisin.X - noeudArrivee.X) + Math.Abs(voisin.Y - noeudArrivee.Y);
                        voisin.Parent = noeudActuel;

                        if (!listeOuverte.Any(n => n.X == voisin.X && n.Y == voisin.Y))
                            listeOuverte.Add(voisin);
                    }
                }
            }

            return null; // Aucun chemin trouvé
        }


        private List<Node> ObtenirVoisins(Node noeud, Node noeudFinal)
        {
            List<Node> voisins = new List<Node>();

            // Définition des directions (gauche, droite, haut, bas)
            Point[] directions = new Point[] {
        new Point(-1, 0), // Gauche
        new Point(1, 0),  // Droite
        new Point(0, -1), // Haut
        new Point(0, 1)   // Bas
    };

            foreach (Point direction in directions)
            {
                int nouveauX = noeud.X + direction.X;
                int nouveauY = noeud.Y + direction.Y;

                // Vérifier si le voisin est dans la grille et accessible
                if (EstDansLeLabyrinthe(new Point(nouveauX, nouveauY)) && labyrinthe[nouveauY, nouveauX] != 1)
                {
                    Node noeudVoisin = new Node(nouveauX, nouveauY);
                    voisins.Add(noeudVoisin);
                }
            }

            return voisins;
        }





        private void DeplacerFantomes()
        {
            for (int i = 0; i < fantomes.Count; i++)
            {
                Point depart = new Point(fantomes[i].X, fantomes[i].Y);
                Point arrivee = pacman;

                // Utilisez la méthode TrouverChemin pour obtenir le chemin optimal
                List<Point> chemin = TrouverChemin(depart, arrivee);

                if (chemin != null && chemin.Count > 1)
                {
                    Point nouvellePositionFantome = chemin[1]; // La prochaine position dans le chemin est la deuxième dans la liste (index 1)

                    // Mettre à jour la position du fantôme dans la liste fantomes
                    fantomes[i] = nouvellePositionFantome;
                }
            }
        }




        private void EnfoncerTouche(object sender, KeyEventArgs e)
        {
            Point nouvellePositionPacman = pacman;

            switch (e.KeyCode)
            {
                case Keys.Left:
                    nouvellePositionPacman = new Point(pacman.X - 1, pacman.Y);
                    directionActuelle = Direction.Gauche; // Mettre à jour la direction actuelle
                    break;
                case Keys.Right:
                    nouvellePositionPacman = new Point(pacman.X + 1, pacman.Y);
                    directionActuelle = Direction.Droite; // Mettre à jour la direction actuelle
                    break;
                case Keys.Up:
                    nouvellePositionPacman = new Point(pacman.X, pacman.Y - 1);
                    directionActuelle = Direction.Haut; // Mettre à jour la direction actuelle
                    break;
                case Keys.Down:
                    nouvellePositionPacman = new Point(pacman.X, pacman.Y + 1);
                    directionActuelle = Direction.Bas; // Mettre à jour la direction actuelle
                    break;
                case Keys.Escape:
                    PauseDifficileChrono Pause = new PauseDifficileChrono(this);
                    Pause.Show();
                    minuterie.Stop();
                    chronometre.Stop();
                    break;
            }

            if (EstDansLeLabyrinthe(nouvellePositionPacman) && labyrinthe[nouvellePositionPacman.Y, nouvellePositionPacman.X] != 1)
            {
                pacman = nouvellePositionPacman;
            }

            MettreAJourImagePacman(); // Mettre à jour l'image de Pacman en fonction de la direction et de l'état du gourdin
        }

        public void DemarrerMinuterie()
        {
            minuterie.Start();
        }

        public void DemarrerChronometre()
        {
            chronometre.Start();
        }

        private void MettreAJourImagePacman()
        {
            if (aGourdin)
            {
                switch (directionActuelle)
                {
                    case Direction.Gauche:
                        imagePacman = (Bitmap)imagePacmanGaucheAvecGourdin;
                        break;
                    case Direction.Droite:
                        imagePacman = (Bitmap)imagePacmanDroiteAvecGourdin;
                        break;
                    case Direction.Haut:
                        imagePacman = (Bitmap)imagePacmanHautAvecGourdin;
                        break;
                    case Direction.Bas:
                        imagePacman = (Bitmap)imagePacmanBasAvecGourdin;
                        break;
                }
            }
            else
            {
                switch (directionActuelle)
                {
                    case Direction.Gauche:
                        imagePacman = imagePacmanGauche;
                        break;
                    case Direction.Droite:
                        imagePacman = imagePacmanDroite;
                        break;
                    case Direction.Haut:
                        imagePacman = imagePacmanHaut;
                        break;
                    case Direction.Bas:
                        imagePacman = imagePacmanBas;
                        break;
                }
            }
        }

        private bool EstDansLeLabyrinthe(Point p)
        {
            return p.X >= 0 && p.X < largeurLabyrinthe && p.Y >= 0 && p.Y < hauteurLabyrinthe;
        }

        private void VerifierCollisions()
        {
            // Vérifier collision avec les gourdins
            for (int i = 0; i < gourdinPositions.Count; i++)
            {
                if (gourdinPositions[i] == pacman)
                {
                    if (!aGourdin)
                    {
                        aGourdin = true; // Pacman ramasse un gourdin
                        gourdinPositions.RemoveAt(i);
                        gourdinTimer.Start(); // Démarrer le timer pour 5 secondes
                        MettreAJourImagePacman(); // Mettre à jour l'image de Pacman immédiatement après avoir ramassé le gourdin
                    }
                    break;
                }
            }

            // Vérifier collision avec les fantômes
            for (int i = 0; i < fantomes.Count; i++)
            {
                if (fantomes[i] == pacman)
                {
                    if (aGourdin)
                    {
                        // Si Pacman a un gourdin, réinitialiser le fantôme à sa position initiale
                        Point nouvellePosition = InitialiserFantome();
                        fantomes[i] = nouvellePosition;
                        score += 1000;

                    }
                    else
                    {
                        // Si Pacman n'a pas de gourdin, réinitialiser Pacman et non tous les fantômes
                        vies--;
                        if (vies <= 0)
                        {
                            minuterie.Stop();
                            AfficherGameOver();
                            FermerApplicationApresDelai();
                        }
                        pacman = new Point(1, 1); // Réinitialisation de Pacman en haut à gauche
                                                  // Ne pas réinitialiser tous les fantômes ici
                    }
                }
            }

            // Vérifier collision avec les gigots
            for (int i = 0; i < gigots.Count; i++)
            {
                if (gigots[i] == pacman)
                {
                    score += 10;
                    gigots.RemoveAt(i);
                    break;
                }
            }

            // Vérifier collision avec les baies
            for (int i = 0; i < baies.Count; i++)
            {
                if (baies[i] == pacman)
                {
                    score += 250;
                    baies.RemoveAt(i);
                    break;
                }
            }

            if (baies.Count == 0 && gigots.Count == 0)
            {
                ReinitialiserJeu(); // Réinitialiser le jeu si toutes les baies et gigots sont récupérés
            }
            // Vérifier collision avec les kits de soin
            for (int i = 0; i < kitsDeSoin.Count; i++)
            {
                if (kitsDeSoin[i] == pacman)
                {
                    if (vies < 3) // Limiter à 3 vies maximum
                    {
                        vies++;
                        kitsDeSoin.RemoveAt(i); // Ramasser le kit de soin
                    }
                    break;
                }
            }
        }
        private void FermerApplicationApresDelai()
        {
            Task.Delay(5000).Wait(); // Attendre 5 secondes de manière synchrone
            Application.Exit(); // Fermer l'application
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            // Dessiner le labyrinthe (murs et sol)
            for (int y = 0; y < hauteurLabyrinthe; y++)
            {
                for (int x = 0; x < largeurLabyrinthe; x++)
                {
                    if (labyrinthe[y, x] == 1)
                    {
                        g.DrawImage(imageMur, decalageX + x * tailleCase, decalageY + y * tailleCase, tailleCase, tailleCase);
                    }
                }
            }

            // Dessiner le sol
            for (int y = 0; y < hauteurLabyrinthe - 1; y++)
            {
                for (int x = 0; x < largeurLabyrinthe - 1; x++)
                {
                    if (labyrinthe[y, x] == 0)
                    {
                        g.DrawImage(imageSol, decalageX + x * tailleCase, decalageY + y * tailleCase, tailleCase, tailleCase);
                    }
                }
            }

            // Dessiner les gigots
            double tailleGigot = tailleCase / 1.8;
            foreach (var gigot in gigots)
            {
                g.DrawImage(imageGigot, decalageX + gigot.X * tailleCase + (tailleCase - (int)tailleGigot) / 2, decalageY + gigot.Y * tailleCase + (tailleCase - (int)tailleGigot) / 2, (int)tailleGigot, (int)tailleGigot);
            }

            // Dessiner les baies
            double tailleBaie = tailleCase / 1.2;
            foreach (var baie in baies)
            {
                g.DrawImage(imageBaie, decalageX + baie.X * tailleCase + (tailleCase - (int)tailleBaie) / 2, decalageY + baie.Y * tailleCase + (tailleCase - (int)tailleBaie) / 2, (int)tailleBaie, (int)tailleBaie);
            }

            // Dessiner les kits de soin
            double tailleKitDeSoin = tailleCase / 1.5;
            foreach (var kit in kitsDeSoin)
            {
                g.DrawImage(imageKitDeSoin, decalageX + kit.X * tailleCase + (tailleCase - (int)tailleKitDeSoin) / 2, decalageY + kit.Y * tailleCase + (tailleCase - (int)tailleKitDeSoin) / 2, (int)tailleKitDeSoin, (int)tailleKitDeSoin);
            }

            // Dessiner les gourdins
            double tailleGourdin = tailleCase / 1.2;
            foreach (var gourdin in gourdinPositions)
            {
                g.DrawImage(imageGourdin, decalageX + gourdin.X * tailleCase + (tailleCase - (int)tailleGourdin) / 2, decalageY + gourdin.Y * tailleCase + (tailleCase - (int)tailleGourdin) / 2, (int)tailleGourdin, (int)tailleGourdin);
            }

            // Dessiner Pacman
            g.DrawImage(imagePacman, decalageX + pacman.X * tailleCase, decalageY + pacman.Y * tailleCase, tailleCase, tailleCase);

            // Dessiner les fantômes
            foreach (var fantome in fantomes)
            {
                g.DrawImage(imageFantome, decalageX + fantome.X * tailleCase, decalageY + fantome.Y * tailleCase, tailleCase, tailleCase);
            }

            int coeurWidth = coeurPleinImage.Width / 2; // Largeur ajustée pour des cœurs plus petits
            int coeurHeight = coeurPleinImage.Height / 2; // Hauteur ajustée pour des cœurs plus petits
            int espaceEntreCoeurs = 5; // Espace entre chaque cœur

            // Position des cœurs
            int xCoeur = espaceEntreCoeurs;
            int yCoeur = hauteurLabyrinthe * tailleCase + 10; // Juste en dessous de la zone de jeu

            for (int i = 0; i < 3; i++)
            {
                if (i < vies)
                {
                    // Dessiner le cœur plein
                    g.DrawImage(coeurPleinImage, decalageX + 330 + xCoeur, (decalageY - 10) + yCoeur, coeurWidth, coeurHeight);
                }
                else
                {
                    // Dessiner le cœur vide
                    g.DrawImage(coeurVideImage, decalageX + 330 + xCoeur, (decalageY - 10) + yCoeur, coeurWidth, coeurHeight);
                }

                // Déplacer la position x pour le prochain cœur
                xCoeur += coeurWidth + espaceEntreCoeurs;
            }

            // Dessiner le chronomètre
            string temps = $"{minutes:D2}:{secondes:D2}";
            g.DrawString($"Temps: {temps}", new Font("Arial", 20), Brushes.White, new PointF(decalageX + 10, decalageY + hauteurLabyrinthe * tailleCase + 20));


            // Afficher le score et les vies
            g.DrawString($"Score: {score}", new Font("Arial", 20), Brushes.White, new PointF(decalageX + 10, decalageY + hauteurLabyrinthe * tailleCase + -10));
            g.DrawString($"Gourdin: {(aGourdin ? "Oui" : "Non")}", new Font("Arial", 20), Brushes.White, new PointF(decalageX + 700, decalageY + hauteurLabyrinthe * tailleCase + 10));
        }

        private int[,] GenererLabyrintheEnProfondeur(int largeur, int hauteur)
        {
            int[,] labyrinthe = new int[hauteur, largeur];

            // Initialisation du labyrinthe avec tous les murs
            for (int y = 0; y < hauteur; y++)
            {
                for (int x = 0; x < largeur; x++)
                {
                    labyrinthe[y, x] = 1;
                }
            }

            GenererLabyrinthe(1, 1, labyrinthe, largeur, hauteur);

            // Enlever la bordure en bas et à droite
            for (int y = 0; y < hauteur; y++)
            {
                labyrinthe[y, largeur - 1] = 0; // Enlever la bordure à droite
            }
            for (int x = 0; x < largeur; x++)
            {
                labyrinthe[hauteur - 1, x] = 0; // Enlever la bordure en bas
            }

            return labyrinthe;
        }

        private void GenererLabyrinthe(int x, int y, int[,] labyrinthe, int largeur, int hauteur)
        {
            labyrinthe[y, x] = 0; // La cellule actuelle devient un espace vide

            int[] directions = { 0, 1, 2, 3 };
            for (int i = 0; i < directions.Length; i++)
            {
                int temp = directions[i];
                int randomIndex = aleatoire.Next(i, directions.Length); // Sélection aléatoire d'une direction
                directions[i] = directions[randomIndex];
                directions[randomIndex] = temp;
            }

            foreach (int direction in directions)
            {
                int nextX = x, nextY = y;
                switch (direction)
                {
                    case 0: nextY -= 2; break; // Haut
                    case 1: nextY += 2; break; // Bas
                    case 2: nextX -= 2; break; // Gauche
                    case 3: nextX += 2; break; // Droite
                }

                if (nextX > 0 && nextX < largeur - 1 && nextY > 0 && nextY < hauteur - 1 && labyrinthe[nextY, nextX] == 1)
                {
                    labyrinthe[nextY, nextX] = 0; // La cellule suivante devient un espace vide
                    labyrinthe[(nextY + y) / 2, (nextX + x) / 2] = 0; // La cellule entre les deux devient un espace vide également

                    GenererLabyrinthe(nextX, nextY, labyrinthe, largeur, hauteur); // Appel récursif pour générer le reste du labyrinthe à partir de la nouvelle position
                }
            }
        }

        private List<Point> InitialiserFantomes()
        {
            List<Point> fantomesInitiaux = new List<Point>();

            while (fantomesInitiaux.Count < 4)
            {
                int x = aleatoire.Next(1, largeurLabyrinthe - 1);
                int y = aleatoire.Next(1, hauteurLabyrinthe - 1);
                if (labyrinthe[y, x] == 0 && (x != 1 || y != 1)) // Ne pas démarrer à la position de Pacman
                {
                    fantomesInitiaux.Add(new Point(x, y));
                }
            }

            return fantomesInitiaux;
        }

        private List<Point> InitialiserGigots()
        {
            List<Point> gigotsInitiaux = new List<Point>();

            for (int y = 1; y < hauteurLabyrinthe - 1; y++)
            {
                for (int x = 1; x < largeurLabyrinthe - 1; x++)
                {
                    Point position = new Point(x, y);
                    if (labyrinthe[y, x] == 0 &&
                        !EstPositionInitialePacman(position) &&
                        !EstPositionOccupee(position))
                    {
                        gigotsInitiaux.Add(position);
                    }
                }
            }

            return gigotsInitiaux;
        }

        private bool EstPositionOccupee(Point position)
        {
            // Vérifie si la position est occupée par une baie ou un kit de soin
            foreach (var baie in baies)
            {
                if (baie == position)
                {
                    return true;
                }
            }

            foreach (var kit in kitsDeSoin)
            {
                if (kit == position)
                {
                    return true;
                }
            }

            return false;
        }

        private List<Point> InitialiserBaies()
        {
            List<Point> baiesInitiales = new List<Point>();

            for (int y = 1; y < hauteurLabyrinthe - 1; y++)
            {
                for (int x = 1; x < largeurLabyrinthe - 1; x++)
                {
                    Point position = new Point(x, y);
                    if (labyrinthe[y, x] == 0 && !EstPositionInitialePacman(position) && aleatoire.Next(100) < 2.5) // 2.5% de chance
                    {
                        baiesInitiales.Add(position);
                    }
                }
            }

            return baiesInitiales;
        }

        private List<Point> InitialiserKitsDeSoin()
        {
            List<Point> kitsInitiaux = new List<Point>();

            for (int y = 1; y < hauteurLabyrinthe - 1; y++)
            {
                for (int x = 1; x < largeurLabyrinthe - 1; x++)
                {
                    Point position = new Point(x, y);
                    if (labyrinthe[y, x] == 0 && !EstPositionInitialePacman(position) && aleatoire.Next(100) < 1) // 1% de chance pour le kit de soin
                    {
                        kitsInitiaux.Add(position);
                    }
                }
            }

            return kitsInitiaux;
        }

        private List<Point> InitialiserGourdins()
        {
            List<Point> gourdinPositions = new List<Point>();
            int nombreDeGourdins = 4;

            for (int i = 0; i < nombreDeGourdins; i++)
            {
                Point position;
                do
                {
                    int x = aleatoire.Next(1, largeurLabyrinthe - 1);
                    int y = aleatoire.Next(1, hauteurLabyrinthe - 1);
                    position = new Point(x, y);
                }
                while (labyrinthe[position.Y, position.X] != 0 || gourdinPositions.Contains(position));

                // Supprimer les autres éléments à cette position
                gigots.RemoveAll(g => g == position);
                baies.RemoveAll(b => b == position);
                kitsDeSoin.RemoveAll(k => k == position);

                gourdinPositions.Add(position);
            }

            return gourdinPositions;
        }


        private void FinGourdin(object sender, EventArgs e)
        {
            aGourdin = false;
            gourdinTimer.Stop();
            MettreAJourImagePacman(); // Mettre à jour l'image de Pacman après la fin du gourdin
        }


        private bool EstPositionInitialePacman(Point position)
        {
            return position.X == 1 && position.Y == 1;
        }

        private void ReinitialiserJeu()
        {
            // Réinitialisation des valeurs
            baies = InitialiserBaies();
            gigots = InitialiserGigots();
            kitsDeSoin = InitialiserKitsDeSoin();
            gourdinPositions = InitialiserGourdins();
            pacman = new Point(1, 1);
            aGourdin = false;
            vies = 3;
        }

        private void AfficherGameOver()
        {
            pictureBoxGameOver.Visible = true;
        }

        private void InitializeComponent()
        {
            this.pictureBoxGameOver = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGameOver)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxGameOver
            // 
            this.pictureBoxGameOver.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxGameOver.Name = "pictureBoxGameOver";
            this.pictureBoxGameOver.Size = new System.Drawing.Size(100, 50);
            this.pictureBoxGameOver.TabIndex = 0;
            this.pictureBoxGameOver.TabStop = false;
            // 
            // JeuDifficileChrono
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.pictureBoxGameOver);
            this.DoubleBuffered = true;
            this.Name = "JeuDifficileChrono";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGameOver)).EndInit();
            this.ResumeLayout(false);

        }
    }
}