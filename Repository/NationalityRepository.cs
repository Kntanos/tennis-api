using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class INationalityRepository : NationalityRepository
    {
        private readonly TennisContext _context;

        public INationalityRepository(TennisContext context)
        {
            _context = context;
        }

        public async Task<Nationality> Create(Nationality nationality)
        {
            _context.Nationalities.Add(nationality);
            await _context.SaveChangesAsync();

            return nationality;
        }

        public async Task Delete(int id)
        {
            var nationalityToDelete = await _context.Nationalities.FindAsync(id);
            _context.Nationalities.Remove(nationalityToDelete);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Nationality>> Get()
        {
            return await _context.Nationalities.ToListAsync();
        }

        public async Task<Nationality> Get(int id)
        {
            return await _context.Nationalities.FindAsync(id);
        }

        public async Task Update(Nationality nationality)
        {
            _context.Entry(nationality).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
