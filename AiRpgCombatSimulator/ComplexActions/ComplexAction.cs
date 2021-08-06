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
        private readonly string _name;
        private readonly string _description;

        public string Name { get { return this._name; } }
        public string Description { get { return this._description; } }

        public ComplexAction(string name, string description)
        {
            this._name = name;
            this._description = description;
        }
        
        public abstract void Execute(Character executor, List<Character> targets);
    }
}
