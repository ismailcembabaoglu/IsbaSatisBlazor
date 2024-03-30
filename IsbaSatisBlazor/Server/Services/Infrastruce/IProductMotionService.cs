using IsbaSatisBlazor.Shared.DTO;

namespace IsbaSatisBlazor.Server.Services.Infrastruce
{
    public interface IProductMotionService
    {
        public Task<ProductMotionDTO> GetProductMotionById(Guid Id);

        public Task<List<ProductMotionDTO>> GetProductMotions();
        public Task<List<ProductMotionDTO>> GetProductMotionsById(Guid Id);

        public Task<ProductMotionDTO> CreateProductMotion(ProductMotionDTO ProductMotion);

        public Task<ProductMotionDTO> UpdateProductMotion(ProductMotionDTO ProductMotion);

        public Task<bool> DeleteProductMotionId(Guid Id);
    }
}
