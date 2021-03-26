using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VedaSystem.Domain.Models;

namespace VedaSystem.Infra.Data.Mappings
{
    public class MedicamentoMap : IEntityTypeConfiguration<Medicamento>
    {
        public void Configure(EntityTypeBuilder<Medicamento> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Nome)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(m => m.Composicao)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(m => m.Laboratorio)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
