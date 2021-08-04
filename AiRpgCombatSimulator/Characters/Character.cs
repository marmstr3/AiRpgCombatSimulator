using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AiRpgCombatSimulator.Characters
{
    public abstract class Character
    {
        #region Fields
        public readonly Image Sprite;
        private string _name;
        private int _maxHP;
        private int _maxMP;
         
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                throw new InvalidOperationException();
            }
        }
        public int MaxHP
        {
            get
            {
                return _maxHP;
            }
            set
            {
                throw new InvalidOperationException();
            }
        } 

        public int MaxMP
        {
            get
            {
                return _maxMP;
            }
            set
            {
                throw new InvalidOperationException();
            }
        }

        public int AttackPower { get; set; }
        public int CurrentHP { get; set; }
        public int CurrentMP { get; set; }
        #endregion
        #region Constructors
        public Character(string name, int maxHP, int maxMP, int attack_power, Image sprite)
        {
            this._name = name;
            this._maxHP = maxHP;
            this._maxMP = maxMP;
            this.AttackPower = attack_power;
            this.Sprite = sprite;
        }
        #endregion
        #region Methods
        public void Attack(Character target)
        {
            target.TakeDamage(this.AttackPower);
        }

        public void TakeDamage(int damage)
        {
            this.CurrentHP -= damage;
        }
        #endregion
    }
}
