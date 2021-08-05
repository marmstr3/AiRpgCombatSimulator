using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AiRpgCombatSimulator.Characters;

namespace AiRpgCombatSimulator.ComplexActions.Consumables
{
    public abstract class Consumable: ComplexAction
    {
        public int Quantity { get; set; }

        public Consumable(string name, string description, int initialQuantity) :
            base(name, description)
        {
            this.Quantity = initialQuantity;
        }
    }
}
