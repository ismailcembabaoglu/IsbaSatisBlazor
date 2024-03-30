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
    [Authorize(Roles = RoleExtension.Customer)]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;
        public CustomerController(ICustomerService CustomerService)
        {

            customerService = CustomerService;
        }

        [HttpGet("Customers")]
        public async Task<ServiceResponse<List<CustomerDTO>>> GetCustomers()
        {
            return new ServiceResponse<List<CustomerDTO>>()
            {
                Value = await customerService.GetCustomers()
            };
        }
        
       
        [HttpPost("Create")]
        public async Task<ServiceResponse<CustomerDTO>> CreateCustomer([FromBody] CustomerDTO customer)
        {
            return new ServiceResponse<CustomerDTO>()
            {
                Value = await customerService.CreateCustomer(customer)
            };
        }
        [HttpPost("Update")]
        public async Task<ServiceResponse<CustomerDTO>> UpdateCustomer([FromBody] CustomerDTO customer)
        {
            return new ServiceResponse<CustomerDTO>()
            {
                Value = await customerService.UpdateCustomer(customer)
            };
        }
        [HttpGet("CustomerById/{Id}")]
        public async Task<ServiceResponse<CustomerDTO>> GetUCustomerById(Guid Id)
        {
            return new ServiceResponse<CustomerDTO>()
            {
                Value = await customerService.GetUCustomerById(Id)
            };
        }
        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeleteCustomer([FromBody] Guid id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await customerService.DeleteCustomerById(id)
            };
        }
    }
}
