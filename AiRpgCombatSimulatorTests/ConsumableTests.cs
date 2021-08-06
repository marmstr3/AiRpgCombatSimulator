using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using AiRpgCombatSimulator.Characters;
using AiRpgCombatSimulator.Characters.Players;
using AiRpgCombatSimulator.ComplexActions.Consumables;
using AiRpgCombatSimulator.ComplexActions.Consumables.Items;

namespace AiRpgCombatSimulatorTests
{
    [TestClass]
    class ConsumableTests
    {
        [TestMethod]
        public void TestOilFlask()
        {
            Character testUser = new Thief();
            List<Character> testTargets = new List<Character> { new Fighter() };
            Consumable testOilFlask = new OilFlask();

            Assert.AreEqual(testOilFlask.Quantity, 1);

            testOilFlask.Execute(testUser, testTargets);

            Assert.AreEqual(testTargets[0].IsOiled, true);
            Assert.AreEqual(testOilFlask.Quantity, 0);
        }
    }
}
