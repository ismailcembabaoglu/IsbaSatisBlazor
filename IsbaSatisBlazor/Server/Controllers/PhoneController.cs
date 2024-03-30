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
    [Authorize(Roles = RoleExtension.Phone)]
    public class PhoneController : ControllerBase
    {
        private readonly IPhoneService phoneService;
        public PhoneController(IPhoneService PhoneService)
        {
            phoneService = PhoneService;
        }

        [HttpGet("Phones")]
        public async Task<ServiceResponse<List<PhoneDTO>>> GetPhones()
        {
            return new ServiceResponse<List<PhoneDTO>>()
            {
                Value = await phoneService.GetPhones()
            };
        }
        [HttpPost("Create")]
        public async Task<ServiceResponse<PhoneDTO>> CreatePhone([FromBody] PhoneDTO phone)
        {
            return new ServiceResponse<PhoneDTO>()
            {
                Value = await phoneService.CreatePhone(phone)
            };
        }
        [HttpPost("Update")]
        public async Task<ServiceResponse<PhoneDTO>> UpdatePhone([FromBody] PhoneDTO phone)
        {
            return new ServiceResponse<PhoneDTO>()
            {
                Value = await phoneService.UpdatePhone(phone)
            };
        }
        [HttpGet("PhoneById/{Id}")]
        public async Task<ServiceResponse<PhoneDTO>> GetPhoneById(Guid Id)
        {
            return new ServiceResponse<PhoneDTO>()
            {
                Value = await phoneService.GetPhoneById(Id)
            };
        }
        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeletePhone([FromBody] Guid id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await phoneService.DeletePhoneId(id)
            };
        }
    }
}
