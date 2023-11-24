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
    public class TeamLogic : ITeamLogic
    {
        IRepository<Team> repo;

        public TeamLogic(IRepository<Team> repo)
        {
            this.repo = repo;
        }

        public void Create(Team item)
        {
            if (item.SquadDepth < 2)
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

        public Team Read(int id)
        {
            return repo.Read(id);
        }

        public IQueryable<Team> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Team item)
        {
            repo.Update(item);
        }

    }
}
