using Microsoft.EntityFrameworkCore;
using Recommendation.Entidades.Cliente;
using Recommendation.Entidades.Nutricionista;
using Recommendation.Entidades.Prescricao;
using Recommendation.Entidades.Receita;
using Recommendation.Entidades.Recepcionista;
namespace Recommendation.Data
{
    public class AppDbContext : DbContext
    {
        private IConfiguration _configuration;
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Receitas> Receitas { get; set; }
        public DbSet<Nutricionista> Nutricionistas { get; set; }
        public DbSet<Recepcionista> Recepcionistas { get; set; }
        public DbSet<Prescricoes> Prescricoes { get; set; } 

        public AppDbContext(IConfiguration configuration, DbContextOptions options) : base(options)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var typeDataBase = _configuration["TypeDataBase"];
            var connectionString = _configuration.GetConnectionString(typeDataBase);
            optionsBuilder.UseNpgsql(connectionString);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    //modelBuilder.Entity<Prescricoes>()
        //    //    .HasKey(p => new { p.ClienteId, p.ReceitaId });
        //    //modelBuilder.Entity<Prescricoes>()
        //    //    .HasOne(p => p.NomeCliente)
        //    //    .WithMany(c => c.ClientePrescricoes)
        //    //    .HasForeignKey(p => p.ClienteId);
        //    //modelBuilder.Entity<Prescricoes>()
        //    //    .HasOne(p => p.NomeReceita)
        //    //    .WithMany(r => r.ReceitaPrescricoes)
        //    //    .HasForeignKey(p => p.ReceitaId);
        //}
    }
}
