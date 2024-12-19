using CrudVega.Models;

namespace CrudVega.Repositories
{
    public interface ISupplierRepository
    {
        public SupplierModel CreateSupplier(SupplierModel supplier);
        public IEnumerable<SupplierModel> GetAllSuppliers();
        //public SupplierModel GetSupplier(int Id);
        //public SupplierModel EditSupplier(SupplierModel supplier);
    }
}
