using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VedaSystem.Domain.Models;

namespace VedaSystem.Infra.Data.Mappings
{
    public class MaterialTerapiaMap : IEntityTypeConfiguration<MaterialTerapia>
    {
        public void Configure(EntityTypeBuilder<MaterialTerapia> builder)
        {
            builder.HasKey(mt => mt.Id);

            builder.Property(mt => mt.EstoqueMaterialId);

            builder.Property(mt => mt.TerapiaId);

            builder.Property(mt => mt.Quantidade)
                    .IsRequired();

            builder.Property(mt => mt.Ativo);
        }
    }
}
