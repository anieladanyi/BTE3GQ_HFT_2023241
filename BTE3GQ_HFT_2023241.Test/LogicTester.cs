using BTE3GQ_HFT_2023241.Models;
using BTE3GQ_HFT_2023241.Logic.Classes;
using BTE3GQ_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using static System.Net.WebRequestMethods;

namespace BTE3GQ_HFT_2023241.Test
{
    [TestFixture]
    public class LogicTester
    {
        LeagueLogic leaguelogic;
        TeamLogic teamlogic;
        Mock<IRepository<League>> mockLeaguerepo;
        Mock<IRepository<Team>> mockTeamrepo;

        [SetUp]
        public void Init()
        {
            mockLeaguerepo = new Mock<IRepository<League>>();
            mockTeamrepo = new Mock<IRepository<Team>>();
            var team = new Team("3,Real Madrid,4,3,1");
            team.Players.Add(new Player("7,3,Thibaut Courtois,GK,199,LEFT,31"));
            var league1 = new League("1, OTP Bank liga, Hungarian, 12");
            var team1 = new Team("1,PSG,3,2,1");
            team1.Players.Add(new Player("5,1,Vitinha,M(C),179,LEFT,23"));
            league1.Teams.Add(team);
            league1.Teams.Add(team1);
            mockLeaguerepo.Setup(x => x.ReadAll()).Returns(new List<League>()
            {
                league1,
                new League("2, Eredvise, Netherland, 12"),
                new League("3, SPL, Saudi Arabian, 12")
            }.AsQueryable());
            leaguelogic = new LeagueLogic(mockLeaguerepo.Object);
            Team b = (new Team("3,Real Madrid,4,3,1"));
            mockTeamrepo.Setup(x => x.ReadAll()).Returns(new List<Team>()
            {
                b,
                new Team("1,PSG,3,2,1")
            }.AsQueryable());
            teamlogic = new TeamLogic(mockTeamrepo.Object);
        }
        [Test]
        public void TeamWithOldestPlayersTest()
        {
            string team = leaguelogic.TeamWithOldestPlayers().Name;
            string name = "Real Madrid";
            Assert.AreEqual(team, name);
        }
        [Test]
        public void AllTeamsAvgHeightTest()
        {
            Assert.AreEqual(leaguelogic.AllTeamsAvgHeight(), 189);
        }
        [Test]
        public void LeageWithAgedPlayerTest()
        {
            List<League> list = leaguelogic.LeageWithAgedPlayer(30);
            string tem = list.First().Name;
            Assert.AreEqual(tem, " OTP Bank liga");
        }
        [Test]
        public void LeaguesWithMostMidfielders()
        {
            List<League> list = leaguelogic.LeaguesWithMostMidfielders();
            string tem = list.First().Name;
            Assert.AreEqual(tem, " OTP Bank liga");
        }

        [Test]
        public void TallestPlayersAgeTest()
        {
            int age = leaguelogic.TheTallestPlayersAge();
            Assert.That(age, Is.EqualTo(31));
        }
        [Test]
        public void CreateLeagueTestWithIncorrectCapacity()
        {
            var league = new League() { LeaguesCapacity = 0 };
            try
            {
                leaguelogic.Create(league);
            }
            catch 
            {
            }

            mockLeaguerepo.Verify(r => r.Create(league), Times.Never);
        }
        [Test]
        public void CreateLeagueTestWithCorrectCapacity()
        {
            var league = new League() { LeaguesCapacity = 2 };
            leaguelogic.Create(league);
            mockLeaguerepo.Verify(r => r.Create(league), Times.Once);
        }
        [Test]
        public void CreateTeamTestWithIncorrectCapacity()
        {
            var team = new Team() { SquadDepth = 1 };
            try
            {
                teamlogic.Create(team);
            }
            catch
            {
            }
            mockTeamrepo.Verify(r => r.Create(team), Times.Never);
        }
        [Test]
        public void CreateTeamTestWithCorrectCapacity()
        {
            var team = new Team() { SquadDepth = 4 };
            teamlogic.Create(team);
            mockTeamrepo.Verify(r => r.Create(team), Times.Once);
        }

        [Test]
        public void SmallestPlayerAgeTest()
        {
            int age = leaguelogic.TheSmallestPlayersAge();
            Assert.That(age, Is.EqualTo(23));
        }
    }
}