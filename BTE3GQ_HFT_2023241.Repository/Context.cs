using BTE3GQ_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.IO;
using System.Numerics;

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
                //string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\football.mdf;Integrated Security=True;MultipleActiveResultSets=true";
                optionsBuilder.UseLazyLoadingProxies().UseInMemoryDatabase("out");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<League>(League => League
            //    .HasOne(League => League.Teams)
            //    .WithMany(Teams => Teams.Leagues)
            //    .HasForeignKey(League => League.TeamsId)
            //    .OnDelete(DeleteBehavior.Cascade));

            //modelBuilder.Entity<Player>()
            //    .HasMany(x => x.Leagues)
            //    .WithMany(x => x.Players)
            //    .UsingEntity<Role>(
            //        x => x.HasOne(x => x.League)
            //            .WithMany().HasForeignKey(x => x.LeagueId).OnDelete(DeleteBehavior.Cascade),
            //        x => x.HasOne(x => x.Player)
            //            .WithMany().HasForeignKey(x => x.PlayerId).OnDelete(DeleteBehavior.Cascade));

            //modelBuilder.Entity<Team>()
            //    .HasOne(r => r.Player)
            //    .WithMany(Player => Player.Roles)
            //    .HasForeignKey(r => r.PlayerId)
            //    .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<League>().HasData(new League[]
            {
                new League("1,Ligue 1,France,2"),
                new League("2,Premier League,England,2"),
                new League("3,LaLiga,Spain,2"),
                new League("4,Bundesliga,Germany,2"),
            });

            modelBuilder.Entity<Team>().HasData(new Team[]
            {
                   new Team("1,PSG,4,1"),
                new Team("2,Manchester United,3,2"),
                new Team("3,Real Madrid,4,3"),
                new Team("4,Barcelona,4,3"),
                new Team("5,Bayern München,2,4"),
                new Team("6,Newcastle,3,2"),
                new Team("7,Borussia Dortmund,3,4"),
                new Team("8,AS Monaco,3,1"),

            });

            modelBuilder.Entity<Player>().HasData(new Player[]
            {
                new Player("1,1,Kylian Mbappé,AM(RL),180,RIGHT,24"),
                new Player("2,1,Corrêa Marquinhos,D(C),183,RIGHT,29"),
                new Player("3,1,Achraf Hakimi,M(RL),180,RIGHT,24"),
                new Player("4,2,Bruno Fernandes,AM(RC),179,RIGHT,29"),
                new Player("5,2,Carlos Casemiro,M(C),184,RIGHT,31"),
                new Player("6,2,Marcus Rashford,F(RLC),185,RIGHT,25"),
                new Player("7,3,Thibaut Courtois,GK,199,LEFT,31"),
                new Player("8,3,Vinícius Júnior,F(LC),176,RIGHT,23"),
                new Player("9,3,Luka Modrić,AM(C),174,BOTH,38"),
                new Player("10,3,Jude Bellingham,AM(RLC),185,RIGHT,20"),
                new Player("11,4,Robert Lewandowski,F(C),185,RIGHT,35"),
                new Player("12,4,Ilkay Gündoğan,AM(C),180,BOTH,33"),
                new Player("13,4,Marc-André Ter Stegen,GK,187,RIGHT,31"),
                new Player("14,4,Frenkie de Jong,M(C),181,RIGHT,26"),
                new Player("15,5,Harry Kane,F(C),188,RIGHT,30"),
                new Player("16,5,Manuel Neuer,GK,193,BOTH,37"),
                new Player("17,6,Bruno Guimarães,M(C),182,RIGHT,25"),
                new Player("18,6,Kieran Trippier,M(RL),177,RIGHT,33"),
                new Player("19,6,ven Botman,D(C),195,LEFT,23"),
                new Player("20,7,Mats Hummels,D(C),191,RIGHT,34"),
                new Player("21,7,Niklas Süle,D(RC),195,RIGHT,28"),
                new Player("22,7,Marcel Sabitzer,AM(RLC),177,RIGHT,29"),
                new Player("23,8,Denis Zakaria,M(C),191,RIGHT,26"),
                new Player("24,8,Breel Embolo,F(RLC),187,RIGHT,26"),
                new Player("25,8,Aleksandr Golovin,AM(RLC),180,RIGHT,27"),
                new Player("26,1,Ousmane Dembélé,F(RLC),178,BOTH,26")
            });


        }
    }
}
