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

        public string Armure { get; set; } = "Aucune";

        public string Arme { get; set; } = "Aucune";

        public string Bouclier { get; set; } = "Aucun";

        public string Accessoire { get; set; } = "Aucun";

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

                    int chancePourObjet = random.Next(1, 1);
                    if (chancePourObjet == 1)
                    {
                        Objet objet = new Objet().GenObjet();
                        DemanderEquipeObjet(objet, this);
                    }
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

        public void MalusStats(int vie, int attaque, int defense, int magie)
        {
            MaxVie -= vie;
            Attaque -= attaque;
            Defense -= defense;
            Magie -= magie;
        }

        public void BoostStats(int vie, int attaque, int defense, int magie)
        {
            MaxVie += vie;
            Attaque += attaque;
            Defense += defense;
            Magie += magie;
        }

        public static void EquipeObjet(Objet objet, Entitee cible)
        {
            switch (objet.Type)
            {
                case "Armure":
                    cible.Armure = objet.Nom;
                    break;
                case "Arme":
                    cible.Arme = objet.Nom;
                    break;
                case "Bouclier":
                    cible.Bouclier = objet.Nom;
                    break;
                case "Accessoire":
                    cible.Accessoire = objet.Nom;
                    break;
            }
            System.Console.WriteLine($"\n# Vous avez équipé {objet.Nom}.");
            cible.BoostStats(objet.MaxVieBoost, objet.AttaqueBoost, objet.DefenseBoost, objet.MagieBoost);
        }

        public static void DemanderEquipeObjet(Objet objet, Entitee cible)
        {
            System.Console.WriteLine($"\nVoulez-vous l'équiper ?\n1 - Oui\n2 - Non");
            Boolean reponseValide = true;
            while (reponseValide)
            {
                string choix = Console.ReadLine();

                switch(choix)
                {
                    case "1":
                        reponseValide = false;
                        break;
                    case "2":
                        reponseValide = false;
                        return;
                    default:
                        System.Console.WriteLine("# Je n'ai pas compris votre choix, aventurier.");
                        break;
                }
            }

            if (cible.Armure == "Aucune" && objet.Type == "Armure" || cible.Arme == "Aucune" && objet.Type == "Arme" || cible.Bouclier == "Aucun" && objet.Type == "Bouclier" || cible.Accessoire == "Aucun" && objet.Type == "Accessoire")
            {
                EquipeObjet(objet, cible);
                System.Console.WriteLine($"# Vous recevez : +{objet.MaxVieBoost} points de vie, +{objet.AttaqueBoost} points d'attaque, +{objet.DefenseBoost} points de défense et +{objet.MagieBoost} points de magie.");
                System.Console.WriteLine($"# Vous avez maintenant {cible.Vie}/{cible.MaxVie} points de vie, {cible.Attaque} points d'attaque, {cible.Defense} points de défense et {cible.Magie} points de magie.");
            }
            else
            {
                System.Console.WriteLine($"\n# Vous avez déjà un {objet.Type} équipé. Voulez-vous le remplacer ?\n1 - Oui\n2 - Non");
                while (true)
                {
                    string choix = Console.ReadLine();

                    switch (choix)
                    {
                        case "1":
                            EquipeObjet(objet, cible);
                            return;
                        case "2":
                            System.Console.WriteLine("# Vous avez décidé de jeter cet objet.");
                            return;
                        default:
                            System.Console.WriteLine("# Je n'ai pas compris votre choix, aventurier.");
                            break;
                    }
                }
            }
        }

        public void DemandeNom()
        {
            // Le nom du joueur doit avoir au moins 1 charactère et il ne peut pas être un espace
            while (true)
            {
                Nom = Console.ReadLine();
                if (Nom.Length > 0 && !Nom.Contains(" ")) { break; }

                if (Joueur) { System.Console.WriteLine("# Désolé aventurier, je n'ai pas entendu votre nom... Pouvez-vous le répéter ?"); }
                else { System.Console.WriteLine("# Désolé aventurier, je n'ai pas entendu son nom... Pouvez-vous le répéter ?"); }
            }
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

        public static void AfficherBarresVie(Entitee entitee)
        {
            string barreVie = "";
            // On calcule le pourcentage de vie restant puis affiche une barre de vie avec "█" pour chaque tranche de 5% de vie et "░" pour chaque tranche de 5% de vie manquante
            if (entitee.MaxVie > 0)
            {
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
    }
}
