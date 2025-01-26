using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Recommendation.Entidades.Cliente;
using Recommendation.Entidades.Prescricao;


namespace Recommendation.Entidades.Receita
{
    public class Receitas
    {
        [Key]
        public Guid Id { get; init; }
        [Required]
        [MaxLength(150)]
        public string Nome { get; private set; }
        [MaybeNull]
        public string? Descricao { get; private set; }
        [Required]
        [MaxLength(100)]
        public string Categoria { get; private set; } = string.Empty;
        [Required]
        [MaxLength(150)]
        public string Marca { get; private set; }
        [Required]
        public bool Disponivel { get; private set; }
        public decimal Valor {  get; private set; }
        public List<Prescricoes> Prescricoes { get; } = [];

        public Receitas(string nome, string descricao, string categoria, string marca, bool disponivel, decimal valor)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Descricao = descricao;
            Categoria = categoria;
            Marca = marca;
            Disponivel = disponivel;
            Valor = valor;
        }

        public Receitas(string nome, string marca, bool disponivel, decimal valor)
        {
            Nome = nome;
            Marca = marca;
            Disponivel = disponivel;
            Valor = valor;
        }

        public void AtualizarNome(string nome)
        {
            Nome = nome;
        }
        public void AtualizarDescricao(string descricao)
        {
            Descricao = descricao;
        }
        public void AtualizarCategoria(string categoria)
        {
            Categoria = categoria;
        }
        public void AtualizarMarca(string marca)
        {
            Marca = marca;
        }
        public void AtualizarDisponibilidade(bool isDisponivel)
        {
            Disponivel = isDisponivel;
        }

        public void AtualizarValor(decimal valor)
        {
            Valor = valor;
        }
    }
}
