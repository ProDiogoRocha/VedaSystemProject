using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VedaSystem.Domain.Models;

namespace VedaSystem.Infra.Data.Mappings
{
    public class ConteudoPtMap : IEntityTypeConfiguration<Tradutor>
    {
        public void Configure(EntityTypeBuilder<Tradutor> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Categoria)
                    .HasMaxLength(30)
                    .IsRequired();

            builder.Property(c => c.Texto)
                    .HasMaxLength(500)
                    .IsRequired();
        }
    }
}
