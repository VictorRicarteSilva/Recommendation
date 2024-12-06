using Recommendation.Entidades.Cliente;
using Recommendation.Entidades.Receita;

namespace Recommendation.Entidades.Prescricao.Requests
{
    public record AddPrescricoesRequest(Clientes Cliente, Receitas Receita, string PrescritoPor);
}
