using BTE3GQ_HFT_2023241.Models;
using System.Linq;

namespace BTE3GQ_HFT_2023241.Logic.Interfaces
{
    public interface ITeamLogic
    {
        void Create(Team item);
        void Delete(int id);
        Team Read(int id);
        IQueryable<Team> ReadAll();
        void Update(Team item);
        Player PlayerById(int id);
    }
}