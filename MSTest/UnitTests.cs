using MSTest_Formation;

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
        }
    }
}