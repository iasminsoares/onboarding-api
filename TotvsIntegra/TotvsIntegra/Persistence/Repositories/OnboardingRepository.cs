using IntegraApi.Application.Domain.Models;
using IntegraApi.Application.Domain.Repositories;
using IntegraApi.Application.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace IntegraApi.Application.Persistence.Repositories
{
    public class OnboardingRepository(AppDbContext context) : BaseRepository(context), IOnboardingRepository
    {
        // "AsNoTracking" tells Entity Framework that it is not necessary to track changes for listed entities. This makes code run faster.
        public async Task<IEnumerable<Onboarding>> ListAsync()
          => await _context.Onboardings.AsNoTracking().ToListAsync();

        public async Task<Onboarding?> GetByIdAsync(Guid id)
          => await _context.Onboardings.FindAsync(id);

        public async Task AddAsync(Onboarding entity)
          => await _context.Onboardings.AddAsync(entity);

        public void Update(Onboarding entity)
        {
            _context.Onboardings.Update(entity);
        }

        public void Remove(Onboarding entity)
        {
            _context.Onboardings.Remove(entity);
        }

    }
}
