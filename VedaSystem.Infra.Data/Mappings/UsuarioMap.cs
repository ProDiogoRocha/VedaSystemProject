using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VedaSystem.Domain.Models;

namespace VedaSystem.Infra.Data.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);
            
            builder.Property(u => u.NomeDeUsuario)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(u => u.Senha)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(u => u.ConfirmeSenha)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(u => u.DataNascimento)
                .IsRequired();

            builder.Property(u => u.Endereco)
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(u => u.Email)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(u => u.DataCadastro);

            builder.Property(u => u.TipoUsuario)
                .IsRequired();
        }
    }
}
