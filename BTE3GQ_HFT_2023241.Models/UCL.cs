using BTE3GQ_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTE3GQ_HFT_2023241.Client
{
    public class UCL
    {
        [Key]
        public int UCLID { get; set; }
        public int Year { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
        public string Winner { get; set; }

        public UCL()
        {
            
        }

    }
}
