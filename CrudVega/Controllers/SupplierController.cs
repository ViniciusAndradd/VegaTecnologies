﻿using CrudVega.Models;
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
        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Delete(SupplierModel supplier)
        {
            return View(supplier);
        }

        [HttpPost]
        public IActionResult CreateSupplier(SupplierModel supplier)
        {
            supplier.CreatedAt = DateTime.Now;
            supplier.QrCode = $"%{supplier.CNPJ}% - %{supplier.CEP}% / CAD.%{supplier.CreatedAt}%";

            _supplierRepository.CreateSupplier(supplier);
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public IActionResult DeleteSupplier(SupplierModel supplier)
        {
            _supplierRepository.DeleteSupplier(supplier);
            return RedirectToAction("Index");
        }
    }
}
