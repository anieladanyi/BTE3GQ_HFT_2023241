using BTE3GQ_HFT_2023241.Logic.Interfaces;
using BTE3GQ_HFT_2023241.Models;
using BTE3GQ_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTE3GQ_HFT_2023241.Logic.Classes
{
    public class PlayerLogic : IPlayerLogic
    {
        IRepository<Player> repo;

        public PlayerLogic(IRepository<Player> repo)
        {
            this.repo = repo;
        }

        public void Create(Player item)
        {
            if (item.Age > 17)
            {
                throw new ArgumentException("The team cannot be created because the squad depth should be at least 2");
            }
            else
            {
                repo.Create(item);
            }
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public Player Read(int id)
        {
            return repo.Read(id);
        }

        public IQueryable<Player> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Player item)
        {
            repo.Update(item);
        }
    }
}
