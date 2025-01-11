using GerenciadorUsuarios.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorUsuarios.Infraestrutura.Mapeamentos
{
    public class FotoMapping : IEntityTypeConfiguration<Foto>
    {
        public void Configure(EntityTypeBuilder<Foto> builder)
        {
            #region Chave Primária
            builder.HasKey(foto => foto.Id);
            #endregion

        }
    }
}
