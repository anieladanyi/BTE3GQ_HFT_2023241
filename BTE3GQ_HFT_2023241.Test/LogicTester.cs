using BTE3GQ_HFT_2023241.Models;
using BTE3GQ_HFT_2023241.Logic.Classes;
using BTE3GQ_HFT_2023241.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTE3GQ_HFT_2023241.Test
{
    public class LogicTester
    {
        LeagueLogic leaguelogic;
        Mock<IRepository<League>> mockLeaguerepo;
        public void Init()
        {
            Mock<IRepository<League>> mockLeaguerepo = new Mock<IRepository<League>>();
            mockLeaguerepo.Setup(x => x.ReadAll()).Returns(new List<League>()
            {
                new League("1, OTP Bank liga, Hungarian, 12"),
                new League("2, Eredvise, Hungarian, 12"),
                new League("3, OTP Bank liga, Hungarian, 12"),
                new League("4, OTP Bank liga, Hungarian, 12"),

            }.AsQueryable());
            leaguelogic = new LeagueLogic(null);
        }
    }
}
