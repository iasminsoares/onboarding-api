using IntegraApi.Application.Domain.Models;
using IntegraApi.Application.Domain.Repositories;
using IntegraApi.Application.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace IntegraApi.Application.Persistence.Repositories
{
    public class AtividadeOnboardingRepository(AppDbContext context) : BaseRepository(context), IAtividadeOnboardingRepository
    {
        public async Task<IEnumerable<AtividadeOnboarding>> ListAsync()
      => await _context.AtividadesOnboardings.AsNoTracking().ToListAsync();

        public async Task<AtividadeOnboarding?> GetByIdAsync(Guid id)
          => await _context.AtividadesOnboardings.FindAsync(id);

        public async Task AddAsync(AtividadeOnboarding entity)
          => await _context.AtividadesOnboardings.AddAsync(entity);

        public void Update(AtividadeOnboarding entity)
        {
            _context.AtividadesOnboardings.Update(entity);
        }

        public void Remove(AtividadeOnboarding entity)
        {
            _context.AtividadesOnboardings.Remove(entity);
        }
    }
}
