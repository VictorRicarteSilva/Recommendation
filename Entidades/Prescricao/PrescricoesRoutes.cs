using Microsoft.EntityFrameworkCore;
using Recommendation.Data;
using Recommendation.Entidades.Cliente;
using Recommendation.Entidades.Prescricao.Requests;
using Recommendation.Entidades.Receita;

namespace Recommendation.Entidades.Prescricao
{
    public static class PrescricoesRoutes
    {
        public static void AddPrescricoesRoutes(this WebApplication app)
        {
            var PrescricoesRoutes = app.MapGroup("Prescrições");

            //Insert Prescrições
            PrescricoesRoutes.MapPost("/ Cadastrar Nova Prescrição", async (AddPrescricoesRequest request, AppDbContext context) =>
            {
                var novaPrescricao = new Prescricoes(request.PrescritoPor);
                
                var clientePrescricao = new Clientes (request.Cliente.Nome, request.Cliente.Cpf, request.Cliente.Endereco, request.Cliente.NmrResidencial, request.Cliente.Bairro, request.Cliente.Cidade);
                novaPrescricao.NomeCliente = clientePrescricao.Nome;
                novaPrescricao.Cpf = clientePrescricao.Cpf;

                var receitaPrescricao = new Receitas(request.Receita.Nome, request.Receita.Descricao, request.Receita.Categoria, request.Receita.Marca, request.Receita.Disponivel);
                novaPrescricao.NomeReceita = receitaPrescricao.Nome;
                novaPrescricao.Descricao = receitaPrescricao.Descricao;

                await context.Prescricoes.AddAsync(novaPrescricao);
                await context.SaveChangesAsync();
            }).WithName("Cadastrar Nova Prescrição")
            .WithDescription("Cadastro de cliente e receita obrigatorios.");

            PrescricoesRoutes.MapGet("/ Listar Prescrições", async (AppDbContext context) =>
            {
                var Prescricoes = await context.Prescricoes.ToListAsync();
                return Prescricoes;
            }).WithName("Listar Prescrições")
            .WithDescription("Listagem de todas as prescrições cadastradas.");

            PrescricoesRoutes.MapPut("/ Atualizar Prescrições {Id}", async (Guid Id, AppDbContext context) =>
            {
                var updatePrescricao = await context.Prescricoes.SingleOrDefaultAsync(prescricao => prescricao.Id == Id);
                if (updatePrescricao != null)
                    return Results.NotFound();
                updatePrescricao.AtualizarStatus();

                await context.SaveChangesAsync();
                return Results.Ok(updatePrescricao);
            }).WithName("Atualizar Prescrições")
            .WithDescription("Atualiza o status de compra, e lança o horario em que o pagamento foi confirmado");
        }
    }
}
