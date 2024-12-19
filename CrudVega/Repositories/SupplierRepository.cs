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

        //public SupplierModel GetSupplier(int Id)
        //{
        //    var supplier = _context.Suppliers.FirstOrDefault(x => x.Id == Id);

        //    return supplier;
        //}

        public IEnumerable<SupplierModel> GetAllSuppliers()
        {
            return _context.Suppliers.ToList();
        }
    }
}
