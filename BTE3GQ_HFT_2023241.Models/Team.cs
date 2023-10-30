using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BTE3GQ_HFT_2023241.Models
{
    public class Team
    {
        public int TeamID { get; set; }
        public string Name { get; set; }
        public int SquadDepth { get; set; }
        public ICollection<Player> Players { get; set; }
        public int LeagueID { get; set; }
        public Team()
        {
            
        }

        public Team(string info)
        {
            string[] split = info.Split(',');
            TeamID = int.Parse(split[0]);
            Name = split[1];
            SquadDepth = int.Parse(split[2]);
            LeagueID = int.Parse(split[3]);
        }
    }
}
