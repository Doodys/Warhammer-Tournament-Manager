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
        public static List<int> winners = new List<int>();
        public static List<int> loosers = new List<int>();

        public static bool checkerForm4 = true;
        int rowNo, rowNo2;

        public int counterPlayer = 1;
        public static int winner, looser;

        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            checkerForm4 = true;

            for (int i = 0; i < Form4._playerFullData.GetLength(0); i++)
            {
                if (Form4.selectedTable.ToString() == Form4._playerFullData[i, 5])
                {
                    label1.Text = Form4._playerFullData[i, 1] + " " + Form4._playerFullData[i, 1];
                    rowNo = i;
                    break;
                }
            }

            for (int i = rowNo + 1; i < Form4._playerFullData.GetLength(0); i++)
            {
                if (Form4.selectedTable.ToString() == Form4._playerFullData[i, 5])
                {
                    label4.Text = Form4._playerFullData[i, 1] + " " + Form4._playerFullData[i, 1];
                    rowNo2 = i;
                    break;
                }
            }

            label5.Text = "Table " + Form4.selectedTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool checker = int.TryParse(textBox1.Text, out int num);
            if (textBox1.Text.Equals("")) { MessageBox.Show("Wrong input."); }
            else if (checker == false) { MessageBox.Show("Wrong input."); }
            else
            {
                if (checkBox1.Checked == true)
                {
                    num += Player._players[rowNo].playersPoints;
                    Player._players[rowNo].playersPoints = num;

                    for (int i = 0; i < Form3._attributes.GetLength(0); i++)
                    {
                        if (Form4.selectedTable == Form3._attributes[i, 0])
                        {
                            winner = Form3._attributes[i, 1];
                            winners.Add(winner);
                            looser = Form3._attributes[i, 2];
                            loosers.Add(looser);
                            break;
                        }
                    }  
                }
                else if (checkBox2.Checked == true)
                {
                    num += Player._players[rowNo2].playersPoints;
                    Player._players[rowNo2].playersPoints = num;

                    for (int i = 0; i < Form3._attributes.GetLength(0); i++)
                    {
                        if (Form4.selectedTable == Form3._attributes[i, 0])
                        {
                            winner = Form3._attributes[i, 2];
                            winners.Add(winner);
                            looser = Form3._attributes[i, 1];
                            loosers.Add(looser);
                            break;
                        }
                    }                 
                }

                checkerForm4 = false;
                this.Hide();
                Form4 InitializeData = new Form4();
                InitializeData.Show();
            }
        }


        private void Form5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { button1.PerformClick(); }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) { checkBox2.Enabled = false; }
            else { checkBox2.Enabled = true; }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true) { checkBox1.Enabled = false; }
            else { checkBox1.Enabled = true; }
        }

        //private void eraseTables()
        //{
        //    for (int i = 0; i < Player.playersAmount; i++)
        //        for (int j = 0; j < 7; j++)
        //        { Form4._playerFullData[i, j] = null; }
        //}

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
