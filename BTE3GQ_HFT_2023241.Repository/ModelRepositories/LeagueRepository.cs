using BTE3GQ_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTE3GQ_HFT_2023241.Repository.ModelRepositories
{
    public class LeagueRepository : Repository<League>, IRepository<League>
    {
        public LeagueRepository(Context ctx) : base(ctx)
        {
        }

        public override League Read(int id)
        {
            return _context.Leagues.FirstOrDefault(t => t.Id == id);
        }

        public override void Update(League item)
        {
            var old = Read(item.Id);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            _context.SaveChanges();
        }
    }
}
