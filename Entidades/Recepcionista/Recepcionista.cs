using System.ComponentModel.DataAnnotations;

namespace Recommendation.Entidades.Recepcionista
{
    public class Recepcionista
    {
        [Key]
        public Guid Id { get; init; }
        [Required]
        [MaxLength(150)]
        public string Nome { get; private set; }
        [Required]
        public string Senha { get; private set; }

        public Recepcionista(string nome, string senha)
        {
            Nome = nome;
            Senha = senha;
        }

        public void AtualizarNome(string nome)
        {
            Nome = nome;
        }

        public void AtualizarSenha(string senha)
        {
            Senha = senha;
        }
    }
}
