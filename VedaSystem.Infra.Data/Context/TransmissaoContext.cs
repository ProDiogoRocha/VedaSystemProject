using Microsoft.EntityFrameworkCore;
using VedaSystem.Domain.Models;
using VedaSystem.Infra.Data.Mappings;

namespace VedaSystem.Infra.Data.Context
{
    public class TransmissaoContext : DbContext
    {
        public TransmissaoContext(DbContextOptions<TransmissaoContext> options) : base(options) { }

        public DbSet<Transmissao> Transmissoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TransmissaoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
