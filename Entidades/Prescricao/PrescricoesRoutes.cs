using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Recommendation.Data;
using Recommendation.Entidades.Prescricao.Requests;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;
using QuestPDF.Companion;

QuestPDF.Settings.License = LicenseType.Community;

namespace Recommendation.Entidades.Prescricao
{
    public static class PrescricoesRoutes
    {
        public static void AddPrescricoesRoutes(this WebApplication app)
        {
            var PrescricoesRoutes = app.MapGroup("Prescrições");

            //Insert Prescrições
            PrescricoesRoutes.MapPost("/CadastrarNovaPrescrição", async (AddPrescricoesRequest request, AppDbContext context) =>
            {
                var novaPrescricao = new Prescricoes(request.PrescritoPor, request.PrescritoPara, request.Cpf);
                await context.Prescricoes.AddAsync(novaPrescricao);
                await context.SaveChangesAsync();
                return Results.Ok();
            }).WithName("CadastrarNovaPrescrição")
            .WithDescription("Cadastro de cliente e receita obrigatorios.");

            PrescricoesRoutes.MapPost("/{Cpf}", async (string Cpf, AddItensRequest request, AppDbContext context) =>
            {
                var Prescricao = await context.Prescricoes.FindAsync(Cpf);
                if (Prescricao == null)
                    return Results.NotFound();
                Prescricao.AddItens(request.Nome, request.Marca, request.Disponivel, request.Valor);
                await context.SaveChangesAsync();
                return Results.Ok();

            }).WithName("AdicionarItensPrescrição")
            .WithDescription("Insere receitas a lista de receitas da prescrição.");

            PrescricoesRoutes.MapGet("/Listar Prescrições", async (AppDbContext context) =>
            {
                var Prescricoes = await context.Prescricoes.ToListAsync();
                return Prescricoes;
            }).WithName("ListarPrescrições")
            .WithDescription("Listagem de todas as prescrições cadastradas.");

            PrescricoesRoutes.MapPut("{Cpf} finalizado", async (string Cpf, AppDbContext context) =>
            {
                var updatePrescricao = await context.Prescricoes.FindAsync(Cpf);
                if (updatePrescricao == null)
                    return Results.NotFound();
                updatePrescricao.AtualizarStatusFinalizado();

                await context.SaveChangesAsync();
                return Results.Ok(updatePrescricao);
            }).WithName("AtualizarPrescriçõesFinalizada")
            .WithDescription("Atualiza o status de compra, e lança o horario em que o pagamento foi confirmado");

            PrescricoesRoutes.MapPut("{Cpf} Cancelado", async (string Cpf, AppDbContext context) =>
            {
                var updatePrescricao = await context.Prescricoes.FindAsync(Cpf);
                if (updatePrescricao == null)
                    return Results.NotFound();
                updatePrescricao.AtualizarStatusCancelado();

                await context.SaveChangesAsync();
                return Results.Ok(updatePrescricao);
            }).WithName("AtualizarPrescriçõesCancelada")
            .WithDescription("Atualiza o status de compra, e lança o horario em que o pagamento foi confirmado");

            PrescricoesRoutes.MapGet("/GerarPDF", async (AppDbContext context) =>
            {
                await Document.Create(container =>
                      {

                      }).ShowInCompanionAsync();
            });
        }
    }
}
