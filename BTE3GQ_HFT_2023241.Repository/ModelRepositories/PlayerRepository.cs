using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE3GQ_HFT_2023241.Models;

namespace BTE3GQ_HFT_2023241.Repository
{
    public class PlayerRepository : Repository<Player>, IRepository<Player>
    {
        public PlayerRepository(Context ctx) : base(ctx)
        {
        }

        public override Player Read(int id)
        {
            return _context.Players.FirstOrDefault(t => t.PlayerID == id);
        }

        public override void Update(Player item)
        {
            var old = Read(item.PlayerID);
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
