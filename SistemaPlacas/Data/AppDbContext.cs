using Microsoft.EntityFrameworkCore;
using SistemaPlacas.Models;

namespace SistemaPlacas.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<PedidoModel> Pedidos { get; set; }
        public DbSet<StatusModel> Status { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StatusModel>().HasData(
     new StatusModel { Id = 1, Nome = "Recebimento do Pedido" },
     new StatusModel { Id = 2, Nome = "Análise Técnica" },
     new StatusModel { Id = 3, Nome = "Pré-Produção" },
     new StatusModel { Id = 4, Nome = "Produção" },
     new StatusModel { Id = 5, Nome = "Finalização" }
 );




            base.OnModelCreating(modelBuilder);
        }
    }
}
