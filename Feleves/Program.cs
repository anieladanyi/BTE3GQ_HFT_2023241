using System;
using System.Linq;
using BTE3GQ_HFT_2023241.Logic.Classes;
using BTE3GQ_HFT_2023241.Models;
using BTE3GQ_HFT_2023241.Repository;
using BTE3GQ_HFT_2023241.Repository.ModelRepositories;

namespace Feleves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();
            
            var items = context.Players.ToArray();
            var repo = new LeagueRepository(context);
            var repo1 = new TeamRepository(context);
            var logic = new LeagueLogic(repo);
            var logict = new TeamLogic(repo1);

            var item = logic.ReadAll();
            var team = logic.TeamWithOldestPlayers();
            var height = logic.AllTeamsAvgHeight();
            var lig = logic.LeageWithAgedPlayer(30);
            var player = logict.PlayerById(1);
            ;
        }
    }
}
