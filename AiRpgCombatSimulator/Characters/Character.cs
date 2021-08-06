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
        public readonly string Name;
        public readonly int MaxHP;
        public readonly int MaxMP;
        private bool _isDead;

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
        public bool IsEmpowered { get; set; }
        public List<Consumable> Items { get; set; }
        public List<Consumable> Skills { get; set; }
        public List<Spell> Spells { get; set; }
        #endregion

        #region Constructors
        public Character(string name, int maxHP, int maxMP, int attackPower, Image sprite)
        {
            this.Name = name;
            this.MaxHP = maxHP;
            this.MaxMP = maxMP;
            this.CurrentHP = this.MaxHP;
            this.CurrentMP = this.MaxMP;
            this._isDead = false;
            this.IsDefending = false;
            this.IsOiled = false;
            this.IsEmpowered = false;

            this.AttackPower = attackPower;
            this.Sprite = sprite;
        }
        #endregion

        #region Methods
        public void Attack(Character target)
        {
            if (this.IsEmpowered)
            {
                target.TakeDamage(2 * this.AttackPower);
            }
            else
            {
                target.TakeDamage(this.AttackPower);
            }
            
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
