namespace MSTest_Formation
{
    public class Joueur(string nom, int vie, int attaque, int defense, int magie)
    {
        public string Nom { get; set; } = nom;
        public int Vie { get; set; } = vie;

        public int MaxVie { get; set; } = vie;
        public int Attaque { get; set; } = attaque;
        public int Defense { get; set; } = defense;

        public int Magie { get; set; } = magie;

        public void Attaquer(Combat combat, Monstre monstre)
        {
            int degats = Combat.CalculDegats(Attaque, monstre.Defense);
            monstre.Vie -= degats;
            if (monstre.Vie < 0) { monstre.Vie = 0; }
            System.Console.WriteLine($"\nVous infligez {degats} points de dégâts au {monstre.Nom} !");
            System.Console.WriteLine($"Il lui reste {monstre.Vie}/{monstre.MaxVie} points de vie.");
            if (monstre.Vie == 0)
            {
                System.Console.WriteLine($"Vous avez vaincu le {monstre.Nom} !");
                Combat.AjoutAttribut(this);
            }
        }

        public void SeSoigner(Combat combat)
        {
            int soins = Combat.CalculSoins(Magie);
            Vie += soins;
            if (Vie > MaxVie) { Vie = MaxVie; }
            System.Console.WriteLine($"\nVous vous soignez et récupérez {soins} points de vie !");
            System.Console.WriteLine($"Vous avez maintenant {Vie}/{MaxVie} points de vie.");
        }
    }
}
