using DrogaBoa.Model;
using Microsoft.EntityFrameworkCore;

namespace DrogaBoa.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().ToTable("tb_produtos");
        }
        
        public DbSet<Produto> Produtos { get; set; } = null!;
    }
}