using Recommendation.Entidades.Cliente;
using Recommendation.Entidades.Enums;
using Recommendation.Entidades.Receita;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
namespace Recommendation.Entidades.Prescricao
{
    public class Prescricoes
    {
        public Guid Id { get; set; }
        public Status StatusPrescricao { get; private set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "(dd/MM/yyyy)", ApplyFormatInEditMode = true)]
        [Column(TypeName = "timestamptz")]
        public DateTime DataLancamento { get; private set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "(dd/MM/yyyy)", ApplyFormatInEditMode = true)]
        [Column(TypeName = "timestamptz")]
        [MaybeNull]
        public DateTime DataPagamendo { get; private set; }
        public string PrescritoPor {  get; private set; }
        public string PrescritoPara { get; private set; }
        public string Cpf { get; private set; }
        public List<Receitas> ItensReceitados { get; } = [];

        public Prescricoes(string prescritoPor, string prescritoPara, string cpf)
        {
            StatusPrescricao = Status.Aguardando;
            DataLancamento = DateTime.UtcNow;
            PrescritoPor = prescritoPor;
            PrescritoPara = prescritoPara;
            Cpf = cpf;
            ItensReceitados = new List<Receitas>();
        }

        public void AtualizarStatusFinalizado()
        {
            StatusPrescricao = Status.Finalizado;
            DataPagamendo = DateTime.UtcNow;
        }

        public void AtualizarStatusCancelado()
        {
            StatusPrescricao = Status.Cancelado;
            DataPagamendo = DateTime.UtcNow;
        }

        public void AddItens(string nome, string marca, bool disponivel, decimal valor)
        {
            Receitas novaReceita = new Receitas(nome, marca, disponivel, valor);
            ItensReceitados.Add(novaReceita);
        }
    }
}
