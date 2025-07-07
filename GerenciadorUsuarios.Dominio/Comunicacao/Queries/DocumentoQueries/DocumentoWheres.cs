
using GerenciadorUsuarios.Dominio.Entidades;
using GerenciadorUsuarios.Dominio.Enumeradores;
using System.Linq.Expressions;

namespace GerenciadorUsuarios.Dominio.Comunicacao.Queries.DocumentoQueries
{
    public static class DocumentoWheres
    {
        public static Expression<Func<Documento, bool>> ObterPorNumeroTipo(TipoDocumento tipo, string valor)
        {
            return x => x.TipoDocumento == tipo && x.Valor == valor;
        }
    }
}
