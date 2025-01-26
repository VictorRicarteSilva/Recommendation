namespace Recommendation.Entidades.Receita.Requests
{
    public record UpdateReceitaRequest(string Nome, string Descricao, string Categoria, string Marca, bool Disponivel, decimal Valor);

}
