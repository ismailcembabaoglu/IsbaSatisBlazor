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
    public class ProductGroupController : ControllerBase
    {
        private readonly IProductGroupService productGroupService;
        public ProductGroupController(IProductGroupService ProductGroupService)
        {
            productGroupService = ProductGroupService;
        }
        [HttpGet("ProductGroups")]
        public async Task<ServiceResponse<List<ProductGroupDTO>>> GetProductGroups()
        {
            return new ServiceResponse<List<ProductGroupDTO>>()
            {
                Value = await productGroupService.GetProductGroups()
            };
        }
        [HttpPost("Create")]
        public async Task<ServiceResponse<ProductGroupDTO>> CreateProductGroup([FromBody] ProductGroupDTO productGroup)
        {
            return new ServiceResponse<ProductGroupDTO>()
            {
                Value = await productGroupService.CreateProductGroup(productGroup)
            };
        }
        [HttpPost("Update")]
        public async Task<ServiceResponse<ProductGroupDTO>> UpdateProductGroup([FromBody] ProductGroupDTO productGroup)
        {
            return new ServiceResponse<ProductGroupDTO>()
            {
                Value = await productGroupService.UpdateProductGroup(productGroup)
            };
        }
    }
}
