using CrudVega.Models;

namespace CrudVega.Repositories
{
    public interface IMaterialRepository
    {
        public IEnumerable<MaterialModel> GetAllMaterials();
        public MaterialModel CreateMaterial(MaterialModel material);
        public MaterialModel GetMaterial(int id);
        public void UpdateMaterial(MaterialModel material);
        public void DeleteMaterial(int id);
    }
}
