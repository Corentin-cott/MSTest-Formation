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
            int degats = Combat.CalculDegats(Attaque, cible.Defense);
            Boolean estVaincu = cible.InfligeDegats(degats);
            if (Joueur) {
                System.Console.WriteLine($"\nVous infligez {degats} points de dégâts au {cible.Nom} !");
                System.Console.WriteLine($"Il lui reste {cible.Vie}/{cible.MaxVie} points de vie.");
                if (estVaincu) {
                    System.Console.WriteLine($"Vous avez vaincu le {cible.Nom} !");
                    DemanderAjoutAttribut();
                }
            } else {
                System.Console.WriteLine($"\n{Nom} vous inflige {degats} points de dégâts !");
                System.Console.WriteLine($"Il vous reste {cible.Vie}/{cible.MaxVie} points de vie.");
                if (estVaincu)
                {
                    System.Console.WriteLine($"{Nom} vous a vaincu...");
                }
            }
        }

        public void SeSoigner()
        {
            int soins = Combat.CalculSoins(Magie);
            Soigne(soins);
            if (Joueur)
            {
                System.Console.WriteLine($"\nVous vous soignez et récupérez {soins} points de vie !");
                System.Console.WriteLine($"Vous avez maintenant {Vie}/{MaxVie} points de vie.");
            }
            else
            {
                System.Console.WriteLine($"\n{Nom} se soigne et récupère {soins} points de vie !");
                System.Console.WriteLine($"{Nom} a maintenant {Vie}/{MaxVie} points de vie.");
            }
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

        public void DemanderAjoutAttribut()
        {
            if (!Joueur) { return; } // On ne demande pas à un monstre d'ajouter des attributs

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
                    Vie += 10;
                    MaxVie += 10;
                    System.Console.WriteLine($"\n# Vous avez maintenant {Vie}/{MaxVie} points de vie !");
                    break;
                case 2:
                    Attaque += 2;
                    System.Console.WriteLine($"\n# Vous avez maintenant {Attaque} points d'attaque !");
                    break;
                case 3:
                    Defense += 1;
                    System.Console.WriteLine($"\n# Vous avez maintenant {Defense} points de défense !");
                    break;
                case 4:
                    Magie += 2;
                    System.Console.WriteLine($"\n# Vous avez maintenant {Magie} points de magie !");
                    break;
                default:
                    System.Console.WriteLine("\n# Je n'ai pas compris votre choix, aventurier.");
                    DemanderAjoutAttribut();
                    break;
            }
        }
    }
}
