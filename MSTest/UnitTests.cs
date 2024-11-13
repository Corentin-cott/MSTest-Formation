using MSTest_Formation;
using FluentAssertions;

namespace MSTest
{
    [TestClass]
    // Class qui va me permettre d'apprendre à utiliser MSTest et les tests unitaires
    // Les tests unitaires suivent le principe de AAA : Arrange, Act, Assert. En français : Arranger, Agir, Auditer
    public class UnitTests
    {
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
            monstre.MaxVie.Should().Equals(monstre.Vie); // Si la vie maximale du monstre est différente de sa vie, le test échoue
            monstre.Attaque.Should().BePositive(); // Si l'attaque du monstre est inférieure ou égale à 0, le test échoue
            monstre.Defense.Should().BePositive(); // Si la défense du monstre est inférieure ou égale à 0, le test échoue
            monstre.Magie.Should().BePositive(); // Si la magie du monstre est inférieure ou égale à 0, le test échoue
        }
    }
}