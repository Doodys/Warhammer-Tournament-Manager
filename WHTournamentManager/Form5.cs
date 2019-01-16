using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WHTournamentManager
{
    public partial class Form5 : Form
    {
        public static int counterRound = 1;
        public List<string> _state = new List<string>();
        public string state;

        private bool checker = true;
        private int oddCheck = 1, counterPlayer = 1;

        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            eraseTables();

        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { button1.PerformClick(); }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void eraseTables()
        {
            for(int i = 0; i < Player.playersAmount; i++) { Form4._playerFullData[i, 5] = ""; }
        }
    }
}
