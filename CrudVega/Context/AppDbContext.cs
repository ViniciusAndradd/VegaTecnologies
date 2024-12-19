using CrudVega.Models;
using Microsoft.EntityFrameworkCore;
namespace CrudVega.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<MaterialModel> Materials { get; set; }
        public DbSet<SupplierModel> Suppliers { get; set; }
    }
}
