using Recommendation.Entidades.Cliente;
using Recommendation.Entidades.Receita;

namespace Recommendation.Entidades.Prescricao.Requests
{
    public record AddPrescricoesRequest(string PrescritoPor, string PrescritoPara, string Cpf);
}
