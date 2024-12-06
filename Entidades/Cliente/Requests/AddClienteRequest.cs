namespace Recomendacao.Entidades.Cliente.Requests
{
    public record AddClienteRequest(string Nome, string Cpf, string Endereco, int NmrResidencial, string Bairro, string Cidade);
}
