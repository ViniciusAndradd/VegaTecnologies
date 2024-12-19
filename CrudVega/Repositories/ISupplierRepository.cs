using CrudVega.Models;

namespace CrudVega.Repositories
{
    public interface ISupplierRepository
    {
        public SupplierModel CreateSupplier(SupplierModel supplier);
        public IEnumerable<SupplierModel> GetAllSuppliers();
        public void DeleteSupplier(SupplierModel supplier);
    }
}
