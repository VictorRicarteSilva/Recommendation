﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recommendation.Data;
using Recommendation.Entidades.Receita.Requests;

namespace Recommendation.Entidades.Receita
{
    [ApiExplorerSettings (GroupName ="Receitas")]
    public static class ReceitaRoutes
    {
        public static void AddReceitaRoutes(this WebApplication app)
        {
            var receitaRoutes = app.MapGroup("Receitas");

            //Insert receita
            receitaRoutes.MapPost("/ Cadastar Receitas", async (AddReceitaRequest request, AppDbContext context) =>
            {
                var novaReceita =
                new Receitas(request.Nome, request.Descricao, request.Categoria, request.Marca, request.Disponivel);
                await context.Receitas.AddAsync(novaReceita);
                await context.SaveChangesAsync();

                return Results.Ok(novaReceita);
            }).WithName("Cadastar Receitas")
            .WithDescription("Todos os campos exceto Descrição, são obrigatorios.");

            //Select receitas
            receitaRoutes.MapGet("/ Listar Receitas", async (AppDbContext context) =>
            {
                var receitas = await context.Receitas.ToListAsync();
                return receitas;
            }).WithName("Listar Receitas")
            .WithDescription("Listagem de todas as receitas cadastradas.");

            //Update receitas
            receitaRoutes.MapPut("/ Atualizar Receita {id}", async (Guid id, UpdateReceitaRequest request, AppDbContext context) =>
            {
                var upgradeReceita = await context.Receitas.SingleOrDefaultAsync(receita => receita.Id == id);

                if (upgradeReceita == null)
                    return Results.NotFound();

                upgradeReceita.AtualizarNome(request.Nome);
                upgradeReceita.AtualizarDescricao(request.Descricao);
                upgradeReceita.AtualizarCategoria(request.Categoria);
                upgradeReceita.AtualizarMarca(request.Marca);
                upgradeReceita.AtualizarDisponibilidade(request.Disponivel);

                await context.SaveChangesAsync();
                return Results.Ok(upgradeReceita);
            }).WithName("Atualizar Receita")
            .WithDescription("Atualiza todos os campos de uma receita");
        }
    }
}