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
using AiRpgCombatSimulator.ComplexActions.Consumables;
using AiRpgCombatSimulator.ComplexActions.Spells;

namespace AiRpgCombatSimulator
{
    public partial class Combat : Form
    {
        private readonly Character PlayerCharacter1;
        private readonly Character PlayerCharacter2;
        private readonly Character PlayerCharacter3;
        private readonly Character PlayerCharacter4;
        private readonly List<Character> PlayerCharacters;
        private readonly Character Enemy;
        private readonly List<PictureBox> CombatSelectors;
        private readonly List<PictureBox> TurnIndicators;
        private readonly List<Label> CharacterHpLabels;
        private readonly List<Label> CharacterMpLabels;
        private int CurrentCharacterTurn;
        private Character _currentCharacter;
        private int CurrentSelection;
        private int _selectedItem;
        private int _selectedSpell;
        private string _targetType;
        private readonly Random RandomGenerator;

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

            this.CharacterHpLabels = new List<Label>
            {
                this.HpValue1,
                this.HpValue2,
                this.HpValue3,
                this.HpValue4
            };
            this.CharacterMpLabels = new List<Label>
            {
                this.MpValue1,
                this.MpValue2,
                this.MpValue3,
                this.MpValue4
            };

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

            this.RandomGenerator = new Random();

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
            switch (e.KeyCode)
            {
                case Keys.Space:
                    if(this.CurrentSelection == 5)
                    {
                        // Don't process turn if user selects HELP
                        this.ExecuteSelection();
                    }
                    else
                    {
                        this.ExecuteSelection();
                        this.IncrementTurn();
                        this.CheckTerminalConditions();
                    }

                    break;
                case Keys.Left:
                    this.ChangeCombatSelector("left");
                    break;
                case Keys.Right:
                    this.ChangeCombatSelector("right");
                    break;
                case Keys.Up:
                    this.ChangeCombatSelector("up");
                    break;
                case Keys.Down:
                    this.ChangeCombatSelector("down");
                    break;
            }
        }

        private void ExecuteSelection()
        {
            switch (this.CurrentSelection)
            {
                case 0:
                    this.Attack(this._currentCharacter, this.Enemy, this.EnemyHpValue);
                    break;
                case 1:
                    using (var spellSelection = new SpellSelection(this._currentCharacter.Spells))
                    {
                        spellSelection.ShowDialog();
                        this._targetType = spellSelection.TargetType;
                        this._selectedSpell = spellSelection.Selection;
                    }
                    Spell spell = this._currentCharacter.Spells[this._selectedSpell];
                    if(this._currentCharacter.CurrentMP >= spell.MpCost)
                    {
                        this.CastSpell(this._currentCharacter.Spells[this._selectedSpell], this._targetType);
                    }
                    break;
                case 2:
                    using (var skillSelection = new SkillSelection(this._currentCharacter.Skills))
                    {
                        
                    }
                    this.UseSkill();
                    break;
                case 3:
                    using (var itemSelection = new ItemSelection(this._currentCharacter.Items))
                    {
                        itemSelection.ShowDialog();
                        this._targetType = "enemy";
                        this._selectedItem = itemSelection.Selection;
                    }
                    Consumable item = this._currentCharacter.Items[this._selectedItem];
                    if(item.Quantity > 0)
                    {
                        this.UseItem(this._currentCharacter.Items[this._selectedItem], this._currentCharacter, this._targetType);
                    }
                    break;
                case 4:
                    this.Defend(this._currentCharacter);
                    break;
                case 5:
                    this.Help();
                    break;
            }
        }

        private void ChangeCombatSelector(string direction)
        {
            switch (direction){
                case "left":
                    if (!this.CurrentSelectionIsLeftmost())
                    {
                        this.MoveSelector(this.CurrentSelection - 2);
                    }
                    break;
                case "right":
                    if (!this.CurrentSelectionIsRightmost())
                    {
                        this.MoveSelector(this.CurrentSelection + 2);
                    }
                    break;
                case "up":
                    if (!this.CurrentSelectionIsUpmost())
                    {
                        this.MoveSelector(this.CurrentSelection - 1);
                    }
                    break;
                case "down":
                    if (!this.CurrentSelectionIsDownmost())
                    {
                        this.MoveSelector(this.CurrentSelection + 1);
                    }
                    break;
            }
        }

        private bool CurrentSelectionIsLeftmost()
        {
            return this.CurrentSelection == 0 || this.CurrentSelection == 1;
        }

        private bool CurrentSelectionIsRightmost()
        {
            return this.CurrentSelection == 4 || this.CurrentSelection == 5;
        }

        private bool CurrentSelectionIsUpmost()
        {
            // Upper row selections are even.
            return this.CurrentSelection % 2 == 0;
        }

        private bool CurrentSelectionIsDownmost()
        {
            // Lower row selections are odd.
            return this.CurrentSelection % 2 == 1;
        }

        private void MoveSelector(int selectorIndex)
        {
            this.CombatSelectors[this.CurrentSelection].Visible = false;
            this.CurrentSelection = selectorIndex;
            this.CombatSelectors[this.CurrentSelection].Visible = true;
        }

        private void Attack(Character attacker, Character target, Label targetHpField)
        {
            attacker.Attack(target);
            this.UpdateHP(targetHpField, target.CurrentHP, target.MaxHP);
        }

        private void CastSpell(Spell spell, string target_type)
        {
            List<Character> targets = null;
            switch (target_type)
            {
                case "enemy":
                    targets = new List<Character> { this.Enemy };
                    break;
                case "allies":
                    targets = this.PlayerCharacters;
                    break;
            }
            spell.Execute(this._currentCharacter, targets);
            
        }

        private void UseSkill()
        {

        }

        private void UseItem(Consumable item, Character user, string target_type)
        {
            List<Character> targets = null;
            switch (target_type)
            {
                case "enemy":
                    targets = new List<Character> { this.Enemy };
                    break;
                case "allies":
                    targets = this.PlayerCharacters;
                    break;
            }
            item.Execute(user, targets);
        }

        private void Defend(Character defendingCharacter)
        {
            defendingCharacter.IsDefending = true;
        }

        private void Help()
        {
            var userManual = new UserManual();
            userManual.Show();
        }

        private void CheckTerminalConditions()
        {
            if(this.Enemy.IsDead && this.AreAllPlayersDead())
            {
                //this.AttackLabel.Text = "You have won, but at what cost?";
                this.RunGameOver("You have won, but at what cost?");
            } else if (this.Enemy.IsDead)
            {
                this.RunGameOver("YOU WIN!");
            } else if (this.AreAllPlayersDead())
            {
                this.RunGameOver("You have lost...");
            }
        }

        private void RunGameOver(string gameOverMessage) 
        {
            var nextForm = new GameOver(gameOverMessage);
            nextForm.Show();
            this.Hide();
        }

        private bool AreAllPlayersDead()
        {
            foreach(Character player in this.PlayerCharacters)
            {
                if(player.IsDead == false)
                {
                    return false;
                }
            }
            return true;
        }

        private void IncrementTurn()
        {
            do
            {
                if (this.CurrentCharacterTurn == 3)
                {
                    this.ProcessEnemyTurn();
                    this.TurnIndicators[this.CurrentCharacterTurn].Visible = false;
                    this.CurrentCharacterTurn = 0;
                    this.SetupNewTurn();
                }
                else
                {
                    this.TurnIndicators[this.CurrentCharacterTurn].Visible = false;
                    this.CurrentCharacterTurn++;
                    this.SetupNewTurn();
                }
            } while (this.PlayerCharacters[CurrentCharacterTurn].IsDead && !this.AreAllPlayersDead());
        }

        private void SetupNewTurn()
        {
            this.UpdateAllHP();
            this.UpdateAllMP();
            this._currentCharacter = this.PlayerCharacters[this.CurrentCharacterTurn];
            this.TurnIndicators[this.CurrentCharacterTurn].Visible = true;
            this.MoveSelector(0);
            this._currentCharacter.IsDefending = false;
        }

        private void ProcessEnemyTurn()
        {
            // Figure out random int generator and create list of hp labels for player characters for the class.
            int targetIndex = this.RandomGenerator.Next(0, 4);
            this.Attack(this.Enemy, PlayerCharacters[targetIndex], CharacterHpLabels[targetIndex]);
        }

        private void UpdateHP(Label hpField, int newHp, int maxHp)
        {
            hpField.Text = newHp + "/" + maxHp;
        }

        private void UpdateAllHP()
        {
            for(int n=0; n<4; n++)
            {
                UpdateHP(this.CharacterHpLabels[n], this.PlayerCharacters[n].CurrentHP, this.PlayerCharacters[n].MaxHP);
            }

            UpdateHP(this.EnemyHpValue, this.Enemy.CurrentHP, this.Enemy.MaxHP);

            
        }

        private void UpdateAllMP()
        {
            for(int n=0; n<4; n++)
            {
                UpdateMP(this.CharacterMpLabels[n], this.PlayerCharacters[n].CurrentMP, this.PlayerCharacters[n].MaxMP);
            }

            UpdateMP(this.EnemyMpValue, this.Enemy.CurrentMP, this.Enemy.MaxMP);
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
            this._currentCharacter = this.PlayerCharacters[this.CurrentCharacterTurn];
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
