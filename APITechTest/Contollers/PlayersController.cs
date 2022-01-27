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
        public async Task<IEnumerable<Player>> GetPlayers()
        {
            return await _PlayerRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetPlayers(int id)
        {
            return await _PlayerRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Player>> PostPlayer(Player player)
        {
            var newPlayer = await _PlayerRepository.Create(player);
            return CreatedAtAction(nameof(GetPlayers), new 
            { 
                id = newPlayer.Id,
                newPlayer.FirstName,
                newPlayer.LastName,
                newPlayer.Nationality,
                newPlayer.BirthDate,
                points = newPlayer.Points = 1200

            },newPlayer);
        }

        // Added rest of CRUD actions for completion
        [HttpPut]
        public async Task<ActionResult> PutBooks(int id, [FromBody] Player player)
        {
            if (id != player.Id)
            {
                return BadRequest();
            }

            await _PlayerRepository.Update(player);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var playerToDelete = await _PlayerRepository.Get(id);
            if (playerToDelete == null)
                return NotFound();

            await _PlayerRepository.Delete(playerToDelete.Id);
            return NoContent();
        }
    }
}
