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
    public partial class ClassDetails : Form
    {
        public ClassDetails()
        {
            InitializeComponent();
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ClassDetails_FormClosed);
            this.KeyDown += ClassDetails_KeyDown;
        }

        private void ClassDetails_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ClassDetails_KeyDown(object sender, KeyEventArgs e)
        {
            var nextForm = new Combat();
            nextForm.Show();
            this.Hide();
        }
    }
}
