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
    [Authorize(Roles = RoleExtension.PaymentType)]
    public class PaymentTypeController : ControllerBase
    {
        private readonly IPaymentTypeService paymentTypeService;
        public PaymentTypeController(IPaymentTypeService PaymentTypeService)
        {
            paymentTypeService = PaymentTypeService;
        }

        [HttpGet("PaymentTypes")]
        public async Task<ServiceResponse<List<PaymentTypeDTO>>> GetPaymentTypes()
        {
            return new ServiceResponse<List<PaymentTypeDTO>>()
            {
                Value = await paymentTypeService.GetPaymentTypes()
            };
        }
        [HttpPost("Create")]
        public async Task<ServiceResponse<PaymentTypeDTO>> CreatePaymentType([FromBody] PaymentTypeDTO paymentType)
        {
            return new ServiceResponse<PaymentTypeDTO>()
            {
                Value = await paymentTypeService.CreatePaymentType(paymentType)
            };
        }
        [HttpPost("Update")]
        public async Task<ServiceResponse<PaymentTypeDTO>> UpdatePaymentType([FromBody] PaymentTypeDTO paymentType)
        {
            return new ServiceResponse<PaymentTypeDTO>()
            {
                Value = await paymentTypeService.UpdatePaymentType(paymentType)
            };
        }
        [HttpGet("PaymentTypeById/{Id}")]
        public async Task<ServiceResponse<PaymentTypeDTO>> GetPaymentTypeById(Guid Id)
        {
            return new ServiceResponse<PaymentTypeDTO>()
            {
                Value = await paymentTypeService.GetPaymentTypeById(Id)
            };
        }
        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeletePaymentType([FromBody] Guid id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await paymentTypeService.DeletePaymentTypeId(id)
            };
        }
    }
}
