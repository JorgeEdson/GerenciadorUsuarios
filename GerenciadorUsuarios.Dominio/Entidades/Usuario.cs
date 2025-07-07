using GerenciadorUsuarios.Dominio.Comunicacao;
using GerenciadorUsuarios.Dominio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorUsuarios.Dominio.Entidades
{
    public class Usuario : EntidadeBase
    {
        #region Propriedades
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string Endereco { get; private set; }
        public string Telefone { get; private set; }
        public bool Ativo { get; private set; }
        public long? IdDocumento { get; private set; }
        public Documento? Documento { get; private set; }
        public long? IdFotoUsuario { get; private set; }
        public Foto? Foto { get; private set; }
        #endregion

        #region Metodos Privados
        private void SetNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome do usuário não pode estar vazio.");

            if (nome.Length > 200)
                throw new ArgumentException("Nome do usuário não pode ter mais de 200 caracteres.");

            Nome = nome;
        }

        private void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email do usuário não pode estar vazio.");

            if (email.Length > 150)
                throw new ArgumentException("Email do usuário não pode ter mais de 200 caracteres.");

            Email = email;
        }

        private void SetSenha(string senha)
        {
            if (string.IsNullOrWhiteSpace(senha))
                throw new ArgumentException("Senha do usuário não pode estar vazia.");

            if (senha.Length < 6)
                throw new ArgumentException("Senha do usuário deve ter no mínimo 6 caracteres.");

            Senha = EncriptadorUtil.Criptografar(senha);
        }
        #endregion

        #region Construtores
        public Usuario() : base()
        {

        }

        private Usuario(string nome, string email, string senha, string endereco, string telefone) : base()
        {
            SetNome(nome);
            SetEmail(email);
            SetSenha(senha);
            SetEndereco(endereco);
            SetTelefone(telefone);
            SetAtivo(true);
        }
        #endregion

        #region Metodos Publicos
        public void SetEndereco(string endereco)
        {
            if (string.IsNullOrWhiteSpace(endereco))
                throw new ArgumentException("Endereço do usuário não pode estar vazio.");

            Endereco = endereco;
        }

        public void SetTelefone(string telefone)
        {
            if (string.IsNullOrWhiteSpace(telefone))
                throw new ArgumentException("Telefone do usuário não pode estar vazio.");

            Telefone = telefone;
        }
        public void SetAtivo(bool ativo)
        {
            Ativo = ativo;
        }
        public void VincularDocumento(Documento documento)
        {
            if (documento == null)
                throw new ArgumentException("Documento inválido.");
            IdDocumento = documento.Id;
            Documento = documento;
        }

        public void VincularFoto(Foto foto)
        {
            if (foto == null)
                throw new ArgumentException("Foto inválida.");
            IdFotoUsuario = foto.Id;
            Foto = foto;
        }

        public static ResultadoGenerico<Usuario> Criar(string nome, string email, string senha, string endereco, string telefone)
        {
            return new ResultadoGenerico<Usuario>(
                true,
                "Usuário criado com sucesso.",
                new Usuario(nome, email, senha, endereco, telefone)
            );
        }
        #endregion


    }
}
