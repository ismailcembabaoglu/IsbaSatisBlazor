using IsbaSatisBlazor.Data.Models;
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
    [Authorize(Roles = RoleExtension.SupplementaryMaterialMotion)]
    public class SupplementaryMaterialMotionController : ControllerBase
    {
        private readonly ISupplementaryMaterialMotionService supplementaryMaterialMotionService;
        public SupplementaryMaterialMotionController(ISupplementaryMaterialMotionService SupplementaryMaterialMotionService)
        {
            supplementaryMaterialMotionService = SupplementaryMaterialMotionService;
        }
        [HttpGet("SupplementaryMaterialMotion")]
        public async Task<ServiceResponse<List<SupplementaryMaterialMotionDTO>>> GetSupplementaryMaterialMotions()
        {
            return new ServiceResponse<List<SupplementaryMaterialMotionDTO>>()
            {
                Value = await supplementaryMaterialMotionService.GetSupplementaryMaterialMotions()
            };
        }
        [HttpPost("Create")]
        public async Task<ServiceResponse<SupplementaryMaterialMotionDTO>> CreateSupplementaryMaterialMotion([FromBody] SupplementaryMaterialMotionDTO supplementaryMaterialMotion)
        {
            return new ServiceResponse<SupplementaryMaterialMotionDTO>()
            {
                Value = await supplementaryMaterialMotionService.CreateSupplementaryMaterialMotion(supplementaryMaterialMotion)
            };
        }
        [HttpPost("Update")]
        public async Task<ServiceResponse<SupplementaryMaterialMotionDTO>> UpdateSupplementaryMaterialMotion([FromBody] SupplementaryMaterialMotionDTO supplementaryMaterialMotion)
        {
            return new ServiceResponse<SupplementaryMaterialMotionDTO>()
            {
                Value = await supplementaryMaterialMotionService.UpdateSupplementaryMaterialMotion(supplementaryMaterialMotion)
            };
        }
        [HttpGet("SupplementaryMaterialMotionById/{Id}")]
        public async Task<ServiceResponse<SupplementaryMaterialMotionDTO>> GetSupplementaryMaterialMotionById(Guid Id)
        {
            return new ServiceResponse<SupplementaryMaterialMotionDTO>()
            {
                Value = await supplementaryMaterialMotionService.GetSupplementaryMaterialMotionById(Id)
            };
        }
        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeleteSupplementaryMaterialMotion([FromBody] Guid id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await supplementaryMaterialMotionService.DeleteSupplementaryMaterialMotionId(id)
            };
        }
    }
}
