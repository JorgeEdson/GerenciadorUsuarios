using GerenciadorUsuarios.Dominio.Comunicacao;


namespace GerenciadorUsuarios.Dominio.Entidades
{
    public class Foto : EntidadeBase
    {
        #region Propriedades
        public long IdUsuario { get; private set; }
        public Usuario Usuario { get; private set; }
        #endregion

        #region Metodos Privados
        private void VincularUsuario(Usuario usuario)
        {
            if (usuario == null)
                throw new ArgumentException("Usuário inválido.");

            Usuario = usuario;
            IdUsuario = usuario.Id;
        }
        #endregion

        #region Construtores
        public Foto()
        {
                
        }

        private Foto(Usuario usuario) : base()
        {
            VincularUsuario(usuario);
        }

        #endregion

        #region Metodos Publicos
        public static ResultadoGenerico<Foto> Criar(Usuario usuario)
        {
            return new ResultadoGenerico<Foto>(
                true,
                "Foto criada com sucesso.",
                new Foto(usuario)
            );
        }
        #endregion
    }
}
