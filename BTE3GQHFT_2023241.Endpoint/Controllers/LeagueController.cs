using BTE3GQ_HFT_2023241.Logic.Interfaces;
using BTE3GQ_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BTE3GQHFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LeagueController : ControllerBase
    {

        ILeagueLogic logic;

        public LeagueController(ILeagueLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<League> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public League Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] League value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Update([FromBody] League value)
        {
            this.logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
        [HttpGet("TeamWithOldestPlayers")]
        public Team TeamWithOldestPlayers()
        {
           return this.logic.TeamWithOldestPlayers();
        }
        [HttpGet("AllTeamsAvgHeight")]
        public double AllTeamsAvgHeight()
        {
            return this.logic.AllTeamsAvgHeight();
        }
        [HttpGet("LeageWithAgedPlayer")]
        public List<League> LeageWithAgedPlayer(int age)
        {
            return this.logic.LeageWithAgedPlayer(age);
        }
        [HttpGet("LeaguesWithMostMidfielders")]
        public List<League> LeaguesWithMostMidfielders()
        {
            return this.logic.LeaguesWithMostMidfielders();
        }
        [HttpGet("TheTallestPlayersAge")]
        public int TheTallestPlayersAge()
        {
            return this.logic.TheTallestPlayersAge();
        }
        [HttpGet("TheSmallestPlayersAge")]
        public int TheSmallestPlayersAge()
        { 
            return this.logic.TheSmallestPlayersAge();
        }
    }
}
