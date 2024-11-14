using System.Net.NetworkInformation;

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
            Entitee joueur = new(true, "placeholder", 200, 8, 5, 10);
            joueur.DemandeNom();
            System.Console.WriteLine($"# Bienvenue {joueur.Nom} ! Vous avez {joueur.Vie} points de vie, {joueur.Attaque} points d'attaque et {joueur.Defense} points de défense.");

            // Lancement des vagues de combat
            int i;
            for (i = 0; i < combat.NbVagues; i++)
            {
                if (joueur.Vie == 0) 
                {
                    break; 
                }

                // Pas de chiffre a virgule
                float bossVague1 = 5 / 2;
                int bossVague2 = combat.NbVagues;

                Entitee monstre;
                if ( i+1 == bossVague1 || i+1 == bossVague2)
                {
                    System.Console.WriteLine($"\n# Vague {i + 1} : Combat de Boss ! Préparez-vous !!");
                    monstre = combat.GenBoss();
                }
                else
                {
                    System.Console.WriteLine($"\n# Vague {i + 1} : Préparez-vous !!");
                    monstre = combat.GenMonstre();
                }

                System.Console.WriteLine($"# Un {monstre.Nom} apparaît ! Il a {monstre.Vie} points de vie, {monstre.Attaque} points d'attaque et {monstre.Defense} points de défense.");
                int j = 0;
                while (joueur.Vie > 0 && monstre.Vie > 0)
                {
                    j ++;
                    System.Console.WriteLine($"\n# Vague {i} : Tour n°{j}");
                    System.Console.WriteLine("# Que voulez-vous faire ?\n1 - Attaquer\n2 - Se soigner");
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
                            joueur.Attaquer(monstre);
                            break;
                        case 2:
                            joueur.SeSoigner();
                            break;
                        default:
                            System.Console.WriteLine("# Je n'ai pas compris votre choix, aventurier.");
                            break;
                    }
                    if (monstre.Vie > 0)
                    {
                        monstre.Attaquer(joueur);
                    }
                }
            }
            System.Console.WriteLine($"\n# Vous avez survécu à {i} vagues de monstres ! Félicitations !");
            System.Console.WriteLine($"# Vos statistiques finales étaient : " +
                $"\n- {joueur.Vie}/{joueur.MaxVie} points de vie" +
                $"\n- {joueur.Attaque} points d'attaque" +
                $"\n- {joueur.Defense} points de défense" +
                $"\n- {joueur.Magie} points de magie"
            );
        }   
    }
}