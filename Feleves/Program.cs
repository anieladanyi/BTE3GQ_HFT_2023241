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
        static void Create(string entity)
        {
            Console.WriteLine(entity + " create");
            Console.ReadLine();
        }

        static void List(string entity)
        {
            if (entity == "Player")
            {
                var items = playerlogic.ReadAll();
                Console.WriteLine("Id" + "\t" + "Name");
                foreach (var item in items)
                {
                    Console.WriteLine(item.PlayerID + "\t" + item.Name);
                }
            }
            Console.ReadLine();
        }

        static void Update(string entity)
        {
            Console.WriteLine(entity + " update");
            Console.ReadLine();
        }

        static void Delete(string entity)
        {
            Console.WriteLine(entity + " delete");
            Console.ReadLine();
        }
        static void Main(string[] args)
        {

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




//// static RestService rest;
////static void Create(string entity)
////{
////    if (entity == "Player")
////    {
////        Console.Write("Enter Player Name: ");
////        string name = Console.ReadLine();
////        rest.Post(new Player() { Name = name }, "player");
////    }
////}
////static void List(string entity)
////{
////    if (entity == "Player")
////    {
////        List<Player> players = rest.Get<Player>("player");
////        foreach (var item in players)
////        {
////            Console.WriteLine(item.PlayerID + ": " + item.Name);
////        }
////    }
////    Console.ReadLine();
////}
////static void Update(string entity)
////{
////    if (entity == "Player")
////    {
////        Console.Write("Enter Player's id to update: ");
////        int id = int.Parse(Console.ReadLine());
////        Player one = rest.Get<Player>(id, "player");
////        Console.Write($"New name [old: {one.Name}]: ");
////        string name = Console.ReadLine();
////        one.Name = name;
////        rest.Put(one, "player");
////    }
////}
////static void Delete(string entity)
////{
////    if (entity == "Player")
////    {
////        Console.Write("Enter Player's id to delete: ");
////        int id = int.Parse(Console.ReadLine());
////        rest.Delete(id, "palyer");
////    }
////}

////static void Main(string[] args)
////{
////    rest = new RestService("http://localhost:53910/", "league");

////    var actorSubMenu = new ConsoleMenu(args, level: 1)
////        .Add("List", () => List("Actor"))
////        .Add("Create", () => Create("Player"))
////        .Add("Delete", () => Delete("Player"))
////        .Add("Update", () => Update("Player"))
////        .Add("Exit", ConsoleMenu.Close);

////    var roleSubMenu = new ConsoleMenu(args, level: 1)
////        .Add("List", () => List("Team"))
////        .Add("Create", () => Create("Team"))
////        .Add("Delete", () => Delete("Team"))
////        .Add("Update", () => Update("Team"))
////        .Add("Exit", ConsoleMenu.Close);

////    var directorSubMenu = new ConsoleMenu(args, level: 1)
////        .Add("List", () => List("Director"))
////        .Add("Create", () => Create("Director"))
////        .Add("Delete", () => Delete("Director"))
////        .Add("Update", () => Update("Director"))
////        .Add("Exit", ConsoleMenu.Close);

////    var movieSubMenu = new ConsoleMenu(args, level: 1)
////        .Add("List", () => List("Movie"))
////        .Add("Create", () => Create("Movie"))
////        .Add("Delete", () => Delete("Movie"))
////        .Add("Update", () => Update("Movie"))
////        .Add("Exit", ConsoleMenu.Close);


////    var menu = new ConsoleMenu(args, level: 0)
////        .Add("Movies", () => movieSubMenu.Show())
////        .Add("Actors", () => actorSubMenu.Show())
////        .Add("Roles", () => roleSubMenu.Show())
////        .Add("Directors", () => directorSubMenu.Show())
////        .Add("Exit", ConsoleMenu.Close);

////    menu.Show();