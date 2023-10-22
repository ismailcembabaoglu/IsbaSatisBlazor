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
    public class UnitController : ControllerBase
    {
        private readonly IUnitService unitService;
        public UnitController(IUnitService UnitService)
        {
            unitService = UnitService;
        }
        [HttpGet("Units")]
        public async Task<ServiceResponse<List<UnitDTO>>> GetUnits()
        {
            return new ServiceResponse<List<UnitDTO>>()
            {
                Value = await unitService.GetUnits()
            };
        }
        [HttpPost("Create")]
        public async Task<ServiceResponse<UnitDTO>> CreateUnit([FromBody] UnitDTO unit)
        {
            return new ServiceResponse<UnitDTO>()
            {
                Value = await unitService.CreateUnit(unit)
            };
        }
        [HttpPost("Update")]
        public async Task<ServiceResponse<UnitDTO>> UpdateUnit([FromBody] UnitDTO unit)
        {
            return new ServiceResponse<UnitDTO>()
            {
                Value = await unitService.UpdateUnit(unit)
            };
        }
        [HttpGet("UnitById/{Id}")]
        public async Task<ServiceResponse<UnitDTO>> GetUnitById(Guid Id)
        {
            return new ServiceResponse<UnitDTO>()
            {
                Value = await unitService.GetUnitById(Id)
            };
        }
        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeleteUnit([FromBody] Guid id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await unitService.DeleteUnitId(id)
            };
        }
    }
}
