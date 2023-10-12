using IsbaSatisBlazor.Shared.DTO;

namespace IsbaSatisBlazor.Server.Services.Infrastruce
{
    public interface IProductGroupService
    {
        public Task<ProductGroupDTO> GetUProductGroupById(Guid Id);

        public Task<List<ProductGroupDTO>> GetProductGroups();

        public Task<ProductGroupDTO> CreateProductGroup(ProductGroupDTO ProductGroup);

        public Task<ProductGroupDTO> UpdateProductGroup(ProductGroupDTO ProductGroup);

        public Task<bool> DeleteProductGroupById(Guid Id);
    }
}
