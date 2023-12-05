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
        Mock<IRepository<League>> mockLeaguerepo;
        [SetUp]
        public void Init()
        {
            mockLeaguerepo = new Mock<IRepository<League>>();
            var team = new Team("3,Real Madrid,4,3,1");
            team.Players.Add(new Player("7,3,Thibaut Courtois,GK,199,LEFT,31"));
            var league1 = new League("1, OTP Bank liga, Hungarian, 12");
            league1.Teams.Add(team);
            mockLeaguerepo.Setup(x => x.ReadAll()).Returns(new List<League>()
            {
                league1,
                new League("2, Eredvise, Netherland, 12"),
                new League("3, SPL, Saudi Arabian, 12")
            }.AsQueryable());
            leaguelogic = new LeagueLogic(mockLeaguerepo.Object);
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
            Assert.AreEqual(leaguelogic.AllTeamsAvgHeight(), 199);
        }
        [Test]
        public void LeageWithAgedPlayerTest()
        {
            List<League> list = leaguelogic.LeageWithAgedPlayer(30);
            string tem = list.First().Name;
            Assert.AreEqual(tem, " OTP Bank liga");
        }

        public voi
    }
}