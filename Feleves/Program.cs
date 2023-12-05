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
            var logic = new LeagueLogic(repo);

            var item = logic.ReadAll();
            var team = logic.TeamWithOldestPlayers();
            //var team = logic.TeamWithOldestPlayers();


            //NON CRUD METÓDUSOKBÓL MÉG CSAK 2 VAN

            //COMMITELJ!!!!!!!!!!!!!!!!!!!!!!!!!!!
        }
    }
}
