using IsbaSatisBlazor.Shared.DTO;

namespace IsbaSatisBlazor.Server.Services.Infrastruce
{
    public interface IProductService
    {
        public Task<ProductDTO> GetUProductById(Guid Id);

        public Task<List<ProductDTO>> GetProducts();

        public Task<ProductDTO> CreateProduct(ProductDTO Product);

        public Task<ProductDTO> UpdateProduct(ProductDTO Product);

        public Task<bool> DeleteProductById(Guid Id);
    }
}
