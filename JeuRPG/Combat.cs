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

            int vie = 50 + (NbVagues * 5);
            int attaque = 5 + random.Next(NbVagues, NbVagues + 5);
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
    }
}
