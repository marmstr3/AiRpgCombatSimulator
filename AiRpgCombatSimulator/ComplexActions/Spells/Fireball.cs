using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AiRpgCombatSimulator.Characters;

namespace AiRpgCombatSimulator.ComplexActions.Spells
{
    class Fireball : Spell
    {

        public Fireball() :
            base("Fireball", "Blast the enemy with a ball of concentrated fire.", 10)
        {

        }

        public override void Execute(Character executor, Character target)
        {
            executor.CurrentMP -= this.MpCost;
            target.TakeDamage(25, "fire");
        }
    }
}
