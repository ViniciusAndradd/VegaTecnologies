using CrudVega.Context;
using CrudVega.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

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

        public void DeleteSupplier(int id)
        {
            var supplier = GetSupplier(id);
            if (supplier != null)
            {
                //Tratamento de exceção aqui para exclusão de fornecedor. Tem produto vinculado ao fornecedor e esse motivo não o deixa excluir o fornecedor
                _context.Suppliers.Remove(supplier);
                _context.SaveChanges();
            }
        }

        public void UpdateSupplier(SupplierModel supplier)
        {
            _context.Suppliers.Update(supplier);
            _context.SaveChanges();
        }

        public IEnumerable<SupplierModel> GetAllSuppliers()
        {
            return _context.Suppliers.ToList();
        }

        public SupplierModel GetSupplier(int id)
        {
            var supplier = _context.Suppliers.FirstOrDefault(s => s.Id == id);
            if (supplier == null)
            {
                return null;
            }
            else
            {
                return supplier;
            }
        }
    }
}
