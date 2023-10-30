using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTE3GQ_HFT_2023241.Models
{
    public class Player
    {
        public int PlayerID { get; set; }
        public int TeamID { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int Height { get; set; }
        public string Foot { get; set; }
        public int Age { get; set; }
        public Player()
        {
            
        }
        public Player(string info)
        {
            string[] lines = info.Split(',');
            PlayerID = int.Parse(lines[0]);
            TeamID = int.Parse(lines[1]);
            Name = lines[2];
            Position = lines[3];
            Height = int.Parse(lines[4]);
            Foot = lines[5];
            Age = int.Parse(lines[6]);
        }

    }
}
