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
    public partial class GameOver : Form
    {
        public GameOver(string gameOverMessage)
        {
            InitializeComponent();
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(GameOver_FormClosed);
            this.GameOverMessage.Text = gameOverMessage;
        }

        private void GameOver_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
