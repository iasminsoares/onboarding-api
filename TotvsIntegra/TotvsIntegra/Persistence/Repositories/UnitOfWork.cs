using IntegraApi.Application.Domain.Repositories;
using IntegraApi.Application.Persistence.Context;

namespace IntegraApi.Application.Persistence.Repositories
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        private readonly AppDbContext _context = context;

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
