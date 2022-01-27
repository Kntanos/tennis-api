using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class IPlayerRepository : PlayerRepository
    {
        private readonly TennisContext _context;

        public IPlayerRepository(TennisContext context)
        {
            _context = context;
        }

        public async Task<Entities.Player> Create(Entities.Player player)
        {
            _context.Players.Add(player);
            await _context.SaveChangesAsync();

            return player;
        }

        public async Task Delete(int id)
        {
            var playerToDelete = await _context.Players.FindAsync(id);
            _context.Players.Remove(playerToDelete);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Entities.Player>> Get()
        {
            return await _context.Players.ToListAsync();
        }

        public async Task<Entities.Player> Get(int id)
        {
            return await _context.Players.FindAsync(id);
        }

        public async Task Update(Entities.Player player)
        {
            _context.Entry(player).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
