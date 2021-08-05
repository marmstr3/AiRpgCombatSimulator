using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AiRpgCombatSimulator.ComplexActions.Consumables;

namespace AiRpgCombatSimulator.Characters
{
    public partial class SkillSelection : Form
    {
        private readonly List<Label> _skillNames;
        public SkillSelection(List<Consumable> skills)
        {
            InitializeComponent();

            _skillNames = new List<Label>
            {
                this.SkillName1,
                this.SkillName2,
                this.SkillName3,
                this.SkillName4,
                this.SkillName5,
                this.SkillName6
            };

            for(int n=0; n<6; n++)
            {
                if (skills[n] != null)
                {
                    this._skillNames[n].Text = skills[n].Name;
                }
            }
        }
    }
}
