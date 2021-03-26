using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VedaSystem.Domain.Models;

namespace VedaSystem.Infra.Data.Mappings
{
    public class EstoqueMaterialMap : IEntityTypeConfiguration<EstoqueMaterial>
    {
        public void Configure(EntityTypeBuilder<EstoqueMaterial> builder)
        {
            builder.HasKey(em => em.Id);

            builder.Property(em => em.Descricao)
                    .HasMaxLength(150)
                    .IsRequired();

            builder.Property(em => em.Modelo)
                    .HasMaxLength(50)
                    .IsRequired();

            builder.Property(em => em.Marca)
                    .HasMaxLength(50)
                    .IsRequired();

            builder.Property(em => em.Quantidade)
                    .IsRequired();
        }
    }
}
