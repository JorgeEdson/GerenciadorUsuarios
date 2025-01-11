using GerenciadorUsuarios.Dominio.Entidades;

namespace GerenciadorUsuarios.Dominio.Interfaces
{
    public interface IUnitOfWork
    {
        Task InserirAsync<T>(T entidade) where T : EntidadeBase;
        Task AtualizarAsync<T>(T entidade) where T : EntidadeBase;
        Task RemoverAsync<T>(T entidade) where T : EntidadeBase;
        Task<T?> ObterPorIdAsync<T>(Guid id) where T : EntidadeBase;
        Task<IEnumerable<T>> ObterTodosAsync<T>() where T : EntidadeBase;
    }
}
