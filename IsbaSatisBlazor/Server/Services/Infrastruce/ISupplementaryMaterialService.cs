using IsbaSatisBlazor.Shared.DTO;

namespace IsbaSatisBlazor.Server.Services.Infrastruce
{
    public interface ISupplementaryMaterialService
    {
        public Task<SupplementaryMaterialDTO> GetSupplementaryMaterialById(Guid Id);

        public Task<List<SupplementaryMaterialDTO>> GetSupplementaryMaterials();

        public Task<SupplementaryMaterialDTO> CreateSupplementaryMaterial(SupplementaryMaterialDTO supplementary);

        public Task<SupplementaryMaterialDTO> UpdateSupplementaryMaterial(SupplementaryMaterialDTO supplementary);

        public Task<bool> DeleteSupplementaryMaterialId(Guid Id);
    }
}
