using Recommendation.Entidades.Cliente;
using Recommendation.Entidades.Receita;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
namespace Recommendation.Entidades.Prescricao
{
    public class Prescricoes
    {
        //public Guid ClienteId { get; private set; }
        //public Guid ReceitaId { get; private set; }
        public Guid Id { get; set; }
        public bool CompraConfirmada { get; private set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "(dd/MM/yyyy)", ApplyFormatInEditMode = true)]
        public DateTime DataLancamento { get; private set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "(dd/MM/yyyy)", ApplyFormatInEditMode = true)]
        [MaybeNull]
        public DateTime DataPagamendo { get; private set; }
        public string PrescritoPor {  get; private set; }

        public string NomeCliente { get;  set; }
        public string Cpf {  get;  set; }
        public string NomeReceita { get;  set; }
        public string Descricao { get;  set; }

        public Prescricoes(string prescritoPor)
        {
            CompraConfirmada = false;
            DataLancamento = DateTime.Now;
            PrescritoPor = prescritoPor;
        }

        public void AtualizarStatus()
        {
            CompraConfirmada = true;
            DataPagamendo = DateTime.Now;
        }
    }
}
