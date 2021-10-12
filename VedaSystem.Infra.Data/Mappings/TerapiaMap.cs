using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VedaSystem.Domain.Models;

namespace VedaSystem.Infra.Data.Mappings
{
    public class TerapiaMap : IEntityTypeConfiguration<Terapia>
    {
        public void Configure(EntityTypeBuilder<Terapia> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.NomeTerapia)
                .HasMaxLength(50);

            builder.Property(t => t.Duracao);

            builder.HasMany(t => t.Materiais)
                .WithOne(m => m.Terapia)
                .HasForeignKey(m => m.TerapiaId);

            builder.Property(t => t.Observacao)
                .HasMaxLength(300);

            builder.Property(t => t.Ativo);
        }
    }
}
