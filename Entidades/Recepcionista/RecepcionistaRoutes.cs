using Microsoft.EntityFrameworkCore;
using Recommendation.Data;
using Recommendation.Entidades.Recepcionista.Requests;

namespace Recommendation.Entidades.Recepcionista
{
    public static class RecepcionistaRoutes
    {
        public static void AddRecepcionistaRoutes(this WebApplication app)
        {
            var RecepcionistaRoutes = app.MapGroup("Recepcionistas");

            //Insert Recepcionistas
            RecepcionistaRoutes.MapPost("/Cadastrar Recepcionistas", async (AddRecepcionistaRequest request, AppDbContext context) =>
            {
                var novoRecepcionista = new Recepcionista(request.Nome, request.Senha);
                await context.Recepcionistas.AddAsync(novoRecepcionista);
                await context.SaveChangesAsync();

                return Results.Ok(novoRecepcionista.Nome);
            }).WithName("Cadastrar Recepcionista")
            .WithDescription("Todos os campos são obrigatorios.");

            RecepcionistaRoutes.MapGet("/Listar Recepcionistas", async (AppDbContext context) =>
            {
                var Recepcionistas = await context.Recepcionistas.ToListAsync();
                return Recepcionistas;
            }).WithName("Listar Recepcionistas")
            .WithDescription("Listagem de todos os Recepcionistas cadastrados.");

            RecepcionistaRoutes.MapPut("{id}", async (Guid id, UpdateRecepcionistaRequest request, AppDbContext context) =>
            {
                var updateRecepcionista = await context.Recepcionistas.FindAsync(id);
                if (updateRecepcionista == null)
                    return Results.NotFound();

                updateRecepcionista.AtualizarNome(request.Nome);
                updateRecepcionista.AtualizarSenha(request.Senha);

                await context.SaveChangesAsync();
                return Results.Ok(updateRecepcionista.Nome);
            }).WithName("Atualizar Recepcionista")
            .WithDescription("Atualiza nome e senha de um recepcionista.");
        }
    }
}
