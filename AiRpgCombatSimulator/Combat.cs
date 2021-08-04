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
        private Character Enemy;

        public Combat()
        {
            /**
             * Default constructor. For testing purposes only.
             */

            InitializeComponent();
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Combat_FormClosed);
            this.PlayerCharacter1 = new Characters.Players.Fighter();
            this.PlayerCharacter2 = new Characters.Players.BlackMage();
            this.PlayerCharacter3 = new Characters.Players.Thief();
            this.PlayerCharacter4 = new Characters.Players.WhiteMage();
            this.Enemy = new Characters.Enemies.Lich();

            // Set Sprites
            this.PlayerSprite1.Image = this.PlayerCharacter1.Sprite;
            this.PlayerSprite2.Image = this.PlayerCharacter2.Sprite;
            this.PlayerSprite3.Image = this.PlayerCharacter3.Sprite;
            this.PlayerSprite4.Image = this.PlayerCharacter4.Sprite;
            this.EnemySprite.Image = this.Enemy.Sprite;

            // Set HP and MP
            UpdateHP(this.HpValue1, PlayerCharacter1.MaxHP, PlayerCharacter1.MaxHP);
            UpdateHP(this.HpValue2, PlayerCharacter2.MaxHP, PlayerCharacter2.MaxHP);
            UpdateHP(this.HpValue3, PlayerCharacter3.MaxHP, PlayerCharacter3.MaxHP);
            UpdateHP(this.HpValue4, PlayerCharacter4.MaxHP, PlayerCharacter4.MaxHP);
            UpdateHP(this.EnemyHpValue, Enemy.MaxHP, Enemy.MaxHP);

            UpdateMP(this.MpValue1, PlayerCharacter1.MaxMP, PlayerCharacter1.MaxMP);
            UpdateMP(this.MpValue2, PlayerCharacter2.MaxMP, PlayerCharacter2.MaxMP);
            UpdateMP(this.MpValue3, PlayerCharacter3.MaxMP, PlayerCharacter3.MaxMP);
            UpdateMP(this.MpValue4, PlayerCharacter4.MaxMP, PlayerCharacter4.MaxMP);
            UpdateMP(this.EnemyMpValue, Enemy.MaxMP, Enemy.MaxMP);
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

        private void Combat_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
