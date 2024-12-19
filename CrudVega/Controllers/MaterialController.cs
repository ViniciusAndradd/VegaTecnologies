using CrudVega.Models;
using CrudVega.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CrudVega.Controllers
{
    public class MaterialController : Controller
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly ISupplierRepository _supplierRepository;

        public MaterialController(IMaterialRepository materialRepository, ISupplierRepository supplierRepository)
        {
            _materialRepository = materialRepository;
            _supplierRepository = supplierRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<MaterialModel> materials = _materialRepository.GetAllMaterials();
            return View(materials);
        }

        public IActionResult Create()
        {
            IEnumerable<SupplierModel> suppliers = _supplierRepository.GetAllSuppliers();
            ViewData["Suppliers"] = suppliers;
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateMaterial(MaterialModel material)
        {
            material.CreatedAt = DateTime.Now;
            material.CreatedBy = "Vinicius";

            _materialRepository.CreateMaterial(material);
            return RedirectToAction("Index");
        }
    }
}
