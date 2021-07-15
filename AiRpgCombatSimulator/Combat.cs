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
    public partial class Combat : Form
    {
        public Combat()
        {
            InitializeComponent();
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Combat_FormClosed);
        }

        private void Combat_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
