using IntegraApi.Application.Domain.Models;
using IntegraApi.Application.Domain.Repositories;
using IntegraApi.Application.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace IntegraApi.Application.Persistence.Repositories
{
    public class TotverRepository(AppDbContext context) : BaseRepository(context), ITotverRepository
    {
        public async Task<IEnumerable<Totver>> ListAsync()
      => await _context.Totvers.AsNoTracking().ToListAsync();

        public async Task<Totver?> GetByIdAsync(Guid id)
          => await _context.Totvers.FindAsync(id);

        public async Task AddAsync(Totver totver)
          => await _context.Totvers.AddAsync(totver);

        public void Update(Totver totver)
        {
            _context.Totvers.Update(totver);
        }

        public void Remove(Totver totver)
        {
            _context.Totvers.Remove(totver);
        }
    }
}
