using MSTest_Formation;

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
            if (monstre.GetType() != typeof(Monstre) || monstre == null)
            {
                Assert.Fail();
            }
        }
    }
}