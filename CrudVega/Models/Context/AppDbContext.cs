using Microsoft.EntityFrameworkCore;
namespace CrudVega.Models.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Material> Materials { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
    }
}
