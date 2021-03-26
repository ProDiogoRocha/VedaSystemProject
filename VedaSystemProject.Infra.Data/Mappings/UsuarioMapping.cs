using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VedaSystemProject.Domain.Models;

namespace VedaSystemProject.Infra.Data.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.NomeDeUsuario)
                .IsRequired();

            builder.Property(c => c.Senha)
                .IsRequired();

            builder.Property(c => c.ConfirmeSenha)
                .IsRequired();

            builder.Property(c => c.DataNascimento)
                .IsRequired();

            builder.Property(c => c.Endereco);

            builder.Property(c => c.Email)
                .IsRequired();

            builder.Property(c => c.DataCadastro)
                .IsRequired();

            builder.Property(c => c.TipoUsuario)
                .IsRequired();
        }
    }
}
