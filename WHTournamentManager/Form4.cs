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
    public partial class Form4 : Form
    {
        public static List<int> counterList = new List<int>();
        public static string[,] _playerFullData = new string[Player.playersAmount, 7];
        public static int counterRound = 1, selectedTable;
        public int infoID = 0;
        public string infoName = "";
        public string infoSurname = "";
        public string infoNation = "";
        public int infoPoints = 0;
        public int infoTable = 0;
        public string infoState = "";

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            Text = Player.gameName + " - Round " + counterRound;

            if (Form5.winners.Count.Equals(0))
            {
                for (int i = 0; i < Form3._attributes.GetLength(0); i++) { counterList.Add(Form3._attributes[i, 0]); }
            }

            counterList.Remove(selectedTable);

            for (int i = 0; i < counterList.Count; i++) { comboBox1.Items.Add(counterList[i]); }

            if (counterRound.Equals(1))
            {
                GenerateFullTable(Player.playersAmount + 1);
            }
            GenerateVsTable(Form3._attributes.GetLength(0) + 1);

            if (Form5.winners.Count.Equals(Player.playersAmount / 2)) { button2.Visible = true; }
            else { button2.Visible = false; }

            if (!Form5.winners.Count.Equals(Player.playersAmount / 2))
            {
                button1.Visible = true;
                comboBox1.Visible = true;
            }
            else
            {
                button1.Visible = false;
                comboBox1.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1 && !comboBox1.Items.Equals(0))
            {
                selectedTable = int.Parse(comboBox1.Text);

                this.Hide();
                Form5 InitializeData = new Form5();
                InitializeData.Show();
            }
            else MessageBox.Show("Select table!");
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void GenerateVsTable(int rowCount)
        {
            int columnCount = 3;
            tableLayoutPanel2.Controls.Clear();
            tableLayoutPanel2.ColumnStyles.Clear();
            tableLayoutPanel2.RowStyles.Clear();

            tableLayoutPanel2.ColumnCount = columnCount;
            tableLayoutPanel2.RowCount = rowCount;

            for (int x = 0; x < columnCount; x++)
            {
                tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

                for (int y = 0; y < rowCount; y++)
                {
                    if (x == 0) { tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.AutoSize)); }
                    if (y == 0)
                    {
                        Label lb = new Label()
                        {
                            AutoSize = false,
                            TextAlign = ContentAlignment.MiddleCenter,
                            Dock = DockStyle.None
                        };
                        lb.Font = new Font(lb.Font, FontStyle.Bold);
                        lb.Text = string.Format(Player._headers2[x]);
                        tableLayoutPanel2.Controls.Add(lb, x, y);
                    }
                    else
                    {
                        switch (x)
                        {
                            case 0:
                                Label b1 = new Label()
                                {
                                    AutoSize = false,
                                    TextAlign = ContentAlignment.MiddleCenter,
                                    Dock = DockStyle.None
                                };
                                b1.Text = Form3._attributes[y - 1, x].ToString();
                                tableLayoutPanel2.Controls.Add(b1, x, y);
                                break;
                            case 1:
                                Label lb2 = new Label()
                                {
                                    AutoSize = false,
                                    TextAlign = ContentAlignment.MiddleCenter,
                                    Dock = DockStyle.None
                                };
                                lb2.Text = Form3._attributes[y - 1, x].ToString();

                                for (int i = 0; i < Form5.winners.Count; i++)
                                {
                                    if (Form5.winners.Contains(int.Parse(lb2.Text)))
                                    {
                                        lb2.BackColor = Color.FromArgb(138, 205, 72);
                                    }
                                    else if (Form5.loosers.Contains(int.Parse(lb2.Text)))
                                    {
                                        lb2.BackColor = Color.FromArgb(138, 66, 72);
                                    }
                                }

                                tableLayoutPanel2.Controls.Add(lb2, x, y);
                                break;
                            case 2:
                                Label lb3 = new Label()
                                {
                                    AutoSize = false,
                                    TextAlign = ContentAlignment.MiddleCenter,
                                    Dock = DockStyle.None
                                };
                                lb3.Text = Form3._attributes[y - 1, x].ToString();

                                for (int i = 0; i < Form5.winners.Count; i++)
                                {
                                    if (Form5.winners.Contains(int.Parse(lb3.Text)))
                                    {
                                        lb3.BackColor = Color.FromArgb(138, 205, 72);
                                    }
                                    else if (Form5.loosers.Contains(int.Parse(lb3.Text)))
                                    {
                                        lb3.BackColor = Color.FromArgb(138, 66, 72);
                                    }
                                }

                                tableLayoutPanel2.Controls.Add(lb3, x, y);
                                break;
                            default: break;
                        }
                    }
                }
            }
        }

        private void GenerateFullTable(int rowCount)
        {
            int columnCount = 7;
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.RowStyles.Clear();

            tableLayoutPanel1.ColumnCount = columnCount;
            tableLayoutPanel1.RowCount = rowCount;

            for (int x = 0; x < columnCount; x++)
            {
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

                for (int y = 0; y < rowCount; y++)
                {
                    if (x == 0) { tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize)); }
                    if (y == 0)
                    {
                        Label lb = new Label()
                        {
                            AutoSize = false,
                            TextAlign = ContentAlignment.MiddleCenter,
                            Dock = DockStyle.None
                        };
                        lb.Font = new Font(lb.Font, FontStyle.Bold);
                        lb.Text = string.Format(Player._headers1[x]);
                        tableLayoutPanel1.Controls.Add(lb, x, y);
                    }
                    else
                    {
                        switch (x)
                        {
                            case 0:
                                Label lb1 = new Label()
                                {
                                    AutoSize = false,
                                    TextAlign = ContentAlignment.MiddleCenter,
                                    Dock = DockStyle.None
                                };
                                lb1.Text = Player._players[y - 1].playerID.ToString();
                                tableLayoutPanel1.Controls.Add(lb1, x, y);
                                infoID = Player._players[y - 1].playerID;
                                _playerFullData[y - 1, x] = infoID.ToString();
                                break;
                            case 1:
                                Label lb2 = new Label()
                                {
                                    AutoSize = false,
                                    TextAlign = ContentAlignment.MiddleCenter,
                                    Dock = DockStyle.None
                                };
                                lb2.Text = Player._players[y - 1].Name;
                                tableLayoutPanel1.Controls.Add(lb2, x, y);
                                infoName = lb2.Text = Player._players[y - 1].Name;
                                _playerFullData[y - 1, x] = infoName;
                                break;
                            case 2:
                                Label lb3 = new Label()
                                {
                                    AutoSize = false,
                                    TextAlign = ContentAlignment.MiddleCenter,
                                    Dock = DockStyle.None
                                };
                                lb3.Text = Player._players[y - 1].Surname;
                                tableLayoutPanel1.Controls.Add(lb3, x, y);
                                infoSurname = Player._players[y - 1].Surname;
                                _playerFullData[y - 1, x] = infoSurname;
                                break;
                            case 3:
                                Label lb4 = new Label()
                                {
                                    AutoSize = false,
                                    TextAlign = ContentAlignment.MiddleCenter,
                                    Dock = DockStyle.None
                                };
                                lb4.Text = Player._players[y - 1].Nation;
                                tableLayoutPanel1.Controls.Add(lb4, x, y);
                                infoNation = Player._players[y - 1].Nation;
                                _playerFullData[y - 1, x] = infoNation;
                                break;
                            case 4:
                                Label lb5 = new Label()
                                {
                                    AutoSize = false,
                                    TextAlign = ContentAlignment.MiddleCenter,
                                    Dock = DockStyle.None
                                };
                                if (Player._players[y - 1].playerID != Player.oddPlayerID)
                                {
                                    lb5.Text = Player._players[y - 1].playersPoints.ToString();
                                    tableLayoutPanel1.Controls.Add(lb5, x, y);
                                    infoPoints = Player._players[y - 1].playersPoints;
                                    _playerFullData[y - 1, x] = infoPoints.ToString();
                                }
                                else
                                {
                                    lb5.Text = (Player._players[y - 1].playersPoints + 15).ToString();
                                    tableLayoutPanel1.Controls.Add(lb5, x, y);
                                    infoPoints = Player._players[y - 1].playersPoints;
                                    _playerFullData[y - 1, x] = infoPoints.ToString();
                                }
                                break;
                            case 5:
                                Label lb6 = new Label()
                                {
                                    AutoSize = false,
                                    TextAlign = ContentAlignment.MiddleCenter,
                                    Dock = DockStyle.None
                                };
                                for (int i = 0; i < Form3._attributes.GetLength(0); i++)
                                {
                                    if (Form3._attributes[i, 1] == Player._players[y - 1].playerID)
                                    {
                                        lb6.Text = Form3._attributes[i, 0].ToString();
                                        tableLayoutPanel1.Controls.Add(lb6, x, y);
                                        infoTable = Form3._attributes[i, 0];
                                        _playerFullData[y - 1, x] = infoTable.ToString();
                                    }
                                    else if (Form3._attributes[i, 2] == Player._players[y - 1].playerID)
                                    {
                                        lb6.Text = Form3._attributes[i, 0].ToString();
                                        tableLayoutPanel1.Controls.Add(lb6, x, y);
                                        infoTable = Form3._attributes[i, 0];
                                        _playerFullData[y - 1, x] = infoTable.ToString();
                                    }
                                }
                                break;
                            case 6:
                                Label lb7 = new Label()
                                {
                                    AutoSize = false,
                                    TextAlign = ContentAlignment.MiddleCenter,
                                    Dock = DockStyle.None
                                };
                                if (Player._players[y - 1].playerID != Player.oddPlayerID)
                                {
                                    if (Form5.checkerForm4 == false)
                                    {
                                        for (int i = 0; i < _playerFullData.GetLength(0); i++)
                                        {
                                            if (Form5.winners.Contains(int.Parse(_playerFullData[y - 1, 0]))) { lb7.Text = "YES"; }
                                            else if (Form5.loosers.Contains(int.Parse(_playerFullData[y - 1, 0]))) { lb7.Text = "NO"; }
                                            else if (
                                                !Form5.winners.Contains(int.Parse(_playerFullData[y - 1, 0])) &&
                                                !Form5.loosers.Contains(int.Parse(_playerFullData[y - 1, 0]))) { lb7.Text = "YES"; }
                                        }
                                    }
                                    else { lb7.Text = "YES"; }
                                    tableLayoutPanel1.Controls.Add(lb7, x, y);
                                    infoState = lb7.Text;
                                    _playerFullData[y - 1, x] = infoState.ToString();
                                }
                                else
                                {
                                    lb7.Text = "Odd player";
                                    tableLayoutPanel1.Controls.Add(lb7, x, y);
                                    infoState = lb7.Text;
                                    _playerFullData[y - 1, x] = infoState.ToString();
                                }
                                break;
                            default: break;
                        }
                    }
                }
            }
        }
    }
}
