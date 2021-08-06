using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AiRpgCombatSimulator.ComplexActions.Consumables;
using AiRpgCombatSimulator.ComplexActions.Spells;

namespace AiRpgCombatSimulator.Characters.Players
{
    class WhiteMage: Character
    {
        public WhiteMage():
            base("White Mage", 50, 50, 1, Properties.Resources.WhiteMage)
        {
            this.Items = new List<Consumable> { };
            this.Skills = new List<Consumable> { };
            this.Spells = new List<Spell>
            {
                new Empower(),
                new Empower(),
                new Empower(),
                new Empower(),
                new Empower(),
                new Empower()
            };
        }
    }
}
