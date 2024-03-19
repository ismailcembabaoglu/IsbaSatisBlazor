using IsbaSatisBlazor.Shared.DTO;

namespace IsbaSatisBlazor.Server.Services.Infrastruce
{
    public interface ICustomerService
    {
        public Task<CustomerDTO> GetUCustomerById(Guid Id);

        public Task<List<CustomerDTO>> GetCustomers();

        public Task<CustomerDTO> CreateCustomer(CustomerDTO Customer);

        public Task<CustomerDTO> UpdateCustomer(CustomerDTO Customer);

        public Task<bool> DeleteCustomerById(Guid Id);
    }
}
