using BTE3GQ_HFT_2023241.Models;
using System.Linq;

namespace BTE3GQ_HFT_2023241.Logic.Interfaces
{
    public interface IPlayerLogic
    {
        void Create(Player item);
        void Delete(int id);
        Player Read(int id);
        IQueryable<Player> ReadAll();
        void Update(Player item);
    }
}