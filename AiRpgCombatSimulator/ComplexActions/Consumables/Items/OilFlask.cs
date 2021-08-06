using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AiRpgCombatSimulator.Characters;

namespace AiRpgCombatSimulator.ComplexActions.Consumables.Items
{
    class OilFlask: Consumable
    {
        public OilFlask():
            base("Oil Flask",
                 "(Permanent) Target takes double damage from fire-based attacks for duration of effect.",
                 1
                )
        {
        }

        public override void Execute(Character executor, List<Character> targets)
        {
            foreach(Character target in targets)
            {
                target.IsOiled = true;
                this.Quantity -= 1;
            }
            
        }

    }
}
