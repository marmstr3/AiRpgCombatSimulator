using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AiRpgCombatSimulator.ComplexActions.Spells;

namespace AiRpgCombatSimulator
{
    public partial class SpellSelection : Form
    {
        private readonly List<Label> _spellNames;
        private readonly List<PictureBox> _selectors;
        public int Selection { get; set; }
        private int _currentSelection;
        public SpellSelection(List<Spell> spells)
        {
            InitializeComponent();
            this.KeyDown += SpellSelection_KeyDown;

            this._spellNames = new List<Label>
            {
                this.SpellName1,
                this.SpellName2,
                this.SpellName3,
                this.SpellName4,
                this.SpellName5,
                this.SpellName6
            };

            this._selectors = new List<PictureBox>
            {
                this.Selector1,
                this.Selector2,
                this.Selector3,
                this.Selector4,
                this.Selector5,
                this.Selector6
            };
            this.InitializeSelectors();

            for (int n = 0; n < 6; n++)
            {
                if (spells[n] != null)
                {
                    this._spellNames[n].Text = spells[n].Name;
                }
            }
        }

        private void SpellSelection_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    this.Selection = this._currentSelection;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    break;
                case Keys.Left:
                    this.ChangeSelector("left");
                    break;
                case Keys.Right:
                    this.ChangeSelector("right");
                    break;
                case Keys.Up:
                    this.ChangeSelector("up");
                    break;
                case Keys.Down:
                    this.ChangeSelector("down");
                    break;
            }

        }

        private void ChangeSelector(string direction)
        {
            switch (direction)
            {
                case "left":
                    if (!this.CurrentSelectionIsLeftmost())
                    {
                        this.MoveSelector(this._currentSelection - 2);
                    }
                    break;
                case "right":
                    if (!this.CurrentSelectionIsRightmost())
                    {
                        this.MoveSelector(this._currentSelection + 2);
                    }
                    break;
                case "up":
                    if (!this.CurrentSelectionIsUpmost())
                    {
                        this.MoveSelector(this._currentSelection - 1);
                    }
                    break;
                case "down":
                    if (!this.CurrentSelectionIsDownmost())
                    {
                        this.MoveSelector(this._currentSelection + 1);
                    }
                    break;
            }
        }

        private bool CurrentSelectionIsLeftmost()
        {
            return this._currentSelection == 0 || this._currentSelection == 1;
        }

        private bool CurrentSelectionIsRightmost()
        {
            return this._currentSelection == 4 || this._currentSelection == 5;
        }

        private bool CurrentSelectionIsUpmost()
        {
            // Upper row selections are even.
            return this._currentSelection % 2 == 0;
        }

        private bool CurrentSelectionIsDownmost()
        {
            // Lower row selections are odd.
            return this._currentSelection % 2 == 1;
        }

        private void MoveSelector(int selectorIndex)
        {
            this._selectors[this._currentSelection].Visible = false;
            this._currentSelection = selectorIndex;
            this._selectors[this._currentSelection].Visible = true;
        }

        private void InitializeSelectors()
        {
            foreach (PictureBox selector in this._selectors)
            {
                selector.Visible = false;
            }

            this._selectors[0].Visible = true;
            this._currentSelection = 0;
        }

    }
}

