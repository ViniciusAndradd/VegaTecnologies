using CrudVega.Context;
using CrudVega.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudVega.Repositories
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly AppDbContext _context;
        public MaterialRepository(AppDbContext context)
        {
            _context = context;
        }

        public MaterialModel CreateMaterial(MaterialModel material)
        {
            _context.Materials.Add(material);
            _context.SaveChanges();
            return material;
        }

        public IEnumerable<MaterialModel> GetAllMaterials()
        {
            return _context.Materials
            .Select(p => new MaterialModel
            {
                Name = p.Name,
                IdSupplier = p.IdSupplier,
                Code = p.Code,
                FiscalCode = p.FiscalCode,
                Specie = p.Specie,
                CreatedAt = p.CreatedAt
            })
            .AsEnumerable();

        }
    }
}
