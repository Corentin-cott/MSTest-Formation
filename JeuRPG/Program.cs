namespace MSTest_Formation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ce projet à pour but de me former à MSTest et aux frameworks de tests unitaires en général
            // Pour cela, je vais créer une application console simple et concise qui à pour seul but de me permettre de tester les différentes tests

            // Mon application sera un jeu de combat par vagues. Elle sera composée de 3 classes : Joueur, Monstre et Combat

            // Création d'une instance de Combat
            Combat combat = new(5);

            // Création d'une instance de Joueur
            System.Console.WriteLine("# Bienvenue aventurier ! Dites moi, quel est votre nom ?");
            string nom = DemanderNomJoueur();
            Joueur joueur = new Joueur(nom, 200, 10, 5, 5);
            System.Console.WriteLine($"# Bienvenue {joueur.Nom} ! Vous avez {joueur.Vie} points de vie, {joueur.Attaque} points d'attaque et {joueur.Defense} points de défense.");

            // Lancement des vagues de combat
            for (int i = 0; i < combat.NbVagues; i++)
            {
                if (joueur.Vie == 0) 
                {
                    System.Console.WriteLine($"# Vous avez survécu à {i} vagues de monstres ! Félicitations !");
                    System.Console.WriteLine($"# Vos statistiques finales étaient : " +
                        $"- {joueur.Vie}/{joueur.MaxVie} points de vie, " +
                        $"- {joueur.Attaque} points d'attaque" +
                        $"- {joueur.Defense} points de défense" +
                        $"- {joueur.Magie} points de magie"
                    );
                    break; 
                }
                System.Console.WriteLine($"\n# Vague {i + 1} : Préparez-vous !\n");
                Monstre monstre = combat.GenMonstre();
                System.Console.WriteLine($"# Un {monstre.Nom} apparaît ! Il a {monstre.Vie} points de vie, {monstre.Attaque} points d'attaque et {monstre.Defense} points de défense.");
                while (joueur.Vie > 0 && monstre.Vie > 0)
                {
                    System.Console.WriteLine("\n# Que voulez-vous faire ?\n1 - Attaquer\n2 - Se soigner");
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
                            joueur.Attaquer(combat, monstre);
                            break;
                        case 2:
                            joueur.SeSoigner(combat);
                            break;
                        default:
                            System.Console.WriteLine("# Je n'ai pas compris votre choix, aventurier.");
                            break;
                    }
                    if (monstre.Vie > 0)
                    {
                        monstre.Attaquer(combat, joueur);
                    }
                }
            }
        }

        static string DemanderNomJoueur()
        {
            string nom = Console.ReadLine();
            while (nom == "")
            {
                System.Console.WriteLine("# Ne sois pas timide, aventurier !");
                nom = Console.ReadLine();
            }
            return nom;
        }        
    }
}