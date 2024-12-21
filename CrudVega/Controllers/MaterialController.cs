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

        public IActionResult Edit(int id)
        {
            var material = _materialRepository.GetMaterial(id);
            if (material != null)
            {
                IEnumerable<SupplierModel> suppliers = _supplierRepository.GetAllSuppliers();
                ViewData["Suppliers"] = suppliers;
                return View(material);
            }
            else
            {
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            var material = _materialRepository.GetMaterial(id);
            if (material != null)
            {
                return View(material);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult CreateMaterial(MaterialModel material)
        {
            material.CreatedAt = DateTime.Now;
            material.CreatedBy = "Vinicius";
            material.UpdatedAt = DateTime.Now;
            material.UpdatedBy = "Vinícius";

            _materialRepository.CreateMaterial(material);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateMaterial(MaterialModel material)
        {
            material.UpdatedAt = DateTime.Now;
            material.UpdatedBy = "Vinícius";
            _materialRepository.UpdateMaterial(material);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteMaterial(int id)
        {
            _materialRepository.DeleteMaterial(id);

            return RedirectToAction("Index");
        }
    }
}
