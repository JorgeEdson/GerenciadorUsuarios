using GerenciadorUsuarios.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorUsuarios.Infraestrutura.Mapeamentos
{
    public class DocumentoMapping : IEntityTypeConfiguration<Documento>
    {
        public void Configure(EntityTypeBuilder<Documento> builder)
        {
            #region Chave Primária
            builder.HasKey(documento => documento.Id);
            builder.Property(documento => documento.Id).ValueGeneratedNever();
            #endregion

            #region Colunas Obrigatorias
            builder.Property(documento => documento.TipoDocumento).IsRequired();
            builder.Property(documento => documento.Valor).IsRequired();
            #endregion
        }
    }
}
