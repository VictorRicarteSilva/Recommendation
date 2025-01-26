using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Recommendation.Entidades.Prescricao;
using Recommendation.Entidades.Receita;

namespace Recommendation.Entidades.Cliente
{
    public class Clientes
    {
        public Guid Id { get; init; }
        [Required]
        [MaxLength(150)]
        public string Nome { get; private set; }
        [Required]
        [MaxLength(11)]
        [DisplayName("CPF")]
        public string Cpf { get; set; }
        public bool Ativo { get; private set; }
        [Required]
        public string Endereco { get; private set; }
        [Required]
        public int NmrResidencial { get; private set; }
        [Required]
        public string Bairro { get; private set; }
        [Required]
        public string Cidade { get; private set; }
        public bool PossuiComorbidade { get; private set; }

        public Clientes(string nome, string cpf, string endereco, int nmrResidencial, string bairro, string cidade, bool possuiComorbidade)
        {
            Id = Guid.NewGuid();
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Cpf = cpf ?? throw new ArgumentNullException(nameof(cpf));
            Ativo = true;
            Endereco = endereco ?? throw new ArgumentNullException(nameof(endereco));
            NmrResidencial = nmrResidencial;
            Bairro = bairro ?? throw new ArgumentNullException(nameof(bairro));
            Cidade = cidade ?? throw new ArgumentNullException(nameof(cidade));
            PossuiComorbidade = possuiComorbidade;
        }

        public void AtualizarNome(string nome)
        {
            Nome = nome;
        }

        public void AtualizarCpf(string cpf)
        {
            Cpf = cpf;
        }

        public void AtualizarAtivo(bool isAtivo)
        {
            Ativo = isAtivo;
        }

        public void AtualizarEndereco(string endereco)
        {
            Endereco = endereco;
        }

        public void AtualizarNmrResidencial(int nmrResidencial)
        {
            NmrResidencial = nmrResidencial;
        }

        public void AtualizarBairro(string bairro)
        {
            Bairro = bairro;
        }

        public void AtualizarCidade(string cidade)
        {
            Cidade = cidade;
        }

        public void AtualizarComorbidade(bool isComorbidade)
        {
            PossuiComorbidade = isComorbidade;
        }
    }
}
