using GerenciadorUsuarios.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorUsuarios.Infraestrutura.Mapeamentos
{
    public class UsuarioPerfilMapping : IEntityTypeConfiguration<UsuarioPerfil>
    {
        public void Configure(EntityTypeBuilder<UsuarioPerfil> builder)
        {
            #region Chave Primária
            builder.HasKey(usuarioPerfil => usuarioPerfil.Id);
            builder.Property(usuarioPerfil => usuarioPerfil.Id).ValueGeneratedNever();
            #endregion

        }
    }
}
