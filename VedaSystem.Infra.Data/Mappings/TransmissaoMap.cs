using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VedaSystem.Domain.Models;

namespace VedaSystem.Infra.Data.Mappings
{
    public class TransmissaoMap : IEntityTypeConfiguration<Transmissao>
    {
        public void Configure(EntityTypeBuilder<Transmissao> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Titulo)
               .HasMaxLength(60)
               .IsRequired();

            builder.Property(t => t.SubTitulo)
               .HasMaxLength(50);

            builder.Property(t => t.TextoAntesDoVideo);

            builder.Property(t => t.CodigoDeIncorporacaoDeVideo);

            builder.Property(t => t.TextoDepoisDoVideo);

            builder.Property(t => t.Rodape);

            builder.Property(t => t.Ativo)
               .IsRequired();

            builder.Property(t => t.IdsDepoimentos);

            builder.HasOne(t => t.Terapeuta)
            .WithMany(x => x.Transmissoes)
            .HasForeignKey(t => t.TerapeutaId);
        }
    }
}
