using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOn
{
    public class PlayerTask
    {
        public DateTime _dateTime { get; }
        public int _coins { get; }
        public int _xp { get; }
        public string _name { get; }
        public string _notes { get; }

        public bool _done { get; }

        public PlayerTask(DateTime dateTime, int coins, int xp, string name, string notes)
        {
            _dateTime = dateTime;
            _coins = coins;
            _xp = xp;
            _name = name;
            _notes = notes;
            _done = false;
        }
       
    }

    public static class PlayerData
    {
        public static string username { get; set; } = "Username";
        public static int coins { get; set; } = 10;
        public static int level { get; set; } = 1;
        public static int xp { get; set; } = 0;

        public static List<PlayerTask> playerTasks { get; set; } = new List<PlayerTask>();
    }
}
