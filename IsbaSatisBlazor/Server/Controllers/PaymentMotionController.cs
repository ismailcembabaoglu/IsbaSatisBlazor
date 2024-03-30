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
    [Authorize(Roles = RoleExtension.PaymentMotion)]
    public class PaymentMotionController : ControllerBase
    {
        private readonly IPaymentMotionService paymentMotionService;
        public PaymentMotionController(IPaymentMotionService PaymentMotionService)
        {
            paymentMotionService = PaymentMotionService;
        }

        [HttpGet("PaymentMotions")]
        public async Task<ServiceResponse<List<PaymentMotionDTO>>> GetPaymentMotions()
        {
            return new ServiceResponse<List<PaymentMotionDTO>>()
            {
                Value = await paymentMotionService.GetPaymentMotions()
            };
        }
        [HttpPost("Create")]
        public async Task<ServiceResponse<PaymentMotionDTO>> CreatePaymentMotion([FromBody] PaymentMotionDTO paymentMotion)
        {
            return new ServiceResponse<PaymentMotionDTO>()
            {
                Value = await paymentMotionService.CreatePaymentMotion(paymentMotion)
            };
        }
        [HttpPost("Update")]
        public async Task<ServiceResponse<PaymentMotionDTO>> UpdatePaymentMotion([FromBody] PaymentMotionDTO paymentMotion)
        {
            return new ServiceResponse<PaymentMotionDTO>()
            {
                Value = await paymentMotionService.UpdatePaymentMotion(paymentMotion)
            };
        }
        [HttpGet("PaymentMotionById/{Id}")]
        public async Task<ServiceResponse<PaymentMotionDTO>> GetPaymentMotionById(Guid Id)
        {
            return new ServiceResponse<PaymentMotionDTO>()
            {
                Value = await paymentMotionService.GetPaymentMotionById(Id)
            };
        }
        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeletePaymentMotion([FromBody] Guid id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await paymentMotionService.DeletePaymentMotionId(id)
            };
        }
    }
}
