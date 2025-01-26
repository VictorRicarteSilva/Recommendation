namespace Recomendacao.Entidades.Cliente.Requests
{
    public record UpdateClienteRequest(string Nome, string Cpf, bool IsAtivo, string Endereco, int NmrResidencial, string Bairro, string Cidade, bool PossuiComorbidade);
}
