﻿using BTE3GQ_HFT_2023241.Models;
using System.Linq;

namespace BTE3GQ_HFT_2023241.Logic.Interfaces
{
    public interface ILeagueLogic
    {
        double AllTeamsAvgHeight();
        void Create(League item);
        void Delete(int id);
        League Read(int id);
        IQueryable<League> ReadAll();
        Team TeamWithOldestPlayers();
        void Update(League item);
    }
}