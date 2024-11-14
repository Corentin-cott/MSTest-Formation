using MSTest_Formation;
using FluentAssertions;

namespace MSTest
{
    [TestClass]
    // Class qui va me permettre d'apprendre à utiliser MSTest et les tests unitaires
    // Les tests unitaires suivent le principe de AAA : Arrange, Act, Assert. En français : Arranger, Agir, Auditer
    public class UnitTests
    {

        // Méthodes pour la class Combat
        [TestMethod]
        public void TestGenMonstre()
        {
            // Arrange : On crée les objets et variables nécessaires à notre test
            Combat combat = new(5);

            // Act : On simule l'action à vérifier
            Monstre monstre = combat.GenMonstre();
            // string monstre = "Gobelin"; // On fausse le test volontairement pour vérifier qu'on ne créer pas de faux positif

            // Assert : On vérifie que le monstre a bien été créé et que ses statistiques sont cohérentes
            Assert.IsNotNull(monstre); // Si "monstre" est null, le test échoue
            Assert.IsInstanceOfType(monstre, typeof(Monstre)); // Si "monstre" n'est pas une instance de Monstre, le test échoue
            monstre.Vie.Should().BeGreaterOrEqualTo(50); // Si la vie du monstre est inférieure à 50, le test échoue
            monstre.MaxVie.Should().Be(monstre.Vie); // Si la vie maximale du monstre est différente de sa vie, le test échoue
            monstre.Attaque.Should().BePositive(); // Si l'attaque du monstre est inférieure ou égale à 0, le test échoue
            monstre.Defense.Should().BePositive(); // Si la défense du monstre est inférieure ou égale à 0, le test échoue
            monstre.Magie.Should().BeGreaterThanOrEqualTo(0); // Si la magie du monstre est inférieure à 0, le test échoue
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
            // Formule de calcul des dégâts : (attaque + random.Next(1, 5)) - defense 
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

        // Méthodes pour la class Joueur
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
            monstre.Vie.Should().BeLessThan(monstre.MaxVie); // Si la vie du monstre n'a pas diminué, le test échoue
            monstre.Vie.Should().BeGreaterOrEqualTo(0);
        }

        [TestMethod]
        public void TestJoueurSeSoigner()
        {
            // Arrange
            Combat combat = new(5);
            Joueur joueur = new("JoueurTest", 100, 10, 5, 10);
            joueur.InfligeDegats(50); // On inflige des dégâts au joueur pour qu'il puisse se soigner
            int viePreSoins = joueur.Vie;

            // Act
            joueur.SeSoigner(combat);

            // Assert
            joueur.Vie.Should().BeGreaterThan(viePreSoins); // Si la vie du joueur n'a pas augmenté, le test échoue
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
            joueur.Vie.Should().BeLessThan(viePreAttaque); // Si la vie du joueur n'a pas diminué, le test échoue
            joueur.Vie.Should().BeGreaterOrEqualTo(0);
        }
    }
}