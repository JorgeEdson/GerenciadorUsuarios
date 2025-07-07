using GerenciadorUsuarios.Dominio.Entidades;
using GerenciadorUsuarios.Dominio.Enumeradores;

namespace GerenciadorUsuarios.Dominio.Interfaces
{
    public interface IUnitOfWork
    {
        Task InserirAsync<T>(T entidade) where T : EntidadeBase;
        Task AtualizarAsync<T>(T entidade) where T : EntidadeBase;
        Task RemoverAsync<T>(T entidade) where T : EntidadeBase;
        Task<T?> ObterPorIdAsync<T>(long id) where T : EntidadeBase;
        Task<IEnumerable<T>> ObterTodosAsync<T>() where T : EntidadeBase;
        Task<int> SalvarAlteracoesAsync(CancellationToken cancellationToken = default);

        #region Metodos de Usuario
        Task<bool> VerificarEmailCadastradoAsync(string email);
        #endregion

        #region Metodos de Documento
        Task<bool> VerificarDocumentoCadastradoAsync(TipoDocumento tipo, string numero);
        #endregion


    }
}
