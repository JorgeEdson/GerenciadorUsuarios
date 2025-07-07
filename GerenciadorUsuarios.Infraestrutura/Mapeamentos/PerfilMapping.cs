using GerenciadorUsuarios.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorUsuarios.Infraestrutura.Mapeamentos
{
    internal class PerfilMapping : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {
            #region Chave Primária
            builder.HasKey(perfil => perfil.Id);
            builder.Property(perfil => perfil.Id).ValueGeneratedNever();
            #endregion

            #region Colunas Obrigatorias
            builder.Property(perfil => perfil.Nome).HasMaxLength(200).IsRequired();
            #endregion

        }
    }
}
