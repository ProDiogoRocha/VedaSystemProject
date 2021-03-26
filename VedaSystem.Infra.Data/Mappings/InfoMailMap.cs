using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VedaSystem.Domain.Models;

namespace VedaSystem.Infra.Data.Mappings
{
    public class InfoMailMap : IEntityTypeConfiguration<InfoMail>
    {
        public void Configure(EntityTypeBuilder<InfoMail> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.TerapeutaId);
            builder.Property(e => e.Lido);
        }
    }
}
