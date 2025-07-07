namespace GerenciadorUsuarios.Dominio.Comunicacao.DTOs.Usuario
{
    public sealed class AutoCadastroReq
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Senha { get; set; }
        public string SenhaConfirmacao { get; set; }        
    }
}
