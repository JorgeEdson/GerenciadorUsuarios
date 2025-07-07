using GerenciadorUsuarios.Dominio.Comunicacao.DTOs.Usuario;
using GerenciadorUsuarios.Dominio.Comunicacao.Factory;
using GerenciadorUsuarios.Dominio.Comunicacao;
using GerenciadorUsuarios.Dominio.Interfaces;
using MediatR;
using GerenciadorUsuarios.Dominio.Enumeradores;
using GerenciadorUsuarios.Dominio.Entidades;

namespace GerenciadorUsuarios.Dominio.Handlers.UsuarioHandlers
{
    public class AutoCadastroHandler(IUnitOfWork unitOfWork)
        : IRequestHandler<Command<AutoCadastroReq, ResultadoGenerico<long>>, ResultadoGenerico<long>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<ResultadoGenerico<long>> Handle(Command<AutoCadastroReq, ResultadoGenerico<long>> request, CancellationToken cancellationToken)
        {
            try 
            {
                var data = request.Data;
                 
                if (data.Senha != data.SenhaConfirmacao)
                {
                    return new ResultadoGenerico<long>(false, "A senha e a confirmação de senha não coincidem.", 0);
                }

                var emailExiste = await _unitOfWork.VerificarEmailCadastradoAsync(data.Email);

                if (emailExiste)
                {
                    return new ResultadoGenerico<long>(false, "Já existe um usuário cadastrado com este email.", 0);
                }

                if (!Enum.IsDefined(typeof(TipoDocumento), data.TipoDocumento))
                {
                    return new ResultadoGenerico<long>(false, "Tipo de documento inválido.", 0);
                }

                TipoDocumento tipoDocumento = (TipoDocumento)data.TipoDocumento;

                var documentoExiste = await _unitOfWork.VerificarDocumentoCadastradoAsync(tipoDocumento, data.NumeroDocumento);
                if (documentoExiste)
                {
                    return new ResultadoGenerico<long>(false, "Já existe um documento cadastrado com este número e tipo.", 0);
                }

                var usuarioResult = Usuario.Criar(
                   nome: data.Nome,
                   email: data.Email,
                   telefone: data.Telefone,
                   senha: data.Senha,
                   endereco: data.Endereco
               );
                var usuarioObj = usuarioResult.Dados;
                await _unitOfWork.InserirAsync<Usuario>(usuarioObj);

                var documentoResult = Documento.Criar(
                    data.TipoDocumento,
                    data.NumeroDocumento,
                    usuarioResult.Dados
                );
                var documentoObj = documentoResult.Dados;
                await _unitOfWork.InserirAsync<Documento>(documentoObj);

                usuarioObj.VincularDocumento(documentoObj);

                await _unitOfWork.SalvarAlteracoesAsync();

                return new ResultadoGenerico<long>(true, "Usuário cadastrado com sucesso.", usuarioObj.Id);

            }
            catch (Exception ex)
            {
                return new ResultadoGenerico<long>(false, $"Erro ao cadastrar o usuário: {ex.Message}", 0);
            }
        }
    }
}
