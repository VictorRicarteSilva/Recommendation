namespace Recommendation.Entidades.Receita.Requests
{
    public record AddReceitaRequest(string Nome, string Descricao, string Categoria, string Marca, bool Disponivel);
}
