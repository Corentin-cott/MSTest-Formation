using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTest_Formation
{
    public class Objet()
    {
        public string Nom { get; set; }
        public string Type { get; set; } // Type de l'objet (Arme, Armure, Bouclier, ou Accessoire)
        public int MaxVieBoost { get; set; }
        public int DefenseBoost { get; set; }
        public int AttaqueBoost { get; set; }
        public int MagieBoost { get; set; }

        public Objet GenObjet()
        {
            Random random = new Random();

            string[] noms = { "Epée en bois", "Epée en fer", "Bouclier en fer", "Sceptre" };
            string[] type = { "Arme", "Arme", "Bouclier", "Arme" };

            int objetIndex = random.Next(0, noms.Length);
            string nom = noms[objetIndex];
            string typeObjet = type[objetIndex];

            int maxVieBoost = random.Next(0, 5);
            int defenseBoost = random.Next(0, 5);
            int attaqueBoost = random.Next(0, 5);
            int magieBoost = random.Next(0, 5);
            Objet objet = new() { Nom = nom, Type = typeObjet, DefenseBoost = defenseBoost, AttaqueBoost = attaqueBoost, MagieBoost = magieBoost };
            return objet;
        }
    }
}
