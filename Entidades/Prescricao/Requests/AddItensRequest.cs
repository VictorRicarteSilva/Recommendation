namespace Recommendation.Entidades.Prescricao.Requests
{
    public record AddItensRequest(string Nome, string Marca, bool Disponivel, decimal Valor);
}
