using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Recommendation.Entidades.Prescricao;


namespace Recommendation.Entidades.Receita
{
    public class Receitas
    {
        public Guid Id { get; init; }
        [Required]
        [MaxLength(150)]
        public string Nome { get; private set; }
        [MaybeNull]
        public string? Descricao { get; private set; }
        [Required]
        [MaxLength(100)]
        public string Categoria { get; private set; }
        [Required]
        [MaxLength(150)]
        public string Marca { get; private set; }
        [Required]
        public bool Disponivel { get; private set; }

        public  ICollection<Prescricoes> ReceitaPrescricoes { get; private set; }

        public Receitas(string nome, string descricao, string categoria, string marca, bool disponivel)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Descricao = descricao;
            Categoria = categoria;
            Marca = marca;
            Disponivel = disponivel;
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
    }
}
