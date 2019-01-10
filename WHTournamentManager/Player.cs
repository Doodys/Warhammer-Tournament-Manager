using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WHTournamentManager
{
    internal class Player
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nation { get; set; }
        public static string gameName { get; set; }

        public static int playersAmount { get; set; }
        public int playersPoints { get; set; }
        public int playerID { get; set; }
        public int tableID { get; set; }
        public static int oddPlayerID { get; set; }

        public static List<Player> _players = new List<Player>();
        public static string[] _headers = {"ID", "NAME", "SURNAME", "NATION", "POINTS", "TABLE", "ALIVE?"};
        //public static Player oddPlayer;

        public Player(string nam, string surNam, string nat, int id, int points)
        {
            Name = nam;
            Surname = surNam;
            Nation = nat;
            playerID = id;
            playersPoints = points;
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
            System.DateTime start = System.DateTime.Now;
            while ((System.DateTime.Now - start).TotalMilliseconds < ms)
            {
                Application.DoEvents();
            }
        }
    }
}