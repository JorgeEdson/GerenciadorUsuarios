using GerenciadorUsuarios.Dominio.Comunicacao.Queries.DocumentoQueries;
using GerenciadorUsuarios.Dominio.Entidades;
using GerenciadorUsuarios.Dominio.Enumeradores;
using GerenciadorUsuarios.Dominio.Interfaces;
using GerenciadorUsuarios.Infraestrutura.Contextos;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorUsuarios.Infraestrutura.Entity
{
    public class UnityOfWork(Contexto contexto) : IUnitOfWork
    {
        private readonly Contexto _contexto = contexto;
        public async Task AtualizarAsync<T>(T entidade) where T : EntidadeBase
        {
            _contexto.Set<T>().Update(entidade);
        }

        public async Task InserirAsync<T>(T entidade) where T : EntidadeBase
        {
            await _contexto.Set<T>().AddAsync(entidade);
        }

        public Task<Documento?> ObterDocumentoPorNumeroTipoAsync(TipoDocumento tipo, string numero)
        {
            throw new NotImplementedException();
        }

        public async Task<T?> ObterPorIdAsync<T>(long id) where T : EntidadeBase
        {
            return await _contexto.Set<T>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<T>> ObterTodosAsync<T>() where T : EntidadeBase
        {
            return await _contexto.Set<T>().ToListAsync();
        }

        public async Task<bool> VerificarEmailCadastradoAsync(string email)
        {
            return await _contexto.Usuarios
                .AsNoTracking()
                .Where(x => x.Email == email)
                .FirstOrDefaultAsync() != null;
        }

        public async Task<bool> VerificarDocumentoCadastradoAsync(TipoDocumento tipo, string numero)
        {
            return await _contexto.Documentos
                .AsNoTracking()
                .Where(DocumentoWheres.ObterPorNumeroTipo(tipo, numero))
                .FirstOrDefaultAsync() != null;
        }

        public async Task RemoverAsync<T>(T entidade) where T : EntidadeBase
        {
            _contexto.Set<T>().Remove(entidade);
        }

        public async Task<int> SalvarAlteracoesAsync(CancellationToken cancellationToken = default)
        {
            return await _contexto.SaveChangesAsync(cancellationToken);
        }
    }
}
