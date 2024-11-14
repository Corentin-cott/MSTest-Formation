namespace MSTest_Formation
{
    public class Combat(int nbVagues)
    {
        public int NbVagues { get; set; } = nbVagues;

        public Entitee GenMonstre()
        {
            Random random = new Random();

            string[] noms = { "Gobelin", "Orc", "Troll", "Dragon", "Loup", "Squelette", "Zombie", "Goule", "Vampire", "Loup-garou", "Renard Bleue" };
            string nom = noms[random.Next(0, noms.Length)];

            int vie = 50 + (NbVagues * 5);
            int attaque = 5 + random.Next(NbVagues, NbVagues + 5);
            int defense = random.Next(NbVagues, NbVagues + 5);
            int magie = 2 + random.Next(0, NbVagues * 2);
            Entitee monstre = new(false, nom, vie, attaque, defense, magie);
            return monstre;
        }

        public Entitee GenBoss()
        {
            Random random = new Random();

            string[] noms = { "Gargantua", "Hydre", "Kraken", "Sphinx", "Cerbère", "Basilic", "Chimère", "Phénix", "Léviathan", "Dragon de l'Apocalypse" };
            string nom = noms[random.Next(0, noms.Length)];

            int vie = 100 + (NbVagues * 10);
            int attaque = 10 + NbVagues;
            int defense = NbVagues + 2;
            int magie = 5 + random.Next(0, NbVagues * 2);
            Entitee boss = new(false, nom, vie, attaque, defense, magie);
            return boss;
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
    }
}
