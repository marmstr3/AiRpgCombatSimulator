using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AiRpgCombatSimulator
{
    public partial class CharacterSelect : Form
    {
        public CharacterSelect()
        {
            InitializeComponent();
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CharacterSelect_FormClosed);
            this.KeyDown += CharacterSelect_KeyDown;
        }

        private void CharacterSelect_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void CharacterSelect_KeyDown(object sender, KeyEventArgs e)
        {
            var nextForm = new ClassDetails();
            nextForm.Show();
            this.Hide();
        }
    }
}
