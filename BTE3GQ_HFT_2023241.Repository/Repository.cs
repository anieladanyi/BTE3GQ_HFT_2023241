using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTE3GQ_HFT_2023241.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected Context _context;
        public Repository(Context ctx)
        {
            _context = ctx;
        }
        public void Create(T item)
        {
            _context.Set<T>().Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Set<T>().Remove(Read(id));
            _context.SaveChanges();
        }

        public abstract T Read(int id);

        public IQueryable<T> ReadAll()
        {
            return _context.Set<T>();
        }

        public abstract void Update(T item);
    }
}
