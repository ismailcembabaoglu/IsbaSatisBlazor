using IsbaSatisBlazor.Data.Enums;
using IsbaSatisBlazor.Data.Enums.Helper;
using IsbaSatisBlazor.Data.Models;
using IsbaSatisBlazor.Server.Services.Extensions;
using IsbaSatisBlazor.Server.Services.Infrastruce;
using IsbaSatisBlazor.Server.Services.Services;
using IsbaSatisBlazor.Shared.DTO;
using IsbaSatisBlazor.Shared.Extensions;
using IsbaSatisBlazor.Shared.ResponseModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Radzen.Blazor;

namespace IsbaSatisBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles =RoleExtension.Portion)]
    public class PortionController : ControllerBase
    {
        private readonly IPortionService portionService;
        public PortionController(IPortionService PortionService)
        {
         
            portionService= PortionService;
        }
        [HttpGet("Portions")]
        public async Task<ServiceResponse<List<PortionDTO>>> GetPortions()
        {
            return new ServiceResponse<List<PortionDTO>>()
            {
                Value = await portionService.GetPortions()
            };
        }
        [HttpGet("PortionsById/{Id}")]
        public async Task<ServiceResponse<List<PortionDTO>>> GetPortionsById(Guid Id)
        {
            return new ServiceResponse<List<PortionDTO>>()
            {
                Value = await portionService.GetPortionsById(Id)
            };
        }
        [HttpPost("Create")]
        public async Task<ServiceResponse<PortionDTO>> CreatePortion([FromBody] PortionDTO portion)
        {
            return new ServiceResponse<PortionDTO>()
            {
                Value = await portionService.CreatePortion(portion)
            };
        }
        [HttpPost("Update")]
        public async Task<ServiceResponse<PortionDTO>> UpdatePortion([FromBody] PortionDTO portion)
        {
            return new ServiceResponse<PortionDTO>()
            {
                Value = await portionService.UpdatePortion(portion)
            };
        }
        [HttpGet("PortionById/{Id}")]
        public async Task<ServiceResponse<PortionDTO>> GetPortionById(Guid Id)
        {
            return new ServiceResponse<PortionDTO>()
            {
                Value = await portionService.GetPortionById(Id)
            };
        }
        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeletePortion([FromBody] Guid id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await portionService.DeletePortionId(id)
            };
        }
    }
}
