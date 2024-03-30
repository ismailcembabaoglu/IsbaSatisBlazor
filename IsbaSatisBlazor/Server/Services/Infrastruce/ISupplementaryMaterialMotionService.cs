using IsbaSatisBlazor.Shared.DTO;

namespace IsbaSatisBlazor.Server.Services.Infrastruce
{
    public interface ISupplementaryMaterialMotionService
    {
        public Task<SupplementaryMaterialMotionDTO> GetSupplementaryMaterialMotionById(Guid Id);

        public Task<List<SupplementaryMaterialMotionDTO>> GetSupplementaryMaterialMotions();
        public Task<List<SupplementaryMaterialMotionDTO>> GetSupplementaryMaterialMotionsById(Guid Id);

        public Task<SupplementaryMaterialMotionDTO> CreateSupplementaryMaterialMotion(SupplementaryMaterialMotionDTO SupplementaryMaterialMotion);

        public Task<SupplementaryMaterialMotionDTO> UpdateSupplementaryMaterialMotion(SupplementaryMaterialMotionDTO SupplementaryMaterialMotion);

        public Task<bool> DeleteSupplementaryMaterialMotionId(Guid Id);
    }
}
