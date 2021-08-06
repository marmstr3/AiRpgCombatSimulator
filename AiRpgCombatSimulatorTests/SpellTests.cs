using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using AiRpgCombatSimulator.Characters;
using AiRpgCombatSimulator.Characters.Players;
using AiRpgCombatSimulator.ComplexActions.Spells;

namespace AiRpgCombatSimulatorTests
{
    [TestClass]
    class SpellTests
    {
        [TestMethod]
        public void TestFireBall()
        {
            Character testCaster = new BlackMage();
            List<Character> testTargets = new List<Character> { new Fighter() } ;
            Spell testFireball = new Fireball();

            testFireball.Execute(testCaster, testTargets);

            Assert.AreEqual(testTargets[0].CurrentHP, 25);
            Assert.AreEqual(testCaster.CurrentMP, 40);
        }

        public void TestFireballWithOil()
        {
            Character testCaster = new BlackMage();
            List<Character> testTargets = new List<Character> { new Fighter() };
            Spell testFireball = new Fireball();

            testTargets[0].IsOiled = true;

            testFireball.Execute(testCaster, testTargets);

            Assert.AreEqual(testTargets[0].CurrentHP, 0);
            Assert.AreEqual(testCaster.CurrentMP, 40);
        }

        [TestMethod]
        public void TestEmpower()
        {
            Character testCaster = new BlackMage();
            List<Character> testTargets = new List<Character> { new Fighter() };
            Spell testEmpower = new Empower();

            testEmpower.Execute(testCaster, testTargets);

            Assert.AreEqual(testTargets[0].IsEmpowered, true);
            Assert.AreEqual(testCaster.CurrentMP, 40);
        }
    }
}
