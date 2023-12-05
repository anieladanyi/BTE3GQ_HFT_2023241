using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using BTE3GQ_HFT_2023241.Models;
using ConsoleTools;
namespace Feleves
{
    internal class Program
    {
        static RestService rest;
        static void Create(string entity)
        {
            if (entity == "Player")
            {
                Console.WriteLine("Enter Player Name: ");
                string name = Console.ReadLine();
                rest.Post(new Player { Name = name }, "player");
            }
            Console.ReadLine();
        }

        static void List(string entity)
        {
            if (entity == "Player")
            {
                List<Player> players = rest.Get<Player>("player");
                foreach (var item in players)
                {
                    Console.WriteLine(item.PlayerID + ": " + item.Name);
                }
            }
            Console.ReadLine();
        }

        static void Update(string entity)
        {
            if (entity == "Player")
            {
                Console.WriteLine("Enter Player's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Player one = rest.Get<Player>(id, "player");
                Console.WriteLine($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "player");
            }
        }

        static void Delete(string entity)
        {
            if (entity == "Player")
            {
                Console.WriteLine("Enter Player's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "player");
            }
        }




        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:26594/", "League");

            var playerSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Player"))
                .Add("Create", () => Create("Player"))
                .Add("Delete", () => Delete("Player"))
                .Add("Update", () => Update("Player"))
                .Add("Exit", ConsoleMenu.Close);

            var teamSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Team"))
                .Add("Create", () => Create("Team"))
                .Add("Delete", () => Delete("Team"))
                .Add("Update", () => Update("Team"))
                .Add("Exit", ConsoleMenu.Close);

            var leagueSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("League"))
                .Add("Create", () => Create("League"))
                .Add("Delete", () => Delete("League"))
                .Add("Update", () => Update("League"))
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Leagues", () => leagueSubMenu.Show())
                .Add("Teams", () => teamSubMenu.Show())
                .Add("Players", () => playerSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }
    }
}
