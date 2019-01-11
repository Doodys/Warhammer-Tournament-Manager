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
        public static int counter = 1;
        public List<string> _state = new List<string>();
        public string state;

        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            _state.Add(state = "Won");
            _state.Add(state = "Defeated");
            label1.Text = Form4._playerFullData[0, 1] + " " + Form4._playerFullData[0, 2];
            button1.Select();
            comboBox1.DisplayMember = "state";
            comboBox1.DataSource = _state;
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
