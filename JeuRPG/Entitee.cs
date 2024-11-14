using System.Data;

namespace MSTest_Formation
{
    public class Entitee(Boolean joueur, string nom, int vie, int attaque, int defense, int magie)
    {
        public Boolean Joueur { get; set; } = joueur;
        public string Nom { get; set; } = nom;
        public int Vie { get; set; } = vie;

        public int MaxVie { get; set; } = vie;
        public int Attaque { get; set; } = attaque;
        public int Defense { get; set; } = defense;

        public int Magie { get; set; } = magie;

        public void DemandeNom()
        {
            // Le nom du joueur doit avoir au moins 1 charactère et il ne peut pas être un espace
            while (true) {
                Nom = Console.ReadLine();
                if (Nom.Length > 0 && !Nom.Contains(" ")) { break; }

                if (Joueur) { System.Console.WriteLine("# Désolé aventurier, je n'ai pas entendu votre nom... Pouvez-vous le répéter ?"); }
                else { System.Console.WriteLine("# Désolé aventurier, je n'ai pas entendu son nom... Pouvez-vous le répéter ?"); }
            }
        }

        public void Attaquer(Entitee cible)
        {
            Random random = new Random();

            int degats = Combat.CalculDegats(Attaque, cible.Defense);
            Boolean estVaincu = cible.InfligeDegats(degats);
            if (!cible.Joueur) {
                System.Console.WriteLine($"\nVous infligez {degats} points de dégâts au {cible.Nom} !");
                AfficherBarresVie(cible);
                if (estVaincu) {
                    System.Console.WriteLine($"Vous avez vaincu le {cible.Nom} !");
                    int points;
                    if (cible.MaxVie < 100) { points = 1; } else { points = random.Next(2, 3); }
                    DemanderAjoutAttribut(points);
                }
            } else {
                System.Console.WriteLine($"\n{Nom} vous inflige {degats} points de dégâts !");
                AfficherBarresVie(cible);
                if (estVaincu)
                {
                    System.Console.WriteLine($"{Nom} vous a vaincu...");
                }
            }
        }

        public static void AfficherBarresVie(Entitee entitee)
        {
            string barreVie = "";
            // On calcule le pourcentage de vie restant puis affiche une barre de vie avec "█" pour chaque tranche de 5% de vie et "░" pour chaque tranche de 5% de vie manquante
            if (entitee.MaxVie > 0) {
                double pourcentageVie = (double)entitee.Vie / entitee.MaxVie;
                int nbBarres = (int)(pourcentageVie * 10);
                int i;
                for (i = 0; i < nbBarres; i++)
                {
                    barreVie += "█";
                }
                for (i = 0; i < 10 - nbBarres; i++)
                {
                    barreVie += "░";
                }
            }
            System.Console.WriteLine($"{barreVie} {entitee.Nom} [{entitee.Vie}/{entitee.MaxVie}]");
        }

        public void SeSoigner()
        {
            int soins = Combat.CalculSoins(Magie);
            Soigne(soins);
            if (Joueur)
            {
                System.Console.WriteLine($"\nVous vous soignez et récupérez {soins} points de vie !");
            }
            else
            {
                System.Console.WriteLine($"\n{Nom} se soigne et récupère {soins} points de vie !");
            }
            AfficherBarresVie(this);
        }

        
        public Boolean InfligeDegats(int degats)
        {
            Vie -= degats;
            if (Vie <= 0) { 
                Vie = 0;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Soigne(int soins)
        {
            Vie += soins;
            if (Vie > MaxVie) { Vie = MaxVie; }
        }

        public void DemanderAjoutAttribut(int points)
        {
            if (!Joueur) { return; } // On ne demande pas à un monstre d'ajouter des attributs

            System.Console.WriteLine($"\n# Vous avez trouvé {points} point(s) bonus ! ");
            while (points > 0)
            {
                System.Console.WriteLine($"Il vous reste {points} point(s). Quel statistique augmenter ?\n1 - Vie\n2 - Attaque\n3 - Défense\n4 - Magie");
                points--;

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
                        Vie += 20;
                        MaxVie += 20;
                        System.Console.WriteLine($"\n# Vous avez maintenant {Vie}/{MaxVie} points de vie !");
                        break;
                    case 2:
                        Attaque += 5;
                        System.Console.WriteLine($"\n# Vous avez maintenant {Attaque} points d'attaque !");
                        break;
                    case 3:
                        Defense += 5;
                        System.Console.WriteLine($"\n# Vous avez maintenant {Defense} points de défense !");
                        break;
                    case 4:
                        Magie += 5;
                        System.Console.WriteLine($"\n# Vous avez maintenant {Magie} points de magie !");
                        break;
                    default:
                        System.Console.WriteLine("\n# Je n'ai pas compris votre choix, aventurier.");
                        points++;
                        break;
                }
            }
        }
    }
}
