namespace GerenciadorUsuarios.Dominio.Entidades
{
    public class EntidadeBase
    {
        #region Propriedades
        public Guid Id { get; private set; }
        #endregion

        #region Metodos Privados
        #endregion

        #region Construtores
        protected EntidadeBase()
        {
            Id = Guid.NewGuid();
        }
        #endregion

        #region Metodos Publicos
        #endregion



    }
}
