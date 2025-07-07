using GerenciadorUsuarios.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace GerenciadorUsuarios.Infraestrutura.Mapeamentos
{
    public class PermissaoMapping : IEntityTypeConfiguration<Permissao>
    {
        public void Configure(EntityTypeBuilder<Permissao> builder)
        {
            #region Chave Primária
            builder.HasKey(permissao => permissao.Id);
            builder.Property(permissao => permissao.Id).ValueGeneratedNever();
            #endregion

            #region Colunas Obrigatorias            
            builder.Property(permissao => permissao.Valor).IsRequired();
            #endregion

        }
    }
}
