using AiRpgCombatSimulator.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiRpgCombatSimulator.ComplexActions.Spells
{
    public class Empower: Spell
    {
        public Empower():
            base("Empower", "All ally attacks do 1.5x damage for one turn.", 10, "allies")
        {

        }

        public override void Execute(Character executor, List<Character> targets)
        {
            executor.CurrentMP -= this.MpCost;
            foreach(Character target in targets)
            {
                target.IsEmpowered = true;
            }
            
        }
    }
}
