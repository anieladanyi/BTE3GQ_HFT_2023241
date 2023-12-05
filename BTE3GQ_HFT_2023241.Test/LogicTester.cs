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
            mockLeaguerepo.Setup(x => x.ReadAll()).Returns(new List<League>()
            {
                new League("1, OTP Bank liga, Hungarian, 12"),
                new League("2, Eredvise, Hungarian, 12"),
                new League("3, OTP Bank liga, Hungarian, 12"),
                new League("4, OTP Bank liga, Hungarian, 12"),

            }.AsQueryable());
            leaguelogic = new LeagueLogic(mockLeaguerepo.Object);
        }
        [Test]
        public void TeamWithOldestPlayersTest()
        {
            Team team = leaguelogic.TeamWithOldestPlayers();
            Assert.AreEqual(team, new Team("3,Real Madrid,4,3,1").UclID = 3);
        }
    }
}
