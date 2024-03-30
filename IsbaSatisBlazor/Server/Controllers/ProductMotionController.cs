using IsbaSatisBlazor.Server.Services.Infrastruce;
using IsbaSatisBlazor.Server.Services.Services;
using IsbaSatisBlazor.Shared.DTO;
using IsbaSatisBlazor.Shared.Extensions;
using IsbaSatisBlazor.Shared.ResponseModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsbaSatisBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = RoleExtension.ProductMotion)]
    public class ProductMotionController : ControllerBase
    {
        private readonly IProductMotionService productMotionService;
        public ProductMotionController(IProductMotionService ProductMotionService)
        {
            productMotionService = ProductMotionService;
        }

        [HttpGet("ProductMotions")]
        public async Task<ServiceResponse<List<ProductMotionDTO>>> GetProductMotions()
        {
            return new ServiceResponse<List<ProductMotionDTO>>()
            {
                Value = await productMotionService.GetProductMotions()
            };
        }
        [HttpPost("Create")]
        public async Task<ServiceResponse<ProductMotionDTO>> CreateProductMotion([FromBody] ProductMotionDTO productMotion)
        {
            return new ServiceResponse<ProductMotionDTO>()
            {
                Value = await productMotionService.CreateProductMotion(productMotion)
            };
        }
        [HttpPost("Update")]
        public async Task<ServiceResponse<ProductMotionDTO>> UpdateProductMotion([FromBody] ProductMotionDTO productMotion)
        {
            return new ServiceResponse<ProductMotionDTO>()
            {
                Value = await productMotionService.UpdateProductMotion(productMotion)
            };
        }
        [HttpGet("ProductMotionById/{Id}")]
        public async Task<ServiceResponse<ProductMotionDTO>> GetProductsMotionById(Guid Id)
        {
            return new ServiceResponse<ProductMotionDTO>()
            {
                Value = await productMotionService.GetProductMotionById(Id)
            };
        }
        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeleteProduct([FromBody] Guid id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await productMotionService.DeleteProductMotionId(id)
            };
        }
    }
}
