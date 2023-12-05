using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using BTE3GQ_HFT_2023241.Client;
using BTE3GQ_HFT_2023241.Models;
using ConsoleTools;
namespace Feleves
{
    internal class Program
    {
        static RestService rest;
     
        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:26594/", "League");
            CrudMethodService cr = new CrudMethodService(rest);
            var playerSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => cr.List<Player>())
                .Add("Create", () => cr.Create<Player>())
                .Add("Delete", () => cr.Delete<Player>())
                .Add("Update", () => cr.Update<Player>())
                .Add("Exit", ConsoleMenu.Close);

            var teamSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => cr.List<Team>())
                .Add("Create", () => cr.Create<Team>())
                .Add("Delete", () => cr.Delete<Team>())
                .Add("Update", () => cr.Update<Team>())
                .Add("Exit", ConsoleMenu.Close);

            //var leagueSubMenu = new ConsoleMenu(args, level: 1)
            //    .Add("List", () => List("League"))
            //    .Add("Create", () => Create("League"))
            //    .Add("Delete", () => Delete("League"))
            //    .Add("Update", () => Update("League"))
            //    .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                //.Add("Leagues", () => leagueSubMenu.Show())
                .Add("Teams", () => teamSubMenu.Show())
                .Add("Players", () => playerSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }
    }
}
