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
    [Authorize(Roles = RoleExtension.Address)]
    public class AddressController : ControllerBase
    {
        private readonly IAdressService adressService;

        public AddressController(IAdressService AdressService)
        {
            adressService = AdressService;
        }

        [HttpGet("Address")]
        public async Task<ServiceResponse<List<AdressDTO>>> GetAdresss()
        {
            return new ServiceResponse<List<AdressDTO>>()
            {
                Value = await adressService.GetAdresss()
            };
        }
        [HttpGet("AdresssById/{Id}")]
        public async Task<ServiceResponse<List<AdressDTO>>> GetAdresssById(Guid Id)
        {
            return new ServiceResponse<List<AdressDTO>>()
            {
                Value = await adressService.GetAdresssById(Id)
            };
        }
        [HttpPost("Create")]
        public async Task<ServiceResponse<AdressDTO>> CreateAdress([FromBody] AdressDTO adress)
        {
            return new ServiceResponse<AdressDTO>()
            {
                Value = await adressService.CreateAdress(adress)
            };
        }
        [HttpPost("Update")]
        public async Task<ServiceResponse<AdressDTO>> UpdateAdress([FromBody] AdressDTO adress)
        {
            return new ServiceResponse<AdressDTO>()
            {
                Value = await adressService.UpdateAdress(adress)
            };
        }
        [HttpGet("AdressById/{Id}")]
        public async Task<ServiceResponse<AdressDTO>> GetAdressById(Guid Id)
        {
            return new ServiceResponse<AdressDTO>()
            {
                Value = await adressService.GetAdressById(Id)
            };
        }
        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeleteAdress([FromBody] Guid id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await adressService.DeleteAdressId(id)
            };
        }
    }
}
