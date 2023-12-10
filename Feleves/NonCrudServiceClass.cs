using BTE3GQ_HFT_2023241.Models;
using Feleves;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace BTE3GQ_HFT_2023241.Client
{
    public class NonCrudServiceClass
    {
        private RestService rest;

        public NonCrudServiceClass(RestService rest)
        {
            this.rest = rest;
        }
        public void LeageWithAgedPlayer()
        {
            Console.WriteLine("Type an age: ");
            int age = int.Parse(Console.ReadLine());
            string endpoint = $"League/LeageWithAgedPlayer?age={age}";

            var result = rest.GetSingle<List<League>>(endpoint);

            foreach (var item in result)
            {
                Console.WriteLine($"League: {item.Name}");
            }
            Console.WriteLine();
            Console.ReadLine();
        }
        public void PlayerById()
        {
            Console.WriteLine("Type an ID number:");
            int ide = int.Parse(Console.ReadLine());
            string endpoint = $"Team/PlayerById?id={ide}";

            var result = rest.GetSingle<Player>(endpoint);

            Console.WriteLine($"Player: {result.Name}");
            Console.ReadLine();
        }
        public void TeamWithOldestPlayers()
        {
            string endpoint = "League/TeamWithOldestPlayers";

            var result = rest.GetSingle<Team>(endpoint);
            Console.WriteLine("Oldest team: " + result.Name);

            Console.ReadLine();
        }
        public void AllTeamsAvgHeight()
        {
            string endpoint = "League/AllTeamsAvgHeight";

            var result = rest.GetSingle<double>(endpoint);

            Console.WriteLine("All teams avg height: " + result);

            Console.ReadLine();
        }

        public void LeaguesWithMostMidfielders() 
        {
            string endpoint = "League/LeaguesWithMostMidfielders";

            var result = rest.GetSingle<List<League>>(endpoint);
            foreach (var item in result)
            {
                Console.WriteLine($"Leagues: {item.Name}");
            }
            Console.WriteLine();
            Console.ReadLine();
        }

        public void TheTallestPlayersAge()
        {
            string endpoint = "League/TheTallestPlayersAge";

            var result = rest.GetSingle<int>(endpoint);

            Console.WriteLine("The tallest players age: " + result);
            Console.ReadLine();
        }

        public void TheSmallestPlayersAge()
        {
            string endpoint = "League/TheSmallestPlayersAge";

            var result = rest.GetSingle<int>(endpoint);

            Console.WriteLine("The smallest players age: " + result);
            Console.ReadLine();

        }

    }
}
