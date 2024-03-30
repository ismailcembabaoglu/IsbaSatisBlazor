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
    [Authorize(Roles = RoleExtension.Adisyon)]
    public class AdisyonController : ControllerBase
    {
        private readonly IAdisyonSevice adisyonService;
        public AdisyonController(IAdisyonSevice AdisyonService)
        {

            adisyonService = AdisyonService;
        }

        [HttpGet("Adisyons")]
        public async Task<ServiceResponse<List<AdisyonDTO>>> GetAdisyons()
        {
            return new ServiceResponse<List<AdisyonDTO>>()
            {
                Value = await adisyonService.GetAdisyons()
            };
        }
        [HttpGet("AdisyonsById/{Id}")]
        public async Task<ServiceResponse<List<AdisyonDTO>>> GetAdisyonsById(Guid Id)
        {
            return new ServiceResponse<List<AdisyonDTO>>()
            {
                Value = await adisyonService.GetAdisyonsById(Id)
            };
        }
        [HttpPost("Create")]
        public async Task<ServiceResponse<AdisyonDTO>> CreateAdisyon([FromBody] AdisyonDTO adisyon)
        {
            return new ServiceResponse<AdisyonDTO>()
            {
                Value = await adisyonService.CreateAdisyon(adisyon)
            };
        }
        [HttpPost("Update")]
        public async Task<ServiceResponse<AdisyonDTO>> UpdateAdisyon([FromBody] AdisyonDTO adisyon)
        {
            return new ServiceResponse<AdisyonDTO>()
            {
                Value = await adisyonService.UpdateAdisyon(adisyon)
            };
        }
        [HttpGet("AdisyonById/{Id}")]
        public async Task<ServiceResponse<AdisyonDTO>> GetAdisyonById(Guid Id)
        {
            return new ServiceResponse<AdisyonDTO>()
            {
                Value = await adisyonService.GetAdisyonById(Id)
            };
        }
        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeleteAdisyon([FromBody] Guid id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await adisyonService.DeleteAdisyonId(id)
            };
        }
    }
}
