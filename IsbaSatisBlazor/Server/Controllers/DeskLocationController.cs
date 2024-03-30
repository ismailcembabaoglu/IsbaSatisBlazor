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
    [Authorize(Roles = RoleExtension.DeskLocation)]
    public class DeskLocationController : ControllerBase
    {
        private readonly IDeskLocationService deskLocationService;
        public DeskLocationController(IDeskLocationService DeskLocationService)
        {
            deskLocationService = DeskLocationService;
        }

        [HttpGet("DeskLocations")]
        public async Task<ServiceResponse<List<DeskLocationDTO>>> GetDeskLocations()
        {
            return new ServiceResponse<List<DeskLocationDTO>>()
            {
                Value = await deskLocationService.GetDeskLocations()
            };
        }
        [HttpPost("Create")]
        public async Task<ServiceResponse<DeskLocationDTO>> CreateDeskLocation([FromBody] DeskLocationDTO deskLocation)
        {
            return new ServiceResponse<DeskLocationDTO>()
            {
                Value = await deskLocationService.CreateDeskLocation(deskLocation)
            };
        }
        [HttpPost("Update")]
        public async Task<ServiceResponse<DeskLocationDTO>> UpdateDeskLocation([FromBody] DeskLocationDTO deskLocation)
        {
            return new ServiceResponse<DeskLocationDTO>()
            {
                Value = await deskLocationService.UpdateDeskLocation(deskLocation)
            };
        }
        [HttpGet("DeskLocationById/{Id}")]
        public async Task<ServiceResponse<DeskLocationDTO>> GetDeskLocationById(Guid Id)
        {
            return new ServiceResponse<DeskLocationDTO>()
            {
                Value = await deskLocationService.GetDeskLocationById(Id)
            };
        }
        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeleteDeskLocation([FromBody] Guid id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await deskLocationService.DeleteDeskLocationId(id)
            };
        }
    }
}
