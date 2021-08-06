using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AiRpgCombatSimulator.Characters;

namespace AiRpgCombatSimulator.ComplexActions.Spells
{
    public class Fireball : Spell
    {

        public Fireball() :
            base("Fireball", "Blast the enemy with a ball of concentrated fire.", 10, "enemy")
        {
        }

        public override void Execute(Character executor, List<Character> targets)
        {
            executor.CurrentMP -= this.MpCost;
            foreach(Character target in targets)
            {
                target.TakeDamage(25, "fire");
            }
        }
    }
}
