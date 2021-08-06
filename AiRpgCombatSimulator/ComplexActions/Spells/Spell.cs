using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiRpgCombatSimulator.ComplexActions.Spells
{
    public abstract class Spell: ComplexAction
    {
        public readonly int MpCost;
        public readonly string Target;

        public Spell(string name, string description, int mpCost, string target): 
            base(name, description)
        {
            this.MpCost = mpCost;
            this.Target = target;
        }
    }
}
