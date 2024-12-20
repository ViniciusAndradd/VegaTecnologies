using CrudVega.Models;

namespace CrudVega.Repositories
{
    public interface ISupplierRepository
    {
        public SupplierModel CreateSupplier(SupplierModel supplier);
        public IEnumerable<SupplierModel> GetAllSuppliers();
        public SupplierModel GetSupplier(int id);
        public void EditSupplier(SupplierModel supplier);
        public void DeleteSupplier(int id);

    }
}
