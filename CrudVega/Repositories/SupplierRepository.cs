using CrudVega.Context;
using CrudVega.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CrudVega.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly AppDbContext _context;
        public SupplierRepository(AppDbContext context) 
        {
            _context = context;
        }
        public SupplierModel CreateSupplier(SupplierModel supplier)
        {
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
            return supplier;
        }

        public void DeleteSupplier(SupplierModel supplier)
        {
            _context.Suppliers.Remove(supplier);
            _context.SaveChanges();
        }

        public IEnumerable<SupplierModel> GetAllSuppliers()
        {
            return _context.Suppliers.ToList();
        }
    }
}
