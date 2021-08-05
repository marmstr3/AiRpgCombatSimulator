using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using AiRpgCombatSimulator.ComplexActions.Consumables;
using AiRpgCombatSimulator.ComplexActions.Consumables.Items;
using AiRpgCombatSimulator.ComplexActions.Spells;

namespace AiRpgCombatSimulator.Characters
{
    public abstract class Character
    {
        #region Fields
        public readonly Image Sprite;
        private readonly string _name;
        private readonly int _maxHP;
        private readonly int _maxMP;
        private bool _isDead;
         
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

        public bool IsDead
        {
            get
            {
                return _isDead;
            }
            set
            {
                throw new InvalidOperationException();
            }
        }

        public int AttackPower { get; set; }
        public int CurrentHP { get; set; }
        public int CurrentMP { get; set; }
        public bool IsDefending { get; set; }
        public bool IsOiled { get; set; }
        public List<Consumable> Items { get; set; }
        public List<Consumable> Skills { get; set; }
        public List<Spell> Spells { get; set; }
        #endregion
        #region Constructors
        public Character(string name, int maxHP, int maxMP, int attack_power, Image sprite)
        {
            this._name = name;
            this._maxHP = maxHP;
            this._maxMP = maxMP;
            this.CurrentHP = this._maxHP;
            this.CurrentMP = this._maxMP;
            this._isDead = false;
            this.IsDefending = false;
            this.IsOiled = false;

            this.AttackPower = attack_power;
            this.Sprite = sprite;
        }
        #endregion
        #region Methods
        public void Attack(Character target)
        {
            target.TakeDamage(this.AttackPower);
        }

        public void TakeDamage(int damage, string damageType = null)
        {
            if (this.IsDefending)
            {
                damage /= 2;
            }

            if (this.IsOiled && damageType == "fire")
            {
                damage *= 2;
            }

            this.CurrentHP -= damage;

            if(this.CurrentHP <= 0)
            {
                this._isDead = true;
            }
        }
        #endregion
    }
}
