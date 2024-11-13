namespace MSTest_Formation
{
    public class Monstre(string nom, int vie, int attaque, int defense, int magie)
    {
        public string Nom { get; set; } = nom;
        public int Vie { get; set; } = vie;

        public int MaxVie { get; set; } = vie;
        public int Attaque { get; set; } = attaque;
        public int Defense { get; set; } = defense;
        public int Magie { get; set; } = magie;

        public void Attaquer(Combat combat, Joueur joueur)
        {
            int degats = Combat.CalculDegats(Attaque, joueur.Defense);
            joueur.Vie -= degats;
            if (joueur.Vie < 0) { joueur.Vie = 0; }
            System.Console.WriteLine($"\n{Nom} vous inflige {degats} points de dégâts !");
            System.Console.WriteLine($"Il vous reste {joueur.Vie}/{joueur.MaxVie} points de vie.");
            if (joueur.Vie == 0)
            {
                System.Console.WriteLine($"{Nom} vous a vaincu...");
            }
        }
    }

}
