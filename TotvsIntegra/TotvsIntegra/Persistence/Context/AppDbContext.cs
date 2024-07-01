using IntegraApi.Application.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace IntegraApi.Application.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        public virtual DbSet<Totver> Totvers { get; set; }
        public virtual DbSet<Atividade> Atividades { get; set; }
        public virtual DbSet<Onboarding> Onboardings { get; set; }
        public virtual DbSet<AtividadeOnboarding> AtividadesOnboardings { get; set; }
    }
}
