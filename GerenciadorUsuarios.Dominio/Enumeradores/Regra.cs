using System.ComponentModel.DataAnnotations;

namespace GerenciadorUsuarios.Dominio.Enumeradores
{
    public enum Regra
    {
        [Display(Name = "Pode editar Autocadastro")]
        Autocadastro_Editar = 1,
        [Display(Name = "Pode excluir Autocadastro")]
        Autocadastro_Excluir = 2,
    }
}
