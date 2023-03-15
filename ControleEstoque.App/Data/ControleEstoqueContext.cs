using ControleEstoque.App.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoque.App.Data
{
  public class ControleEstoqueContext : DbContext
    {
        public ControleEstoqueContext(DbContextOptions<ControleEstoqueContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Client { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
    }
}
