using GerenciadorUsuarios.Dominio.Comunicacao;

namespace GerenciadorUsuarios.Dominio.Entidades
{
    public class UsuarioPerfil : EntidadeBase
    {
        #region Propriedades
        public Guid IdUsuario { get; private set; }
        public Usuario Usuario { get; private set; }
        public Guid IdPerfil { get; private set; }
        public Perfil Perfil { get; private set; }
        public bool Ativo { get; private set; }
        #endregion

        #region Metodos Privados
        private void SetPerfil(Perfil perfil)
        {
            if (perfil is null)
                throw new Exception(nameof(perfil));

            Perfil = perfil;
            IdPerfil = perfil.Id;
        }

        private void SetUsuario(Usuario usuario)
        {
            if (usuario is null)
                throw new Exception(nameof(usuario));

            Usuario = usuario;
            IdUsuario = usuario.Id;
        }

        #endregion

        #region Construtores
        public UsuarioPerfil()
        {
        }

        private UsuarioPerfil(Usuario usuario, Perfil perfil, bool ativo) : base()
        {
            SetUsuario(usuario);
            SetPerfil(perfil);
            SetAtivo(ativo);
        }

        #endregion

        #region metodos Publicos
        public void SetAtivo(bool ativo)
        {
            Ativo = ativo;
        }

        public static ResultadoGenerico<UsuarioPerfil> Criar(
            Perfil perfil,
            Usuario usuario,
            bool ativo)
        {
            if (perfil is null)
                return new ResultadoGenerico<UsuarioPerfil>(false, "Perfil inválido.", null);

            if (usuario is null)
                return new ResultadoGenerico<UsuarioPerfil>(false, "Usuário inválido.", null);

            return new ResultadoGenerico<UsuarioPerfil>(true, "Vínculo criado com sucesso.", new UsuarioPerfil(usuario,perfil, ativo));
        }
        #endregion
    }
}
