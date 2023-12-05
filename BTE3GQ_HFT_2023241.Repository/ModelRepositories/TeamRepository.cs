using BTE3GQ_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTE3GQ_HFT_2023241.Repository
{
    public class TeamRepository : Repository<Team>, IRepository<Team>
    {
        public TeamRepository(Context ctx) : base(ctx)
        {
        }

        public override Team Read(int id)
        {
            return _context.Teams.FirstOrDefault(t => t.TeamID == id);
        }

        public override void Update(Team item)
        {
            var old = Read(item.TeamID);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            _context.SaveChanges();
        }
    }
}
