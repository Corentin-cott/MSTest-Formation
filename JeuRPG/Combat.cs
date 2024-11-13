namespace MSTest_Formation
{
    public class Combat(int nbVagues)
    {
        public int NbVagues { get; set; } = nbVagues;

        public Monstre GenMonstre()
        {
            Random random = new Random();

            string[] noms = { "Gobelin", "Orc", "Troll", "Dragon", "Renard Bleue" };
            string nom = noms[random.Next(0, noms.Length)];

            int vie = 50 + (NbVagues * 10);
            int attaque = 5 + (NbVagues * 2) + random.Next(1, 4);
            int defense = random.Next(NbVagues, NbVagues + 2);
            int magie = 0;
            Monstre monstre = new(nom, vie, attaque, defense, magie);
            return monstre;
        }


        public static int CalculDegats(int attaque, int defense)
        {
            Random random = new Random();

            int degats = (attaque + random.Next(1, 5)) - defense;
            if (degats < 0) { degats = 0; }

            // 1 chance sur 8 de faire un coup critique
            if (random.Next(1, 9) == 1)
            {
                System.Console.WriteLine("\n!! Coup critique !!");
                degats *= 2;
            }
            return degats;
        }

        public static int CalculSoins(int magie)
        {
            Random random = new Random();

            int soins = magie + random.Next(1, 5);

            // 1 chance sur 8 de faire un soin critique
            if (random.Next(1, 9) == 1)
            {
                System.Console.WriteLine("\n!! Soin critique !!");
                soins *= 2;
            }

            return soins;
        }

        public static void AjoutAttribut(Joueur joueur)
        {
            System.Console.WriteLine("\n# Vous avez trouvé un bonus ! Quel statistique augmenter ?\n1 - Vie\n2 - Attaque\n3 - Défense\n4 - Magie");
            string choix = Console.ReadLine();
            int choixInt;
            while (!int.TryParse(choix, out choixInt))
            {
                System.Console.WriteLine("# Je n'ai pas compris votre choix, aventurier.");
                choix = Console.ReadLine();
            }

            switch (choixInt)
            {
                case 1:
                    joueur.Vie += 10;
                    joueur.MaxVie += 10;
                    System.Console.WriteLine($"\n# Vous avez maintenant {joueur.Vie}/{joueur.MaxVie} points de vie !");
                    break;
                case 2:
                    joueur.Attaque += 2;
                    System.Console.WriteLine($"\n# Vous avez maintenant {joueur.Attaque} points d'attaque !");
                    break;
                case 3:
                    joueur.Defense += 1;
                    System.Console.WriteLine($"\n# Vous avez maintenant {joueur.Defense} points de défense !");
                    break;
                case 4:
                    joueur.Magie += 2;
                    System.Console.WriteLine($"\n# Vous avez maintenant {joueur.Magie} points de magie !");
                    break;
                default:
                    System.Console.WriteLine("\n# Je n'ai pas compris votre choix, aventurier.");
                    AjoutAttribut(joueur);
                    break;
            }
        }
    }
}
