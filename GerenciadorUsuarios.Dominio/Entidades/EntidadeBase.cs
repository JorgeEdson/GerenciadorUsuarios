using GerenciadorUsuarios.Dominio.Utils;

namespace GerenciadorUsuarios.Dominio.Entidades
{
    public class EntidadeBase
    {
        #region Propriedades
        public long Id { get; private set; }
        #endregion

        #region Metodos Privados
        #endregion

        #region Construtores
        protected EntidadeBase()
        {
            Id = GeradorIdUtil.ProximoId();
        }
        #endregion

        #region Metodos Publicos
        #endregion



    }
}
