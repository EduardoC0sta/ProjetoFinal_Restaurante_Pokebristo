using Microsoft.EntityFrameworkCore;
using Sprint3.Models;

namespace Sprint3.Data
{
    public class RestauranteDbContext : DbContext
    {
        public RestauranteDbContext(DbContextOptions<RestauranteDbContext> options) : base(options) { }

        public DbSet<Cardapio> Cardapios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cardapio>().ToTable("cardapio");
            modelBuilder.Entity<Cliente>().ToTable("cliente");
            modelBuilder.Entity<Funcionario>().ToTable("funcionario");
            modelBuilder.Entity<Pedido>().ToTable("pedido");
            modelBuilder.Entity<ItemPedido>().ToTable("item_pedido");
        }
    }
}