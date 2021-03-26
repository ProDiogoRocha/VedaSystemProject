using Microsoft.EntityFrameworkCore;
using VedaSystem.Domain.Models;
using VedaSystem.Infra.Data.Mappings;

namespace VedaSystem.Infra.Data.Context
{
    public class PrescricaoContext : DbContext
    {
        public PrescricaoContext(DbContextOptions<PrescricaoContext> options) : base(options)
        {
        }
        public DbSet<Prescricao> Prescricoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PrescricaoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
