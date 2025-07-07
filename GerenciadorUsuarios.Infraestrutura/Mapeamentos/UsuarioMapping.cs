using GerenciadorUsuarios.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorUsuarios.Infraestrutura.Mapeamentos
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            #region Chave Primária
            builder.HasKey(usuario => usuario.Id);
            builder.Property(usuario => usuario.Id).ValueGeneratedNever();
            #endregion

            #region Colunas Obrigatorias
            builder.Property(usuario => usuario.Nome)
                .HasMaxLength(200)
                .IsRequired();

            builder.HasIndex(usuario => usuario.Email)
                .IsUnique();

            builder.Property(usuario => usuario.Email)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(usuario => usuario.Telefone)
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(usuario => usuario.Senha)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(usuario => usuario.Ativo)
                .IsRequired();

            builder.Property(usuario => usuario.Endereco)
                .IsRequired();
            #endregion

            #region Relacionamentos 1:1
            builder.HasOne(usuario => usuario.Documento)
                .WithOne(documento => documento.Usuario)
                .HasForeignKey<Documento>(documento => documento.IdUsuario);

            builder.HasOne(usuario => usuario.Foto)
                .WithOne(foto => foto.Usuario)
                .HasForeignKey<Foto>(foto => foto.IdUsuario);
            #endregion
        }
    }
}
