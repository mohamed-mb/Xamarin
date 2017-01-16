using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhackAMonkey.Model
{
    public class Game
    {
        public int Level { get; set; }
        public long Score { get; set; }
        public string Status { get; set; }
        public string PlayerName { get; set; }

        public List<string> MonkeyImages { get; set; }
       // public string[] PlaygroundImages { get; set; }
        public int Timer { get; set; }
        public bool IsHit { get; set; }
        public Game()
        {
            MonkeyImages = new List<string>(); 
                       
        }
    }
}
