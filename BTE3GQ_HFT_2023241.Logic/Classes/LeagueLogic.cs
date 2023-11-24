using BTE3GQ_HFT_2023241.Repository;
using BTE3GQ_HFT_2023241.Models;
using System;
using System.Collections;
using System.IO;
using System.Linq;
using BTE3GQ_HFT_2023241.Logic.Interfaces;

namespace BTE3GQ_HFT_2023241.Logic.Classes
{
    public class LeagueLogic : ILeagueLogic
    {

        IRepository<League> repo;

        public LeagueLogic(IRepository<League> repo)
        {
            this.repo = repo;
        }

        public void Create(League item)
        {
            if (item.LeaguesCapacity < 1)
            {
                throw new ArgumentException("The league cannot be created, because the capacity is too low.");
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

        public League Read(int id)
        {
            return repo.Read(id);
        }

        public IQueryable<League> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(League item)
        {
            repo.Update(item);
        }

        public Team TeamWithOldestPlayers()
        {
            return repo.ReadAll().SelectMany(t => t.Teams).
                OrderByDescending(t => t.Players.Max(t => t.Age)).
                FirstOrDefault();
        }

        public double AllTeamsAvgHeight()
        {
            return repo.ReadAll()
           .SelectMany(league => league.Teams)
           .SelectMany(team => team.Players)
           .Average(player => player.Height);
        }
    }
}
