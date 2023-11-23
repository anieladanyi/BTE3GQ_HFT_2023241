using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Globalization;

namespace BTE3GQ_HFT_2023241.Models
{
    public class League
    {
        public virtual ICollection<Team> Teams { get; set; }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LeaguesNation { get; set; }
        public int LeaguesCapacity { get; set; }
        public League()
        {
            
        }
        public League(string info)
        {
            string[] lines = info.Split(',');
            Id = int.Parse(lines[0]);
            Name = lines[1];
            LeaguesNation = lines[2];
            LeaguesCapacity = int.Parse(lines[3]);
        }
    }
}
