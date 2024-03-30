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
    [Authorize(Roles = RoleExtension.Garson)]
    public class GarsonController : ControllerBase
    {
        private readonly IGarsonService garsonService;
        public GarsonController(IGarsonService GarsonService)
        {
            garsonService = GarsonService;
        }

        [HttpGet("Garsons")]
        public async Task<ServiceResponse<List<GarsonDTO>>> GetGarsonts()
        {
            return new ServiceResponse<List<GarsonDTO>>()
            {
                Value = await garsonService.GetGarsons()
            };
        }
        [HttpPost("Create")]
        public async Task<ServiceResponse<GarsonDTO>> CreatGarson([FromBody] GarsonDTO garson)
        {
            return new ServiceResponse<GarsonDTO>()
            {
                Value = await garsonService.CreateGarson(garson)
            };
        }
        [HttpPost("Update")]
        public async Task<ServiceResponse<GarsonDTO>> UpdateGarson([FromBody] GarsonDTO garson)
        {
            return new ServiceResponse<GarsonDTO>()
            {
                Value = await garsonService.UpdateGarson(garson)
            };
        }
        [HttpGet("GarsonById/{Id}")]
        public async Task<ServiceResponse<GarsonDTO>> GetGarsonById(Guid Id)
        {
            return new ServiceResponse<GarsonDTO>()
            {
                Value = await garsonService.GetGarsonById(Id)
            };
        }
        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeleteGarson([FromBody] Guid id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await garsonService.DeleteGarsonId(id)
            };
        }
    }
}
