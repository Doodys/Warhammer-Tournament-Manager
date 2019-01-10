using System;
using System.Windows.Forms;

namespace WHTournamentManager
{
    public partial class Start : Form
    {
        private bool checker = true;
        private bool checkIfClosedApp = true;

        public Start()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { button1.PerformClick(); }
        }
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { button1.PerformClick(); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string gameNam = "WarhammerApp";
            int amount = 0;

            if (checker)
            {
                gameNam = this.textBox1.Text;
                bool inputAmount = int.TryParse(this.textBox2.Text, out amount);

                if (gameNam == "") { MessageBox.Show("GAME needs a name, bro!"); }
                else if (inputAmount == false) { MessageBox.Show("Wrong AMOUNT input!"); }
                else if (amount < 2) { MessageBox.Show("AMOUNT has to be at least 2!"); }
                else
                {
                    checker = false;
                    checkIfClosedApp = false;
                    var newPlayer = new Player(gameNam, amount); 
                    this.Hide();
                    Form2 InitializeData = new Form2();
                    InitializeData.Show();
                }
            }
            else
            {
                var newPlayer = new Player(gameNam, amount);
                this.Hide();
                checkIfClosedApp = false;
                Form2 InitializeData = new Form2();
                InitializeData.Show();                
            }
        }

        private void Start_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (checkIfClosedApp)
            {
                Application.Exit();
            }
        }
    }
}
