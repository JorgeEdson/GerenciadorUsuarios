using GerenciadorUsuarios.Dominio.Comunicacao;
using GerenciadorUsuarios.Dominio.Enumeradores;

namespace GerenciadorUsuarios.Dominio.Entidades
{
    public class Documento : EntidadeBase
    {
        #region Propriedades
        public TipoDocumento TipoDocumento { get; private set; }
        public string Valor { get; private set; }
        public long IdUsuario { get; private set; }
        public Usuario Usuario { get; private set; }
        #endregion

        #region Métodos Privados
        private void SetTipoDocumento(int tipoDocumento)
        {
            if (!Enum.IsDefined(typeof(TipoDocumento), tipoDocumento))
                throw new ArgumentException("Tipo de documento inválido.");

            TipoDocumento = (TipoDocumento)tipoDocumento;
        }

        private void SetValor(string valor)
        {
            if (string.IsNullOrEmpty(valor))
                throw new ArgumentException("Valor do documento inválido.");
            Valor = valor;
        }

        private void VincularUsuario(Usuario usuario)
        {
            if (usuario == null)
                throw new ArgumentException("Usuário inválido.");
            Usuario = usuario;
            Usuario.VincularDocumento(this);
        }
        #endregion

        #region Construtores
        public Documento() : base()
        {
            
        }

        private Documento(int tipoDocumento, string valor, Usuario usuario) : base()
        {
            SetTipoDocumento(tipoDocumento);
            SetValor(valor);
            VincularUsuario(usuario);
        }
        #endregion

        #region Métodos Publicos
        public static ResultadoGenerico<Documento> Criar(int tipo, string numero, Usuario usuario)
        {
            return new ResultadoGenerico<Documento>(
                true,
                "Documento criado com sucesso.",
                new Documento(tipo, numero, usuario)
            );
        }
        #endregion
    }
}
