using JeuFacile.Properties;
using PacMan.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

public class JeuFacile : Form
{
    private const int tailleCase = 30;
    private int hauteurLabyrinthe;
    private int largeurLabyrinthe;
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
    private bool aGourdin = false; // Indique si Pacman a ramass� un gourdin
    private Timer gourdinTimer;
    private int compteurDeplacementFantomes = 0;
    private const int vitesseFantomes = 2; // Nombre de tours de minuterie avant chaque d�placement des fant�mes
    private Bitmap imagePacmanDroite;
    private Bitmap imagePacmanGauche;
    private Bitmap imagePacmanHaut;
    private Bitmap imagePacmanBas;
    private Image imagePacmanDroiteAvecGourdin;
    private Image imagePacmanGaucheAvecGourdin;
    private Image imagePacmanHautAvecGourdin;
    private Image imagePacmanBasAvecGourdin;
    private enum Direction { Haut, Bas, Gauche, Droite }
    private Direction directionActuelle;
    private List<Point> fantomesTues;

    private Dictionary<Point, DateTime> tempsFantomeTue = new Dictionary<Point, DateTime>();
    private const int delaiReapparitionFantome = 5000;
    private bool jeuTermine = false;





    public JeuFacile(int hauteur, int largeur)
    {
        this.hauteurLabyrinthe = hauteur;
        this.largeurLabyrinthe = largeur;

        this.Width = largeurLabyrinthe * tailleCase + 40;
        this.Height = hauteurLabyrinthe * tailleCase + 80;
        this.Text = "PacMan";
        this.DoubleBuffered = true;
        this.BackColor = Color.Black;
        this.KeyDown += new KeyEventHandler(EnfoncerTouche);

        aleatoire = new Random();

        labyrinthe = GenererLabyrintheEnProfondeur(largeurLabyrinthe, hauteurLabyrinthe);

        fantomes = InitialiserFantomes();
        baies = InitialiserBaies();
        kitsDeSoin = InitialiserKitsDeSoin();
        gigots = InitialiserGigots();
        gourdinPositions = InitialiserGourdins(); // Initialiser les positions des gourdins
        pacman = new Point(1, 1); // Pacman commence en haut � gauche
        score = 0;
        vies = 3;
        aGourdin = false; // Initialiser � false

        gourdinTimer = new Timer();
        gourdinTimer.Interval = 10000; // 5 secondes
        gourdinTimer.Tick += new EventHandler(FinGourdin);

        minuterie = new Timer();
        minuterie.Interval = 100;
        minuterie.Tick += new EventHandler(MettreAJourJeu);
        minuterie.Start();

        // Chargement des images
        imagePacman = Resources.PersoBas_removebg_preview;
        imageMur = Resources.Mur;
        imageSol = Resources.Sol;
        imageFantome = Resources.Dino_Gris;
        imageGigot = Resources.gigot_removebg_preview;
        imageKitDeSoin = Resources.Kit;
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

        fantomesTues = new List<Point>();
        tempsFantomeTue = new Dictionary<Point, DateTime>();


    }

    private void MettreAJourJeu(object sender, EventArgs e)
    {
        compteurDeplacementFantomes++;
        if (compteurDeplacementFantomes >= vitesseFantomes)
        {
            DeplacerFantomes();
            compteurDeplacementFantomes = 0; // R�initialisation du compteur apr�s chaque d�placement
        }
        VerifierCollisions();
        this.Invalidate();

        foreach (var fantomeTue in fantomesTues.ToList())
        {
            // V�rifier le d�lai �coul� pour chaque fant�me tu�
            if ((DateTime.Now - tempsFantomeTue[fantomeTue]).TotalMilliseconds >= delaiReapparitionFantome)
            {
                // R�initialiser le fant�me � sa position initiale
                fantomes.Add(fantomeTue);
                tempsFantomeTue.Remove(fantomeTue);
                fantomesTues.Remove(fantomeTue);
            }
        }

        // V�rifier si tous les gigots et baies ont �t� ramass�s
        if (gigots.Count == 0 && baies.Count == 0)
        {
            ReinitialiserPartie(); // Appeler la m�thode pour r�initialiser la partie
        }

        this.Invalidate();
    }



    private void DeplacerFantomes()
    {
        Point[] directions = new Point[] {
        new Point(-1, 0), // Gauche
        new Point(1, 0),  // Droite
        new Point(0, -1), // Haut
        new Point(0, 1)   // Bas
    };

        for (int i = 0; i < fantomes.Count; i++)
        {
            Point nouvellePositionFantome;
            do
            {
                Point direction = directions[aleatoire.Next(directions.Length)];
                nouvellePositionFantome = new Point(fantomes[i].X + direction.X, fantomes[i].Y + direction.Y);
            } while (!EstDansLeLabyrinthe(nouvellePositionFantome) || labyrinthe[nouvellePositionFantome.Y, nouvellePositionFantome.X] == 1);

            fantomes[i] = nouvellePositionFantome;

        }

    }

    private void EnfoncerTouche(object sender, KeyEventArgs e)
    {
        Point nouvellePositionPacman = pacman;

        switch (e.KeyCode)
        {
            case Keys.Left:
                nouvellePositionPacman = new Point(pacman.X - 1, pacman.Y);
                directionActuelle = Direction.Gauche; // Mettre � jour la direction actuelle
                break;
            case Keys.Right:
                nouvellePositionPacman = new Point(pacman.X + 1, pacman.Y);
                directionActuelle = Direction.Droite; // Mettre � jour la direction actuelle
                break;
            case Keys.Up:
                nouvellePositionPacman = new Point(pacman.X, pacman.Y - 1);
                directionActuelle = Direction.Haut; // Mettre � jour la direction actuelle
                break;
            case Keys.Down:
                nouvellePositionPacman = new Point(pacman.X, pacman.Y + 1);
                directionActuelle = Direction.Bas; // Mettre � jour la direction actuelle
                break;
        }

        if (EstDansLeLabyrinthe(nouvellePositionPacman) && labyrinthe[nouvellePositionPacman.Y, nouvellePositionPacman.X] != 1)
        {
            pacman = nouvellePositionPacman;
        }

        MettreAJourImagePacman(); // Mettre � jour l'image de Pacman en fonction de la direction et de l'�tat du gourdin
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
        // V�rifier collision avec les gourdins
        for (int i = 0; i < gourdinPositions.Count; i++)
        {
            if (gourdinPositions[i] == pacman)
            {
                if (!aGourdin)
                {
                    aGourdin = true; // Pacman ramasse un gourdin
                    gourdinPositions.RemoveAt(i);
                    gourdinTimer.Start(); // D�marrer le timer pour 5 secondes
                    MettreAJourImagePacman(); // Mettre � jour l'image de Pacman imm�diatement apr�s avoir ramass� le gourdin
                }
                break;
            }
        }

        // V�rifier collision avec les fant�mes
        for (int i = 0; i < fantomes.Count; i++)
        {
            if (fantomes[i] == pacman)
            {
                if (aGourdin)
                {
                    score += 1000; // Ajouter 1000 points si Pacman a un gourdin
                                   // Ajouter le fant�me tu� � la liste
                    fantomesTues.Add(fantomes[i]);
                    tempsFantomeTue[fantomes[i]] = DateTime.Now; // Enregistrer le temps actuel
                    fantomes.RemoveAt(i); // Supprimer le fant�me touch�
                    i--; // Ajuster l'indice apr�s suppression
                }
                else
                {
                    // Perdre une vie si Pacman n'a pas de gourdin
                    vies--;
                    if (vies <= 0)
                    {
                        FinDeJeu(); // Appeler la m�thode pour g�rer la fin de jeu
                        return; // Sortir de la m�thode car le jeu est termin�
                    }
                    else
                    {
                        // R�initialiser la position de Pacman apr�s la collision
                        pacman = new Point(1, 1); // Position de d�part
                    }
                }
            }
        }

        // V�rifier collision avec les gigots
        for (int i = 0; i < gigots.Count; i++)
        {
            if (gigots[i] == pacman)
            {
                score += 10;
                gigots.RemoveAt(i);
                if (gigots.Count == 0 && baies.Count == 0)
                {
                    ReinitialiserPartie(); // R�initialiser si tous les gigots et baies ont �t� collect�s
                }
                break;
            }
        }

        // V�rifier collision avec les baies
        for (int i = 0; i < baies.Count; i++)
        {
            if (baies[i] == pacman)
            {
                score += 250;
                baies.RemoveAt(i);
                if (gigots.Count == 0 && baies.Count == 0)
                {
                    ReinitialiserPartie(); // R�initialiser si tous les gigots et baies ont �t� collect�s
                }
                break;
            }
        }

        // V�rifier collision avec les kits de soin
        for (int i = 0; i < kitsDeSoin.Count; i++)
        {
            if (kitsDeSoin[i] == pacman)
            {
                if (vies < 3) // Limiter � 3 vies maximum
                {
                    vies++;
                    kitsDeSoin.RemoveAt(i); // Ramasser le kit de soin
                }
                break;
            }
        }
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
                    g.DrawImage(imageMur, x * tailleCase, y * tailleCase, tailleCase, tailleCase);
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
                    g.DrawImage(imageSol, x * tailleCase, y * tailleCase, tailleCase, tailleCase);
                }
            }
        }

        // Dessiner les gigots
        double tailleGigot = tailleCase / 1.8;
        foreach (var gigot in gigots)
        {
            g.DrawImage(imageGigot, gigot.X * tailleCase + (tailleCase - (int)tailleGigot) / 2, gigot.Y * tailleCase + (tailleCase - (int)tailleGigot) / 2, (int)tailleGigot, (int)tailleGigot);
        }

        // Dessiner les baies
        double tailleBaie = tailleCase / 1.2;
        foreach (var baie in baies)
        {
            g.DrawImage(imageBaie, baie.X * tailleCase + (tailleCase - (int)tailleBaie) / 2, baie.Y * tailleCase + (tailleCase - (int)tailleBaie) / 2, (int)tailleBaie, (int)tailleBaie);
        }

        // Dessiner les kits de soin
        double tailleKitDeSoin = tailleCase / 1.5;
        foreach (var kit in kitsDeSoin)
        {
            g.DrawImage(imageKitDeSoin, kit.X * tailleCase + (tailleCase - (int)tailleKitDeSoin) / 2, kit.Y * tailleCase + (tailleCase - (int)tailleKitDeSoin) / 2, (int)tailleKitDeSoin, (int)tailleKitDeSoin);
        }

        // Dessiner les gourdins
        double tailleGourdin = tailleCase / 1.2;
        foreach (var gourdin in gourdinPositions)
        {
            g.DrawImage(imageGourdin, gourdin.X * tailleCase + (tailleCase - (int)tailleGourdin) / 2, gourdin.Y * tailleCase + (tailleCase - (int)tailleGourdin) / 2, (int)tailleGourdin, (int)tailleGourdin);
        }


        // Dessiner Pacman
        g.DrawImage(imagePacman, pacman.X * tailleCase, pacman.Y * tailleCase, tailleCase, tailleCase);

        // Dessiner les fant�mes
        foreach (var fantome in fantomes)
        {
            g.DrawImage(imageFantome, fantome.X * tailleCase, fantome.Y * tailleCase, tailleCase, tailleCase);
        }

        // Afficher le score et les vies
        g.DrawString($"Score: {score}", new Font("Arial", 14), Brushes.White, new PointF(10, hauteurLabyrinthe * tailleCase + 10));
        g.DrawString($"Vies: {vies}", new Font("Arial", 14), Brushes.White, new PointF(150, hauteurLabyrinthe * tailleCase + 10));
        g.DrawString($"Gourdin: {(aGourdin ? "Oui" : "Non")}", new Font("Arial", 14), Brushes.White, new PointF(290, hauteurLabyrinthe * tailleCase + 10));
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

        // Enlever la bordure en bas et � droite
        // Enlever la bordure � droite si la largeur est paire
        if (largeur % 2 == 0)
        {
            for (int y = 0; y < hauteur; y++)
            {
                labyrinthe[y, largeur - 1] = 0; // Enlever la bordure � droite
            }
        }

        // Enlever la bordure en bas si la hauteur est impaire
        if (hauteur % 2 == 0)
        {
            for (int x = 0; x < largeur; x++)
            {
                labyrinthe[hauteur - 1, x] = 0; // Enlever la bordure en bas
            }
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
            int randomIndex = aleatoire.Next(i, directions.Length); // S�lection al�atoire d'une direction
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
                labyrinthe[(nextY + y) / 2, (nextX + x) / 2] = 0; // La cellule entre les deux devient un espace vide �galement

                GenererLabyrinthe(nextX, nextY, labyrinthe, largeur, hauteur); // Appel r�cursif pour g�n�rer le reste du labyrinthe � partir de la nouvelle position
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
            if (labyrinthe[y, x] == 0 && (x != 1 || y != 1)) // Ne pas d�marrer � la position de Pacman
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
        // V�rifie si la position est occup�e par une baie ou un kit de soin
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

            // Supprimer les autres �l�ments � cette position
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
        MettreAJourImagePacman(); // Mettre � jour l'image de Pacman apr�s la fin du gourdin
    }


    private bool EstPositionInitialePacman(Point position)
    {
        return position.X == 1 && position.Y == 1;
    }

    private void FinDeJeu()
    {
        // V�rifier si le jeu est d�j� termin�
        if (jeuTermine) return;

        jeuTermine = true;

        // Arr�ter tous les timers et autres actions du jeu
        gourdinTimer.Stop(); // Arr�ter le timer des gourdins
        minuterie.Stop(); // Arr�ter le timer des dinosaures

        MessageBox.Show("Game Over! Votre score final est : " + score, "Fin de jeu");

        Environment.Exit(0); //  l'arr�t de l'application
    }

    private void ReinitialiserPartie()
    {
        // Sauvegarde du score actuel
        int scoreActuel = score;

        // R�initialisation du labyrinthe et des �l�ments de jeu
        labyrinthe = GenererLabyrintheEnProfondeur(largeurLabyrinthe, hauteurLabyrinthe);
        pacman = new Point(1, 1); // Position de d�part de Pacman
        vies = 3;
        aGourdin = false;

        // R�initialisation des collectibles
        gigots = InitialiserGigots();
        baies = InitialiserBaies();
        kitsDeSoin = InitialiserKitsDeSoin();
        gourdinPositions = InitialiserGourdins();

        // R�initialisation des fant�mes
        fantomes = InitialiserFantomes();
        fantomesTues.Clear();
        tempsFantomeTue.Clear();

        // R�initialisation des timers
        minuterie.Start(); // Red�marrer la minuterie principale
        gourdinTimer.Stop(); // Arr�ter le timer des gourdins
        aGourdin = false; // R�initialiser l'�tat du gourdin
        directionActuelle = Direction.Droite; // R�initialiser la direction de Pacman

        // Restaurer le score sauvegard�
        score = scoreActuel;

        // Rafra�chir l'affichage du jeu
        this.Invalidate();
    }



    [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        int hauteur = 24;
        int largeur = 30;

        Application.Run(new JeuFacile(hauteur, largeur));
    }
}