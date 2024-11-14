using MSTest_Formation;
using FluentAssertions;

namespace MSTest
{
    [TestClass]
    // Class qui va me permettre d'apprendre � utiliser MSTest et les tests unitaires
    // Les tests unitaires suivent le principe de AAA : Arrange, Act, Assert. En fran�ais : Arranger, Agir, Auditer
    public class UnitTests
    {

        // M�thodes pour la class Combat
        [TestMethod]
        public void TestGenMonstre()
        {
            // Arrange : On cr�e les objets et variables n�cessaires � notre test
            Combat combat = new(5);

            // Act : On simule l'action � v�rifier
            Monstre monstre = combat.GenMonstre();
            // string monstre = "Gobelin"; // On fausse le test volontairement pour v�rifier qu'on ne cr�er pas de faux positif

            // Assert : On v�rifie que le monstre a bien �t� cr�� et que ses statistiques sont coh�rentes
            Assert.IsNotNull(monstre); // Si "monstre" est null, le test �choue
            Assert.IsInstanceOfType(monstre, typeof(Monstre)); // Si "monstre" n'est pas une instance de Monstre, le test �choue
            monstre.Vie.Should().BeGreaterOrEqualTo(50); // Si la vie du monstre est inf�rieure � 50, le test �choue
            monstre.MaxVie.Should().Be(monstre.Vie); // Si la vie maximale du monstre est diff�rente de sa vie, le test �choue
            monstre.Attaque.Should().BePositive(); // Si l'attaque du monstre est inf�rieure ou �gale � 0, le test �choue
            monstre.Defense.Should().BePositive(); // Si la d�fense du monstre est inf�rieure ou �gale � 0, le test �choue
            monstre.Magie.Should().BeGreaterThanOrEqualTo(0); // Si la magie du monstre est inf�rieure � 0, le test �choue
        }

        [TestMethod]
        public void TestCalculDegats()
        {
            // Arrange
            int attaque = 10;
            int defense = 5;

            // Act
            int degats = Combat.CalculDegats(attaque, defense);

            // Assert
            // Formule de calcul des d�g�ts : (attaque + random.Next(1, 5)) - defense 
            degats.Should().BePositive();
            degats.Should().BeInRange(attaque + 1 - defense, (attaque + 5 - defense) * 2); // Ne pas oublier de multiplier par 2 pour prendre en compte le coup critique
        }

        [TestMethod]
        public void TestCalculSoins()
        {
            // Arrange
            int magie = 10;

            // Act
            int soins = Combat.CalculSoins(magie);

            // Assert
            // Formule de calcul des soins : magie + random.Next(1, 5)
            soins.Should().BePositive();
            soins.Should().BeInRange(magie + 1, (magie + 5) * 2); // Ne pas oublier de multiplier par 2 pour prendre en compte le soin critique
        }

        // M�thodes pour la class Joueur
        [TestMethod]
        public void TestJoueurAttaquer()
        {
            // Arrange
            Combat combat = new(5);
            Monstre monstre = combat.GenMonstre();
            Joueur joueur = new("JoueurTest", 100, 10, 5, 0);

            // Act
            joueur.Attaquer(combat, monstre);

            // Assert
            monstre.Vie.Should().BeLessThan(monstre.MaxVie); // Si la vie du monstre n'a pas diminu�, le test �choue
            monstre.Vie.Should().BeGreaterOrEqualTo(0);
        }

        [TestMethod]
        public void TestJoueurSeSoigner()
        {
            // Arrange
            Combat combat = new(5);
            Joueur joueur = new("JoueurTest", 100, 10, 5, 10);
            joueur.InfligeDegats(50); // On inflige des d�g�ts au joueur pour qu'il puisse se soigner
            int viePreSoins = joueur.Vie;

            // Act
            joueur.SeSoigner(combat);

            // Assert
            joueur.Vie.Should().BeGreaterThan(viePreSoins); // Si la vie du joueur n'a pas augment�, le test �choue
            joueur.Vie.Should().BeLessOrEqualTo(joueur.MaxVie);
        }

        // Test pour la class Monstre
        [TestMethod]
        public void TestMonstreAttaquer()
        {
            // Arrange
            Combat combat = new(5);
            Monstre monstre = combat.GenMonstre();
            Joueur joueur = new("JoueurTest", 100, 10, 5, 0);
            int viePreAttaque = joueur.Vie;

            // Act
            monstre.Attaquer(combat, joueur);

            // Assert
            joueur.Vie.Should().BeLessThan(viePreAttaque); // Si la vie du joueur n'a pas diminu�, le test �choue
            joueur.Vie.Should().BeGreaterOrEqualTo(0);
        }
    }
}