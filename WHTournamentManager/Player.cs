using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WHTournamentManager
{
    internal class Player
    {
        //those variables kinda go in order of program's flow
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nation { get; set; }
        public static string gameName { get; set; }

        public static int playersAmount { get; set; }
        public int playersPoints { get; set; }
        public int playerID { get; set; }
        public int tableID { get; set; }
        public static int oddPlayerID { get; set; }

        public static List<Player> _players = new List<Player>(); //it'll be cleared after creating a game
        public static string[] _headers1 = {"ID", "NAME", "SURNAME", "NATION", "POINTS", "TABLE", "ALIVE?"};
        public static string[] _headers2 = { "TABLE", "ID [1]", "ID [2]" };

        public Player(string nam, string surNam, string nat, int id, int points, int table)
        {
            Name = nam;
            Surname = surNam;
            Nation = nat;
            playerID = id;
            playersPoints = points;
            tableID = table;
        }

        public Player(string gamNam, int am)
        {
            gameName = gamNam;
            playersAmount = am;
        }
      

        public Player(Player info)
        {
            _players.Add(info);
        }

        public static void Wait(int ms)
        {
            DateTime start = DateTime.Now;
            while ((DateTime.Now - start).TotalMilliseconds < ms)
            {
                Application.DoEvents();
            }
        }
    }
}