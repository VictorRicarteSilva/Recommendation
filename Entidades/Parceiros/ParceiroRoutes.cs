using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recommendation.Data;
using Recommendation.Entidades.Parceiros;
using Recommendation.Entidades.Parceiros.Requests;

namespace Recommendation.Entidades.Parceiros
{
    [ApiExplorerSettings(GroupName = "Parceiros")]
    public static class ParceiroRoutes
    {
        public static void AddParceiroRoutes(this WebApplication app)
        {

            var ParceiroRoutes = app.MapGroup("Parceiros");

            //Insert Parceiros
            ParceiroRoutes.MapPost("/Cadastrar Parceiros", async (AddParceiroRequest request, AppDbContext context) =>
            {
                var novoNutricionista = new Parceiro(request.Nome, request.Profissao, request.Email, request.Numero, request.Senha);
                await context.Parceiros.AddAsync(novoNutricionista);
                await context.SaveChangesAsync();

                return Results.Ok(novoNutricionista);
            }).WithName("Cadastrar Parceiros")
              .WithDescription("Todos os campos são obrigatorios.");

            //Select Parceiros
            ParceiroRoutes.MapGet("/Listar Parceiros", async (AppDbContext context) =>
            {
                var Parceiros = await context.Parceiros.ToListAsync();
                return Parceiros;
            }).WithName("Listar Parceiros")
            .WithDescription("Listagem de todos os Parceiros.");

            ParceiroRoutes.MapPut("{id}", async (Guid id, UpdateParceiroRequest request, AppDbContext context) =>
            {
                var updateParceiro = await context.Parceiros.FindAsync(id);
                if (updateParceiro == null)
                    return Results.NotFound();

                updateParceiro.AtualizarNome(request.Nome);
                updateParceiro.AtualizarProfissao(request.Profissao);
                updateParceiro.AtualizarEmail(request.Email);
                updateParceiro.AtualizarNumero(request.Numero);

                await context.SaveChangesAsync();
                return Results.Ok(updateParceiro);
            }).WithName("Atualizar Cadastro de Parceiro")
            .WithDescription("Atualiza todos os campos do registro de um Parceiro.");
        }
    }
}
