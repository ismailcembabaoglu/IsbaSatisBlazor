using AutoMapper;
using AutoMapper.QueryableExtensions;
using IsbaSatisBlazor.Data.Context;
using IsbaSatisBlazor.Server.Services.Infrastruce;
using IsbaSatisBlazor.Shared.DTO;
using Microsoft.EntityFrameworkCore;

namespace IsbaSatisBlazor.Server.Services.Services
{
    public class CustomerService:ICustomerService
    {
        private readonly IMapper mapper;
        private readonly IsbaSatisDbContext context;
        private readonly IConfiguration configuration;
        public CustomerService(IMapper Mapper, IsbaSatisDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;
        }
        public async Task<CustomerDTO> CreateCustomer(CustomerDTO Customer)
        {
            var dbCustomer = await context.Customers.Where(i => i.Id == Customer.Id).FirstOrDefaultAsync();

            if (dbCustomer != null)
                throw new Exception("Müşteri Zaten Mevcut");


            dbCustomer = mapper.Map<Data.Models.Customer>(Customer);
            dbCustomer.CreateDate = DateTime.Now;
            await context.Customers.AddAsync(dbCustomer);
            int result = await context.SaveChangesAsync();

            return mapper.Map<CustomerDTO>(dbCustomer);
        }

        public async Task<bool> DeleteCustomerById(Guid Id)
        {
            var dbCustomer = await context.Customers.Where(i => i.Id == Id).FirstOrDefaultAsync();

            if (dbCustomer == null)
                throw new Exception("Müşteri Bulunamadı");
            context.Customers.Remove(dbCustomer);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<List<CustomerDTO>> GetCustomers()
        {
            return await context.Customers
                   .ProjectTo<CustomerDTO>(mapper.ConfigurationProvider)
                   .ToListAsync();
        }

        public async Task<CustomerDTO> GetUCustomerById(Guid Id)
        {
            return await context.Customers
                  .Where(i => i.Id == Id)
                  .ProjectTo<CustomerDTO>(mapper.ConfigurationProvider)
                  .FirstOrDefaultAsync();
        }

        public async Task<CustomerDTO> UpdateCustomer(CustomerDTO Customer)
        {
            var dbCustomer = await context.Customers.Where(i => i.Id == Customer.Id).FirstOrDefaultAsync();

            if (dbCustomer == null)
                throw new Exception("Müşteri bulunamadı");


            mapper.Map(Customer, dbCustomer);

            int result = await context.SaveChangesAsync();

            return mapper.Map<CustomerDTO>(dbCustomer);
        }

    }
}
