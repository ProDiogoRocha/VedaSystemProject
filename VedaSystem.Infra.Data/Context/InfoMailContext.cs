using Microsoft.EntityFrameworkCore;
using VedaSystem.Domain.Models;
using VedaSystem.Infra.Data.Mappings;

namespace VedaSystem.Infra.Data.Context
{
    public class InfoMailContext : DbContext
    {
        public InfoMailContext(DbContextOptions<InfoMailContext> options) : base(options)
        {
        }
        public DbSet<InfoMail> InfoMails { get; set; }
         
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new InfoMailMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
