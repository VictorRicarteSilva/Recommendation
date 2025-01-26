using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recomendacao.Entidades.Cliente;
using Recomendacao.Entidades.Cliente.Requests;
using Recommendation.Data;

namespace Recommendation.Entidades.Cliente
{
    [ApiExplorerSettings(GroupName ="Clientes")]
    public static class ClienteRoutes
    {
        public static void AddClienteRoutes(this WebApplication app)
        {
            var clienteRoutes = app.MapGroup("Clientes");
            //Insert clientes
            clienteRoutes.MapPost("/CadastrarCliente", async (AddClienteRequest request, AppDbContext context) =>
            {
                var novoCliente = new Clientes(request.Nome, request.Cpf, request.Endereco, request.NmrResidencial, request.Bairro, request.Cidade, request.PossuiComorbidade);
                await context.Clientes.AddAsync(novoCliente);
                await context.SaveChangesAsync();

                return Results.Ok(new ClienteDto(novoCliente.Nome, novoCliente.Cpf, novoCliente.Ativo));
            }).WithName("CadastrarCliente")
            .WithDescription("Todos os campos são obrigatorios");

            //Select clientes
            clienteRoutes.MapGet("/ListarClientes", async (AppDbContext context) =>
            {
                var clientes = await context.Clientes
                .Select(cliente => new ClienteDto(cliente.Nome, cliente.Cpf, cliente.Ativo)).ToListAsync();
                return clientes;
            }).WithName("ListarClientes")
            .WithDescription("Listagem de todos os clientes cadastrados.");

            //Update clientes
            clienteRoutes.MapPut("{Cpf}", async (string Cpf, UpdateClienteRequest request, AppDbContext context) =>
            {
                var updateCliente = await context.Clientes.FindAsync(Cpf);

                if (updateCliente == null)
                    return Results.NotFound();

                updateCliente.AtualizarNome(request.Nome);
                updateCliente.AtualizarCpf(request.Cpf);
                updateCliente.AtualizarAtivo(request.IsAtivo);
                updateCliente.AtualizarEndereco(request.Endereco);
                updateCliente.AtualizarNmrResidencial(request.NmrResidencial);
                updateCliente.AtualizarBairro(request.Bairro);
                updateCliente.AtualizarCidade(request.Cidade);
                updateCliente.AtualizarComorbidade(request.PossuiComorbidade);

                await context.SaveChangesAsync();

                return Results.Ok(new ClienteDto(updateCliente.Nome, updateCliente.Cpf, updateCliente.Ativo));
            }).WithName("AtualizarCliente")
            .WithDescription("Atualiza todos os campos de um cliente.");
        }
    }

}
