using CrudVega.Models;
using Microsoft.AspNetCore.Mvc;
using CrudVega.Context;
using CrudVega.Repositories;
using System.Runtime.ConstrainedExecution;

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
        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSupplier(SupplierModel supplier)
        {
            supplier.CreatedAt = DateTime.Now;
            supplier.QrCode = $"%{supplier.CNPJ}% - %{supplier.CEP}% / CAD.%{supplier.CreatedAt}%";

            _supplierRepository.CreateSupplier(supplier);
            return RedirectToAction("Index");
        }
    }
}
