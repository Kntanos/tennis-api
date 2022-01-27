using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APITechTest.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly Repository.PlayerRepository _PlayerRepository;

        public PlayersController(PlayerRepository IPlayerRepository)
        {
            _PlayerRepository = IPlayerRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Player>> Get()
        {
            return await _PlayerRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> Get(int id)
        {
            return await _PlayerRepository.Get(id);
        }
    }
}
