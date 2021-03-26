using Microsoft.EntityFrameworkCore;
using VedaSystem.Domain.Models;
using VedaSystem.Infra.Data.Mappings;

namespace VedaSystem.Infra.Data.Context
{
    public class TerapiaPrincipalContext : DbContext
    {
        public TerapiaPrincipalContext(DbContextOptions<TerapiaPrincipalContext> options) : base(options)
        {
        }
        public DbSet<TerapiaPrincipal> TerapiasPrincipais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TerapiaPrincipalMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
