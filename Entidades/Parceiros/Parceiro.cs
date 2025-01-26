using System.ComponentModel.DataAnnotations;

namespace Recommendation.Entidades.Parceiros
{
    public class Parceiro
    {
        public Guid Id { get; init; }
        [Required]
        [MaxLength(150)]
        public string Nome { get; private set; }
        [Required]
        [MaxLength(100)]
        public string Profissao { get; private set; }
        [Required]
        public string Email { get; private set; }
        [Required]
        [MaxLength(20)]
        public string Numero { get; private set; }
        public string Senha { get; private set; }

        public Parceiro(string nome, string profissao, string email, string numero, string senha)
        {
            Nome = nome;
            Profissao = profissao;
            Email = email;
            Numero = numero;
            Senha = senha;
        }

        public void AtualizarNome(string nome)
        {
            Nome = nome;
        }
        public void AtualizarProfissao(string profissao)
        {
            Profissao = profissao;
        }
        public void AtualizarEmail(string email)
        {
            Email = email;
        }
        public void AtualizarNumero(string numero)
        {
            Numero = numero;
        }

        public void AtualizarSenha(string senha)
        {
            Senha = senha;
        }
    }
}
