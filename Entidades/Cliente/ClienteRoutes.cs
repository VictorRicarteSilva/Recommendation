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
            clienteRoutes.MapPost("/ Cadastrar Cliente", async (AddClienteRequest request, AppDbContext context) =>
            {
                var novoCliente = new Clientes(request.Nome, request.Cpf, request.Endereco, request.NmrResidencial, request.Bairro, request.Cidade);
                await context.Clientes.AddAsync(novoCliente);
                await context.SaveChangesAsync();

                return Results.Ok(new ClienteDto(novoCliente.Id, novoCliente.Nome, novoCliente.Ativo));
            }).WithName("Cadastrar Cliente")
            .WithDescription("Todos os campos são obrigatorios");

            //Select clientes
            clienteRoutes.MapGet("/ Listar Clientes", async (AppDbContext context) =>
            {
                var clientes = await context.Clientes
                .Select(cliente => new ClienteDto(cliente.Id, cliente.Nome, cliente.Ativo)).ToListAsync();
                return clientes;
            }).WithName("Listar Clientes")
            .WithDescription("Listagem de todos os clientes cadastrados.");

            //Update clientes
            clienteRoutes.MapPut("{Id}", async (Guid Id, UpdateClienteRequest request, AppDbContext context) =>
            {
                var updateCliente = await context.Clientes.FindAsync(Id);

                if (updateCliente == null)
                    return Results.NotFound();

                updateCliente.AtualizarNome(request.Nome);
                updateCliente.AtualizarCpf(request.Cpf);
                updateCliente.AtualizarAtivo(request.IsAtivo);
                updateCliente.AtualizarEndereco(request.Endereco);
                updateCliente.AtualizarNmrResidencial(request.NmrResidencial);
                updateCliente.AtualizarBairro(request.Bairro);
                updateCliente.AtualizarCidade(request.Cidade);

                await context.SaveChangesAsync();

                return Results.Ok(new ClienteDto(updateCliente.Id, updateCliente.Nome, updateCliente.Ativo));
            }).WithName("Atualizar Cliente")
            .WithDescription("Atualiza todos os campos de um cliente.");
        }
    }

}
