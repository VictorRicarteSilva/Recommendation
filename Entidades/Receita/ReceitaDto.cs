using Microsoft.EntityFrameworkCore;

namespace Recommendation.Entidades.Receita
{
    public record ReceitaDto(string Nome, string Marca, bool Disponivel, decimal Valor);
}
