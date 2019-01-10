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
        public Form4()
        {
            InitializeComponent();
            Text = Player.gameName;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            GenerateTable(Player.playersAmount + 1);
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void GenerateTable(int rowCount)
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
                        Label lb = new Label();
                        lb.Font = new Font(lb.Font, FontStyle.Bold);
                        lb.Text = string.Format(Player._headers[x]);
                        tableLayoutPanel1.Controls.Add(lb, x, y);
                    }
                    else
                    {
                        switch (x)
                        {
                            case 0:
                                Label lb1 = new Label();
                                lb1.Text = Player._players[y - 1].playerID.ToString();
                                tableLayoutPanel1.Controls.Add(lb1, x, y); break;
                            case 1:
                                Label lb2 = new Label();
                                lb2.Text = Player._players[y - 1].Name;
                                tableLayoutPanel1.Controls.Add(lb2, x, y); break;
                            case 2:
                                Label lb3 = new Label();
                                lb3.Text = Player._players[y - 1].Surname;
                                tableLayoutPanel1.Controls.Add(lb3, x, y); break;
                            case 3:
                                Label lb4 = new Label();
                                lb4.Text = Player._players[y - 1].Nation;
                                tableLayoutPanel1.Controls.Add(lb4, x, y); break;
                            case 4:
                                Label lb5 = new Label();
                                if (Player._players[y - 1].playerID != Player.oddPlayerID)
                                {
                                    lb5.Text = Player._players[y - 1].playersPoints.ToString();
                                    tableLayoutPanel1.Controls.Add(lb5, x, y);
                                }
                                else
                                {
                                    lb5.Text = "15";
                                    tableLayoutPanel1.Controls.Add(lb5, x, y);
                                }
                                break;
                            case 5:
                                Label lb6 = new Label();
                                for (int i = 0; i < Form3._attributes.GetLength(0); i++)
                                {
                                    if (Form3._attributes[i, 1] == Player._players[y - 1].playerID)
                                    {
                                        lb6.Text = Form3._attributes[i, 0].ToString();
                                        tableLayoutPanel1.Controls.Add(lb6, x, y);
                                    }
                                    else if (Form3._attributes[i, 2] == Player._players[y - 1].playerID)
                                    {
                                        lb6.Text = Form3._attributes[i, 0].ToString();
                                        tableLayoutPanel1.Controls.Add(lb6, x, y);
                                    }
                                }
                                break;
                            case 6:
                                Label lb7 = new Label();
                                if (Player._players[y - 1].playerID != Player.oddPlayerID)
                                {
                                    lb7.Text = "YES";
                                    tableLayoutPanel1.Controls.Add(lb7, x, y);
                                }
                                else
                                {
                                    lb7.Text = "Odd player";
                                    tableLayoutPanel1.Controls.Add(lb7, x, y);
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
