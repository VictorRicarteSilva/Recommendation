using Recommendation.Entidades;
using Recommendation.Data;
using Recommendation.Entidades.Cliente;
using Recommendation.Entidades.Nutricionista;
using Recommendation.Entidades.Receita;
using Recommendation.Entidades.Recepcionista;
using Recommendation.Entidades.Prescricao;

namespace Recommendation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<AppDbContext>();

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<AppDbContext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            //app.UseAuthorization();

            ClienteRoutes.AddClienteRoutes(app);
            ReceitaRoutes.AddReceitaRoutes(app);
            NutricionistaRoutes.AddNutricionistaRoutes(app);
            RecepcionistaRoutes.AddRecepcionistaRoutes(app);
            PrescricoesRoutes.AddPrescricoesRoutes(app);

            app.Run();
        }
    }
}
