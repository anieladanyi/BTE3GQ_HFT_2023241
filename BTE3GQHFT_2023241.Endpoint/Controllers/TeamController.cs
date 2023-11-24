using BTE3GQ_HFT_2023241.Logic;
using BTE3GQ_HFT_2023241.Logic.Interfaces;
using BTE3GQ_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace BTE3GQHFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {

        ITeamLogic logic;

        public TeamController(ITeamLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Team> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Team Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Team value)
        {
            this.logic.Create(value);
        }

        [HttpPut("{id}")]
        public void Update([FromBody] Team value)
        {
            this.logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
