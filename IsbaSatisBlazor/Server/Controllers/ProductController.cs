using IsbaSatisBlazor.Server.Services.Infrastruce;
using IsbaSatisBlazor.Server.Services.Services;
using IsbaSatisBlazor.Shared.DTO;
using IsbaSatisBlazor.Shared.ResponseModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsbaSatisBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductController(IProductService ProductService)
        {
            productService = ProductService;
        }
        [HttpGet("Products")]
        public async Task<ServiceResponse<List<ProductDTO>>> GetProducts()
        {
            return new ServiceResponse<List<ProductDTO>>()
            {
                Value = await productService.GetProducts()
            };
        }
        [HttpPost("Create")]
        public async Task<ServiceResponse<ProductDTO>> CreateProduct([FromBody] ProductDTO product)
        {
            return new ServiceResponse<ProductDTO>()
            {
                Value = await productService.CreateProduct(product)
            };
        }
        [HttpPost("Update")]
        public async Task<ServiceResponse<ProductDTO>> UpdateProduct([FromBody] ProductDTO product)
        {
            return new ServiceResponse<ProductDTO>()
            {
                Value = await productService.UpdateProduct(product)
            };
        }
        [HttpGet("ProductById/{Id}")]
        public async Task<ServiceResponse<ProductDTO>> GetProductById(Guid Id)
        {
            return new ServiceResponse<ProductDTO>()
            {
                Value = await productService.GetUProductById(Id)
            };
        }
        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeleteProduct([FromBody] Guid id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await productService.DeleteProductById(id)
            };
        }
    }
}
