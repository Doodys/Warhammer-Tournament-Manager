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
    public partial class Form3 : Form
    {
        private int tID, pID, counter = 0, forFill = 0;
        public static List<int> _tables = new List<int>(); //below
        public static List<int> _pID = new List<int>(); //those 2 lists will be cleared after creating a game and merging them into _attributes
        public static int[,] _attributes = new int[(Player.playersAmount / 2), 3]; 

        Random rnd = new Random();

        public Form3()
        {
            InitializeComponent();
            Text = Player.gameName;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
           
        }

        private void FillLists()
        {
            for (int i = 1; i <= (Player.playersAmount / 2); i++) { _tables.Add(i); }
            for (int i = 1; i <= Player.playersAmount; i++) { _pID.Add(i); }
        }

        private void TableLogic()
        {
            FillLists();

            if(Player.playersAmount % 2 != 0)
            {
                Random rnd = new Random();
                int plID = rnd.Next(1, Player.playersAmount + 1);
                _pID.RemoveAt(_pID.IndexOf(plID));
                Player.oddPlayerID = plID;
            }
            while (counter < (Player.playersAmount / 2))
            {
                Random rnd = new Random();
                int x = 0;
            // draw tableID + delete from _tables, of it draw
            Repeat:
                int tableID = rnd.Next(1, (Player.playersAmount / 2) + 1);

                if (_tables.Contains(tableID))
                {
                    tID = tableID;
                    _tables.RemoveAt(_tables.IndexOf(tableID));
                    _attributes[counter, x] = tID;
                }
                else { goto Repeat; }

            // draw playerID + delete from _pID, if it draw
                for (int i = forFill; i < (forFill + 2); i++)
                {
                Repeat2:
                    int plID = rnd.Next(1, Player.playersAmount + 1);

                    if (_pID.Contains(plID))
                    {
                        x++;
                        pID = plID;
                        _pID.RemoveAt(_pID.IndexOf(plID));
                        _attributes[counter, x] = pID;
                    }
                    else { goto Repeat2; }
                }
                forFill += 2;
                counter++;
            }
        }

        private void TextAnimation()
        {
            //just aesthetic thing.. BUT VERY BEAUTIFUL, DO NOT DELETE PLOX
            label1.Text = "Creating tables";
            Player.Wait(600);
            label1.Text = "Creating tables .";
            Player.Wait(600);
            label1.Text = "Creating tables . .";
            Player.Wait(600);
            label1.Text = "Creating tables . . .";
            Player.Wait(600);
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form3_Shown(object sender, EventArgs e)
        {
            TableLogic();
            TextAnimation();
            this.Hide();
            Form4 InitializeData = new Form4();
            InitializeData.Show();
        }
    }
}
