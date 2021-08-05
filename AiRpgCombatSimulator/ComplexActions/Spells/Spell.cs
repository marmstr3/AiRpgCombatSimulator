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

        public Spell(string name, string description, int mpCost): 
            base(name, description)
        {
            this.MpCost = mpCost;
        }
    }
}
