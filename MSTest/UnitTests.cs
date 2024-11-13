using MSTest_Formation;
using FluentAssertions;

namespace MSTest
{
    [TestClass]
    // Class qui va me permettre d'apprendre � utiliser MSTest et les tests unitaires
    // Les tests unitaires suivent le principe de AAA : Arrange, Act, Assert. En fran�ais : Arranger, Agir, Auditer
    public class UnitTests
    {
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
            monstre.MaxVie.Should().Equals(monstre.Vie); // Si la vie maximale du monstre est diff�rente de sa vie, le test �choue
            monstre.Attaque.Should().BePositive(); // Si l'attaque du monstre est inf�rieure ou �gale � 0, le test �choue
            monstre.Defense.Should().BePositive(); // Si la d�fense du monstre est inf�rieure ou �gale � 0, le test �choue
            monstre.Magie.Should().BePositive(); // Si la magie du monstre est inf�rieure ou �gale � 0, le test �choue
        }
    }
}