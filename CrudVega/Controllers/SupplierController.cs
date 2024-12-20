using CrudVega.Models;
using Microsoft.AspNetCore.Mvc;
using CrudVega.Repositories;

namespace CrudVega.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierController(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<SupplierModel> suppliers = _supplierRepository.GetAllSuppliers();

            return View(suppliers);
        }
        public IActionResult Edit(int id)
        {
            var supplier = _supplierRepository.GetSupplier(id);
            if (supplier != null)
            {
                return View(supplier);
            }
            else
            {
                return View();
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            var supplier = _supplierRepository.GetSupplier(id);
            if (supplier != null)
            {
                return View(supplier);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult CreateSupplier(SupplierModel supplier)
        {
            supplier.CreatedAt = DateTime.Now;
            supplier.QrCode = $"%{supplier.CNPJ}% - %{supplier.CEP}% / CAD.%{supplier.CreatedAt}%";

            _supplierRepository.CreateSupplier(supplier);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteSupplier(int id)
        {
            _supplierRepository.DeleteSupplier(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditSupplier(SupplierModel supplier)
        {
            _supplierRepository.EditSupplier(supplier);
            return RedirectToAction("Index");
        }
    }
}
