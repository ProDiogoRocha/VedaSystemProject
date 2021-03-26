using Microsoft.EntityFrameworkCore;
using VedaSystem.Domain.Models;
using VedaSystem.Infra.Data.Mappings;

namespace VedaSystem.Infra.Data.Context
{
    public class TratamentoContext : DbContext
    {
        public TratamentoContext(DbContextOptions<TratamentoContext> options) : base(options)
        {
        }

        public DbSet<Tratamento> Tratamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TratamentoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
