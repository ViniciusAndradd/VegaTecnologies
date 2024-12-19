using CrudVega.Models;

namespace CrudVega.Repositories
{
    public interface IMaterialRepository
    {
        public IEnumerable<MaterialModel> GetAllMaterials();
        public MaterialModel CreateMaterial(MaterialModel material);
    }
}
