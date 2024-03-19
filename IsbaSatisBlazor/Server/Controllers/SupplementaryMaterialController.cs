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
    [Authorize(Roles =RoleExtension.SupplementaryMeterial)]
    public class SupplementaryMaterialController : ControllerBase
    {
        private readonly ISupplementaryMaterialService supplementaryMaterialService;
        public SupplementaryMaterialController(ISupplementaryMaterialService SupplementaryMaterialService)
        {
            supplementaryMaterialService = SupplementaryMaterialService;
        }
        [HttpGet("SupplementaryMaterials")]
        public async Task<ServiceResponse<List<SupplementaryMaterialDTO>>> GetSupplementaryMaterials()
        {
            return new ServiceResponse<List<SupplementaryMaterialDTO>>()
            {
                Value = await supplementaryMaterialService.GetSupplementaryMaterials()
            };
        }
        [HttpGet("SupplementaryMaterialsById/{Id}")]
        public async Task<ServiceResponse<List<SupplementaryMaterialDTO>>> GetSupplementaryMaterialsById(Guid Id)
        {
            return new ServiceResponse<List<SupplementaryMaterialDTO>>()
            {
                Value = await supplementaryMaterialService.GetSupplementaryMaterialsById(Id)
            };
        }
        [HttpPost("Create")]
        public async Task<ServiceResponse<SupplementaryMaterialDTO>> CreateSupplementaryMaterial([FromBody] SupplementaryMaterialDTO supplementaryMaterial)
        {
            return new ServiceResponse<SupplementaryMaterialDTO>()
            {
                Value = await supplementaryMaterialService.CreateSupplementaryMaterial(supplementaryMaterial)
            };
        }
        [HttpPost("Update")]
        public async Task<ServiceResponse<SupplementaryMaterialDTO>> UpdateSupplementaryMaterial([FromBody] SupplementaryMaterialDTO supplementaryMaterial)
        {
            return new ServiceResponse<SupplementaryMaterialDTO>()
            {
                Value = await supplementaryMaterialService.UpdateSupplementaryMaterial(supplementaryMaterial)
            };
        }
        [HttpGet("SupplementaryMaterialById/{Id}")]
        public async Task<ServiceResponse<SupplementaryMaterialDTO>> GetSupplementaryMaterialById(Guid Id)
        {
            return new ServiceResponse<SupplementaryMaterialDTO>()
            {
                Value = await supplementaryMaterialService.GetSupplementaryMaterialById(Id)
            };
        }
        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeleteSupplementaryMaterial([FromBody] Guid id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await supplementaryMaterialService.DeleteSupplementaryMaterialId(id)
            };
        }
    }
}
