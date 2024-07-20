using Microsoft.EntityFrameworkCore;
using TesteVize.Models;

namespace TesteVize.Data
{
    public class ProdutosDBContext : DbContext
    {
        public ProdutosDBContext (DbContextOptions<ProdutosDBContext> options)
            : base(options)
        {

        }

        public DbSet <ProdutoModel> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
