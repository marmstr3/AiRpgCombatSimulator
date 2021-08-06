using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AiRpgCombatSimulator.Characters;

namespace AiRpgCombatSimulator.ComplexActions
{
    public abstract class ComplexAction
    {
        public readonly string Name;
        public readonly string Description;

        public ComplexAction(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }
        
        public abstract void Execute(Character executor, List<Character> targets);
    }
}
