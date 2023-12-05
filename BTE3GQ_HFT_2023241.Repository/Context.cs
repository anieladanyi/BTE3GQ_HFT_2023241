using BTE3GQ_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Numerics;
using System.Reflection.Emit;

namespace BTE3GQ_HFT_2023241.Repository
{
    public class Context : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Team> Teams { get; set; }

        public Context()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseInMemoryDatabase("out");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().HasOne(t => t.Team).WithMany(t => t.Players).HasForeignKey(t => t.TeamID);
            modelBuilder.Entity<Team>().HasOne(t => t.League).WithMany(t => t.Teams).HasForeignKey(t => t.LeagueID);

            var france = new League("1,Ligue 1,France,2");
            var english = new League("2,Premier League,England,2");
            var spain = new League("3,LaLiga,Spain,2");
            var german = new League("4,Bundesliga,Germany,2");

            var leagues = new List<League>();
            leagues.Add(france);
            leagues.Add(english);
            leagues.Add(spain);
            leagues.Add(german);


            var psg = new Team("1,PSG,4,1,1"); psg.UclID = 2;
            var manutd = new Team("2,Manchester United,3,2,2"); manutd.UclID = 4;
            var real = new Team("3,Real Madrid,4,3,1"); real.UclID = 3;
            var bar = new Team("4,Barcelona,4,3,1");
            var bay = new Team("5,Bayern München,2,4,1"); bay.UclID = 1;
            var newc = new Team("6,Newcastle,3,2,1");
            var dor = new Team("7,Borussia Dortmund,3,4,1");
            var mon = new Team("8,AS Monaco,3,1,1");
            var teams = new List<Team>();

            teams.Add(psg);
            teams.Add(manutd);
            teams.Add(real);
            teams.Add(bar);
            teams.Add(bay);
            teams.Add(newc);
            teams.Add(dor);
            teams.Add(mon);



            var mbappe = new Player("1,1,Kylian Mbappé,AM(RL),180,RIGHT,24");
            var marquinhos = new Player("2,1,Corrêa Marquinhos,D(C),183,RIGHT,29");
            var hakimi = new Player("3,1,Achraf Hakimi,M(RL),180,RIGHT,24");
            var bruno = new Player("4,2,Bruno Fernandes,AM(RC),179,RIGHT,29");
            var casemiro = new Player("5,2,Carlos Casemiro,M(C),184,RIGHT,31");
            var rashford = new Player("6,2,Marcus Rashford,F(RLC),185,RIGHT,25");
            var courtois = new Player("7,3,Thibaut Courtois,GK,199,LEFT,31");
            var vinicius = new Player("8,3,Vinícius Júnior,F(LC),176,RIGHT,23");
            var modric = new Player("9,3,Luka Modrić,AM(C),174,BOTH,38");
            var bellingham = new Player("10,3,Jude Bellingham,AM(RLC),185,RIGHT,20");
            var lewandowski = new Player("11,4,Robert Lewandowski,F(C),185,RIGHT,35");
            var gundogan = new Player("12,4,Ilkay Gündoğan,AM(C),180,BOTH,33");
            var terstegen = new Player("13,4,Marc-André Ter Stegen,GK,187,RIGHT,31");
            var dejong = new Player("14,4,Frenkie de Jong,M(C),181,RIGHT,26");
            var kane = new Player("15,5,Harry Kane,F(C),188,RIGHT,30");
            var neuer = new Player("16,5,Manuel Neuer,GK,193,BOTH,37");
            var guinmares = new Player("17,6,Bruno Guimarães,M(C),182,RIGHT,25");
            var trippier = new Player("18,6,Kieran Trippier,M(RL),177,RIGHT,33");
            var botman = new Player("19,6,ven Botman,D(C),195,LEFT,23");
            var hummels = new Player("20,7,Mats Hummels,D(C),191,RIGHT,34");
            var sule = new Player("21,7,Niklas Süle,D(RC),195,RIGHT,28");
            var sabitzer = new Player("22,7,Marcel Sabitzer,AM(RLC),177,RIGHT,29");
            var zakaria = new Player("23,8,Denis Zakaria,M(C),191,RIGHT,26");
            var embolo = new Player("24,8,Breel Embolo,F(RLC),187,RIGHT,26");
            var golovin = new Player("25,8,Aleksandr Golovin,AM(RLC),180,RIGHT,27");
            var dembele = new Player("26,1,Ousmane Dembélé,F(RLC),178,BOTH,26");


            var players = new List<Player>();
            players.Add(mbappe);
            players.Add(marquinhos);
            players.Add(hakimi);
            players.Add(bruno);
            players.Add(casemiro);
            players.Add(rashford);
            players.Add(courtois);
            players.Add(vinicius);
            players.Add(modric);
            players.Add(bellingham);
            players.Add(lewandowski);
            players.Add(gundogan);
            players.Add(terstegen);
            players.Add(dejong);
            players.Add(kane);
            players.Add(neuer);
            players.Add(guinmares);
            players.Add(trippier);
            players.Add(botman);
            players.Add(hummels);
            players.Add(sule);
            players.Add(sabitzer);
            players.Add(zakaria);
            players.Add(embolo);
            players.Add(golovin);
            players.Add(dembele);

            //var uclteams = new List<Team>();

            //foreach (var team in teams)
            //{
            //    if (team.CurrentUclParticipation == true)
            //    {
            //        uclteams.Add(team);
            //    }
            //}


            modelBuilder.Entity<Player>().HasData(players);
            modelBuilder.Entity<League>().HasData(leagues);
            modelBuilder.Entity<Team>().HasData(teams);

        }
    }
}