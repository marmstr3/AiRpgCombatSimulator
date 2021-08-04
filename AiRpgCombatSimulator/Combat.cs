using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AiRpgCombatSimulator.Characters;

namespace AiRpgCombatSimulator
{
    public partial class Combat : Form
    {
        private Character PlayerCharacter1;
        private Character PlayerCharacter2;
        private Character PlayerCharacter3;
        private Character PlayerCharacter4;
        private List<Character> PlayerCharacters;
        private Character Enemy;
        private List<PictureBox> CombatSelectors;
        private List<PictureBox> TurnIndicators;
        private int CurrentCharacterTurn;
        private int CurrentSelection;
        private bool Victory;
        private bool CombatComplete;

        public Combat()
        {
            /**
             * Default constructor. For testing purposes only.
             */
            // Form and Event Initialization
            InitializeComponent();
            this.KeyDown += Combat_KeyDown;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Combat_FormClosed);

            // Character Initialization
            this.PlayerCharacter1 = new Characters.Players.Fighter();
            this.PlayerCharacter2 = new Characters.Players.BlackMage();
            this.PlayerCharacter3 = new Characters.Players.Thief();
            this.PlayerCharacter4 = new Characters.Players.WhiteMage();
            this.PlayerCharacters = new List<Character>
            {
                this.PlayerCharacter1,
                this.PlayerCharacter2,
                this.PlayerCharacter3,
                this.PlayerCharacter4,
            };
            this.Enemy = new Characters.Enemies.Lich();

            // Selectors Initialization
            this.CombatSelectors = new List<PictureBox> 
            { 
                this.AttackSelector, 
                this.SpellsSelector, 
                this.SkillsSelector,
                this.ItemsSelector,
                this.DefendSelector,
                this.HelpSelector
            };
            this.TurnIndicators = new List<PictureBox>
            {
                this.TurnIndicator1,
                this.TurnIndicator2,
                this.TurnIndicator3,
                this.TurnIndicator4
            };

            // State Flags Initialization
            this.Victory = false;
            this.CombatComplete = false;

            // Initialize Form Values and Sprites
            this.InitializeHP();
            this.InitializeMP();
            this.IntializeSprites();

            // Initialize Selectors/Indicators
            this.InitializeSelectors();
            this.InitializeTurns();
        }

        private void Combat_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                this.Attack(this.PlayerCharacters[this.CurrentCharacterTurn], this.Enemy, this.EnemyHpValue);
            }
        }

        private void Attack(Character attacker, Character target, Label targetHpField)
        {
            attacker.Attack(target);
            this.UpdateHP(targetHpField, target.CurrentHP, target.MaxHP);
            
            if(this.Enemy.CurrentHP <= 0)
            {
                this.AttackLabel.Text = "YOU WIN";
            }
        }

        private void UpdateHP(Label hpField, int newHp, int maxHp)
        {
            hpField.Text = newHp + "/" + maxHp;
        }

        private void UpdateMP(Label mpField, int newMp, int maxMp)
        {
            // Note: Although identical in functionality as UpdateHP, this is
            // kept as a separate method to improve readability.
            mpField.Text = newMp + "/" + maxMp;
        }

        private void IntializeSprites()
        {
            this.PlayerSprite1.Image = this.PlayerCharacter1.Sprite;
            this.PlayerSprite2.Image = this.PlayerCharacter2.Sprite;
            this.PlayerSprite3.Image = this.PlayerCharacter3.Sprite;
            this.PlayerSprite4.Image = this.PlayerCharacter4.Sprite;
            this.EnemySprite.Image = this.Enemy.Sprite;
        }

        private void InitializeHP()
        {
            UpdateHP(this.HpValue1, this.PlayerCharacter1.MaxHP, this.PlayerCharacter1.MaxHP);
            UpdateHP(this.HpValue2, this.PlayerCharacter2.MaxHP, this.PlayerCharacter2.MaxHP);
            UpdateHP(this.HpValue3, this.PlayerCharacter3.MaxHP, this.PlayerCharacter3.MaxHP);
            UpdateHP(this.HpValue4, this.PlayerCharacter4.MaxHP, this.PlayerCharacter4.MaxHP);
            UpdateHP(this.EnemyHpValue, this.Enemy.MaxHP, this.Enemy.MaxHP);
        }

        private void InitializeMP()
        {
            UpdateMP(this.MpValue1, this.PlayerCharacter1.MaxMP, this.PlayerCharacter1.MaxMP);
            UpdateMP(this.MpValue2, this.PlayerCharacter2.MaxMP, this.PlayerCharacter2.MaxMP);
            UpdateMP(this.MpValue3, this.PlayerCharacter3.MaxMP, this.PlayerCharacter3.MaxMP);
            UpdateMP(this.MpValue4, this.PlayerCharacter4.MaxMP, this.PlayerCharacter4.MaxMP);
            UpdateMP(this.EnemyMpValue, this.Enemy.MaxMP, this.Enemy.MaxMP);
        }

        private void InitializeTurns()
        {
            foreach(PictureBox turnIndicator in this.TurnIndicators)
            {
                turnIndicator.Visible = false;
            }

            this.TurnIndicators[0].Visible = true;
            this.CurrentCharacterTurn = 0;
        }

        private void InitializeSelectors()
        {
            foreach (PictureBox selector in this.CombatSelectors)
            {
                selector.Visible = false;
            }

            this.CombatSelectors[0].Visible = true;
            this.CurrentSelection = 0;
        }

        private void Combat_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
