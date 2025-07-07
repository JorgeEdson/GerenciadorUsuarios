using GerenciadorUsuarios.Dominio.Comunicacao;
using GerenciadorUsuarios.Dominio.Enumeradores;
using GerenciadorUsuarios.Dominio.Utils;

namespace GerenciadorUsuarios.Dominio.Entidades
{
    public class Permissao : EntidadeBase
    {
        #region Propriedades
        public long IdPerfil { get; set; }
        public Perfil Perfil { get; set; }
        public Regra Valor { get; set; }

        #endregion

        #region Metodos Privados
        private void SetPerfil(Perfil perfil)
        {
            if (perfil is null)
            {
                throw new Exception(nameof(perfil));
            }

            Perfil = perfil;
            IdPerfil = perfil.Id;
        }

        private void SetValor(Regra valor)
        {
            if (!valor.IsInEnum<Regra>())
                throw new Exception(nameof(valor));

            Valor = valor;
        }
        #endregion

        #region Construtores
        public Permissao()
        {
        }

        private Permissao(Perfil perfil, Regra valor) : base()
        {
            SetPerfil(perfil);
            SetValor(valor);
        }
        #endregion

        #region Metodos Publicos
        public static ResultadoGenerico<Permissao> Criar(Perfil perfil, Regra valor)
        {
            if (perfil is null)
                return new ResultadoGenerico<Permissao>(false, "Perfil inválido.", null);

            if (!valor.IsInEnum<Regra>())
                return new ResultadoGenerico<Permissao>(false, "Role Inválida", null);

            return new ResultadoGenerico<Permissao>(true, "Permissão criada com sucesso.", new Permissao(perfil, valor));
        }
        #endregion
    }
}
