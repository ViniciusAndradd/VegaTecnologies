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

        public void DeleteMaterial(int id)
        {
            var material = GetMaterial(id);
            if (material != null)
            {
                _context.Materials.Remove(material);
                _context.SaveChanges();
            }
        }

        public IEnumerable<MaterialModel> GetAllMaterials()
        {
            return _context.Materials
            .Select(m => new MaterialModel
            {
                Id = m.Id,
                Name = m.Name,
                IdSupplier = m.IdSupplier,
                Code = m.Code,
                FiscalCode = m.FiscalCode,
                Specie = m.Specie,
                CreatedAt = m.CreatedAt
            })
            .AsEnumerable();
        }

        public MaterialModel GetMaterial(int id)
        {
            var material = _context.Materials.SingleOrDefault(m => m.Id == id);
                
            if (material == null)
            {
                return null;
            }
            else
            {
                return material;
            }
        }

        public void UpdateMaterial(MaterialModel material)
        {
            _context.Materials.Update(material);
            _context.SaveChanges();
        }
    }
}
