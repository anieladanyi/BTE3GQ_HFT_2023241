using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTE3GQ_HFT_2023241.Client;
using BTE3GQ_HFT_2023241.Models;


namespace BTE3GQ_HFT_2023241.Repository
{
    internal class UCLRepository : Repository<UCL>, IRepository<UCL>
    {
        public UCLRepository(Context ctx) : base(ctx)
        {
        }
        public override UCL Read(int id)
        {
            return _context.UCLs.FirstOrDefault(t => t.Year == id);
        }

        public override void Update(UCL item)
        {
            var old = Read(item.Year);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            _context.SaveChanges();
        }
    }
}
