using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AiRpgCombatSimulator.ComplexActions.Consumables;
using AiRpgCombatSimulator.ComplexActions.Consumables.Items;
using AiRpgCombatSimulator.ComplexActions.Spells;

namespace AiRpgCombatSimulator.Characters.Players
{
    class Thief: Character
    {
        public Thief():
            base("Thief", 50, 50, 7, Properties.Resources.Thief)
        {
            this.Items = new List<Consumable>
            {
                new OilFlask(),
                null,
                null,
                null,
                null,
                null                            
            };
            this.Skills = new List<Consumable> { };
            this.Spells = new List<Spell> { };
        }
    }
}
