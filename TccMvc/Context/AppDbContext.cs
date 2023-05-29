using Microsoft.EntityFrameworkCore;
using TccMvc.Models;
namespace TccMvc.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Aluguel> Aluguel { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<AluguelProduto> AluguelProduto { get; set; }
        public DbSet<CarrinhoDeComprasItem> CarrinhoDeCompras { get; set; }






    }
}