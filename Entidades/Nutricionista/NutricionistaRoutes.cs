using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recommendation.Data;
using Recommendation.Entidades.Nutricionista.Requests;

namespace Recommendation.Entidades.Nutricionista
{
    [ApiExplorerSettings(GroupName ="Nutricionistas")]
    public static class NutricionistaRoutes
    {
        public static void AddNutricionistaRoutes( this WebApplication app)
        {
            
            var NutricionistaRoutes = app.MapGroup("Nutricionistas");

            //Insert Nutricionistas
            NutricionistaRoutes.MapPost("/ Cadastrar Nutricionistas", async (AddNutricionistaRequest request, AppDbContext context) =>
            {
                var novoNutricionista = new Nutricionista(request.Nome, request.Profissao, request.Email, request.Numero);
                await context.Nutricionistas.AddAsync(novoNutricionista);
                await context.SaveChangesAsync();

                return Results.Ok(novoNutricionista);
            }).WithName("Cadastrar Nutricionista")
              .WithDescription("Todos os campos são obrigatorios.");

            //Select Nutricionistas
            NutricionistaRoutes.MapGet("/ Listar Nutricionistas", async (AppDbContext context) =>
            {
                var Nutricionistas = await context.Nutricionistas.ToListAsync();
                return Nutricionistas;
            }).WithName("Listar Nutricionistas")
            .WithDescription("Listagem de todos os Nutricionistas.");

            NutricionistaRoutes.MapPut("/ Atualizar Nutricionista {id}", async (Guid id, UpdateNutricionistaRequest request, AppDbContext context) =>
            {
                var updateNutricionista = await context.Nutricionistas.SingleOrDefaultAsync(nutricionista =>  nutricionista.Id == id);  
                if(updateNutricionista == null)
                    return Results.NotFound();

                updateNutricionista.AtualizarNome(request.Nome);
                updateNutricionista.AtualizarProfissao(request.Profissao);
                updateNutricionista.AtualizarEmail(request.Email);
                updateNutricionista.AtualizarNumero(request.Numero);

                await context.SaveChangesAsync();
                return Results.Ok(updateNutricionista);
            }).WithName("Atualizar Cadastro de Nutricionista")
            .WithDescription("Atualiza todos os campos do registro de um Nutricionista.");
        }
    }
}
