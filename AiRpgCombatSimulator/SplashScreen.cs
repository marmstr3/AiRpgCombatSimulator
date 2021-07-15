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
    public partial class SplashScreen : Form
    {

        public SplashScreen()
        {
            InitializeComponent();
            this.KeyDown += SplashScreen_KeyDown;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SplashScreen_FormClosed);
        }

        private void SplashScreen_KeyDown(object sender, KeyEventArgs e)
        {
            var nextForm = new MainMenu();
            nextForm.Show();
            this.Hide();
        }

        private void SplashScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
