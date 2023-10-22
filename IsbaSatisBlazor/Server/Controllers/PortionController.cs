using IsbaSatisBlazor.Server.Services.Infrastruce;
using IsbaSatisBlazor.Server.Services.Services;
using IsbaSatisBlazor.Shared.DTO;
using IsbaSatisBlazor.Shared.ResponseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsbaSatisBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
