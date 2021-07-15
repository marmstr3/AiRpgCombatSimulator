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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            this.KeyDown += MainMenu_KeyDown;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(MainMenu_FormClosed);
        }

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        // FOR TESTING ONLY. Remove.
        private void MainMenu_KeyDown(object sender, KeyEventArgs e)
        {
            label1.Text = "Button Pressed";
            var nextForm = new CharacterSelect();
            nextForm.Show();
            this.Hide();
        }
    }
}
