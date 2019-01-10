using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WHTournamentManager
{
    public partial class Form2 : Form
    {
        private int counter = 1, ID = 1;      

        public Form2()
        {
            InitializeComponent();
            Text = Player.gameName;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = "Player " + counter;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text1 = this.textBox1.Text;
            string text2 = this.textBox2.Text;
            string text3 = this.textBox3.Text;

            if (text1 == "" || text2 == "" || text3 == "") { MessageBox.Show("All fields have to be filled with text!"); }
            else
            {
                var newPlayer = new Player(
                    this.textBox1.Text,
                    this.textBox2.Text,
                    this.textBox3.Text,
                    ID,
                    0
                    );

                Player playerInfo = new Player(newPlayer);

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                ID++;

                counter++;
                label1.Text = "Player " + counter;
                textBox1.Select();             
            }
            if (counter > Player.playersAmount)
            {
                this.Hide();
                Form3 InitializeData = new Form3();
                InitializeData.Show();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { button1.PerformClick(); }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
