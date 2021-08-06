using Microsoft.VisualStudio.TestTools.UnitTesting;
using AiRpgCombatSimulator.Characters;
using AiRpgCombatSimulator.Characters.Players;

namespace AiRpgCombatSimulatorTests
{
    [TestClass]
    public class CharacterTests
    {

        [TestMethod]
        public void TestFighterInstantiation()
        {
            Character testFighter = new Fighter();

            Assert.AreEqual(testFighter.MaxHP, 50);
            Assert.AreEqual(testFighter.MaxMP, 50);
            Assert.AreEqual(testFighter.CurrentHP, 50);
            Assert.AreEqual(testFighter.CurrentMP, 50);
            Assert.AreEqual(testFighter.AttackPower, 10);
            Assert.AreEqual(testFighter.Name, "Fighter");
            Assert.AreEqual(testFighter.IsDead, false);
            Assert.AreEqual(testFighter.IsDefending, false);
            Assert.AreEqual(testFighter.IsOiled, false);
            Assert.AreEqual(testFighter.IsEmpowered, false);
        }

        [TestMethod]
        public void TestFighterTakeDamage()
        {
            Character testFighter = new Fighter();

            testFighter.TakeDamage(5);
            Assert.AreEqual(testFighter.CurrentHP, 45);
        }

        [TestMethod]
        public void TestFighterDefend()
        {
            Character testFighter = new Fighter();

            testFighter.IsDefending = true;
            testFighter.TakeDamage(10);
            Assert.AreEqual(testFighter.CurrentHP, 45);
        }

        [TestMethod]
        public void TestFighterAttack()
        {
            Character testFighter = new Fighter();
            Character targetFighter = new Fighter();

            testFighter.Attack(targetFighter);

            Assert.AreEqual(targetFighter.CurrentHP, 40);
        }

        // Would write similar test methods for the other classes


    }
}
