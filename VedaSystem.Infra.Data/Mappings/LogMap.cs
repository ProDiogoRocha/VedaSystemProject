using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VedaSystem.Domain.Models;

namespace VedaSystem.Infra.Data.Mappings
{
    public class LogMap : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.HasKey(l => l.Id);

            builder.Property(l => l.Data);

            builder.Property(l => l.IdUsuario);

            builder.Property(l => l.NomeUsuario);

            builder.Property(l => l.NomeComputador);

            builder.Property(l => l.Controller_Action);

            builder.Property(l => l.Servico_Metodo);

            builder.Property(l => l.Repositorio_Metodo);

            builder.Property(l => l.Informacao);

            builder.Property(l => l.ObjetoJson);

            builder.Property(l => l.Erro);

            builder.Property(l => l.Excecao);
        }
    }
}
