
using GerenciadorUsuarios.Dominio.Comunicacao;
using GerenciadorUsuarios.Dominio.Enumeradores;
using System.Data;

namespace GerenciadorUsuarios.Dominio.Entidades
{
    public class Perfil : EntidadeBase
    {
        #region Propriedades
        public string Nome { get; private set; }
        public List<UsuarioPerfil> VinculosUsuario { get; private set; }
        public List<Permissao> Permissoes { get; private set; }

        #endregion

        #region Metodos Privados
        private void SetNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new Exception(nameof(nome));

            Nome = nome;
        }
        #endregion

        #region Construtores
        public Perfil()
        {
            VinculosUsuario = new List<UsuarioPerfil>();
            Permissoes = new List<Permissao>();
        }

        private Perfil(string nome) : base()
        {
            SetNome(nome);
            VinculosUsuario = new List<UsuarioPerfil>();
            Permissoes = new List<Permissao>();
        }
        #endregion

        #region Metodos Publicos
        public void VincularPermissoes(Regra[] permissoes)
        {
            foreach (var permissao in permissoes)
            {
                var vinculo = Permissao.Criar(this, permissao);

                if (!vinculo.Sucesso)
                    throw new Exception(vinculo.Mensagem);

                Permissoes.Add(vinculo.Dados);
            }
        }
        public static ResultadoGenerico<Perfil> Criar(string nome)
        {
            return new ResultadoGenerico<Perfil>(true, "Perfil criado com sucesso.", new Perfil(nome));
        }
        #endregion
    }
}
