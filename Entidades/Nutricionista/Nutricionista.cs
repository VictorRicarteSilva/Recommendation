using System.ComponentModel.DataAnnotations;

namespace Recommendation.Entidades.Nutricionista
{
    public class Nutricionista
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

        public Nutricionista(string nome, string profissao, string email, string numero)
        {
            Nome = nome;
            Profissao = profissao;
            Email = email;
            Numero = numero;
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
    }
}
