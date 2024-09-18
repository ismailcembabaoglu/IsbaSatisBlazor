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
    [Authorize(Roles = RoleExtension.Desk)]
    public class DeskController : ControllerBase
    {
        private readonly IDeskSevice deskService;
        public DeskController(IDeskSevice DeskService)
        {
            deskService = DeskService;
        }
        [HttpGet("Desks")]
        public async Task<ServiceResponse<List<DeskDTO>>> GetDesks()
        {
            return new ServiceResponse<List<DeskDTO>>()
            {
                Value = await deskService.GetDesks()
            };
        }
        [HttpPost("Create")]
        public async Task<ServiceResponse<DeskDTO>> CreateDesk([FromBody] DeskDTO desk)
        {
            return new ServiceResponse<DeskDTO>()
            {
                Value = await deskService.CreateDesk(desk)
            };
        }
        [HttpPost("Update")]
        public async Task<ServiceResponse<DeskDTO>> UpdateDesk([FromBody] DeskDTO desk)
        {
            return new ServiceResponse<DeskDTO>()
            {
                Value = await deskService.UpdateDesk(desk)
            };
        }
        [HttpGet("DeskById/{Id}")]
        public async Task<ServiceResponse<DeskDTO>> GetDeskById(Guid Id)
        {
            return new ServiceResponse<DeskDTO>()
            {
                Value = await deskService.GetDeskById(Id)
            };
        }
        [HttpGet("DesksById/{DeskLocationId}")]
        public async Task<ServiceResponse<List<DeskDTO>>> GetDesksById(Guid DeskLocationId)
        {
            return new ServiceResponse<List<DeskDTO>>()
            {
                Value = await deskService.GetDesksById(DeskLocationId)
            };
        }
        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeleteDeskId([FromBody] Guid id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await deskService.DeleteDeskId(id)
            };
        }
    }
}
