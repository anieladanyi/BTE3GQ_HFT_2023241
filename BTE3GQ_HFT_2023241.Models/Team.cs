using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
//using BTE3GQ_HFT_2023241.Client;

namespace BTE3GQ_HFT_2023241.Models
{
    public class Team
    {
        [Key]
        public int TeamID { get; set; }
        public string Name { get; set; }
        public int SquadDepth { get; set; }
        //public bool CurrentUclParticipation { get; set; }
        public virtual ICollection<Player> Players { get; set; }
        public int LeagueID { get; set; }
        [JsonIgnore]
        public virtual League League { get; set; }
        public int UclID { get; set; }
        public Team()
        {

        }

        public Team(string info)
        {
            Players = new HashSet<Player>();
            string[] split = info.Split(',');
            TeamID = int.Parse(split[0]);
            Name = split[1];
            SquadDepth = int.Parse(split[2]);
            LeagueID = int.Parse(split[3]);
            //if (int.Parse(split[4]) == 1)
            //{
            //    CurrentUclParticipation = true;
            //}
            //else
            //{
            //    CurrentUclParticipation = false;

            //}
        }
    }
}
