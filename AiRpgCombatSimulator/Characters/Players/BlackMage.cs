using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AiRpgCombatSimulator.ComplexActions.Consumables;
using AiRpgCombatSimulator.ComplexActions.Spells;

namespace AiRpgCombatSimulator.Characters.Players
{
    class BlackMage: Character
    {
        public BlackMage() :
            base("Black Mage", 50, 50, 5, Properties.Resources.BlackMage)
        {
            this.Items = new List<Consumable> { };
            this.Skills = new List<Consumable> { };
            this.Spells = new List<Spell>
            {
                new Fireball(),
                new Fireball(),
                new Fireball(),
                new Fireball(),
                new Fireball(),
                new Fireball()
            };
        }
    }
}
