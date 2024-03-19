using AutoMapper;
using AutoMapper.QueryableExtensions;
using IsbaSatisBlazor.Data.Context;
using IsbaSatisBlazor.Server.Services.Infrastruce;
using IsbaSatisBlazor.Shared.DTO;
using Microsoft.EntityFrameworkCore;

namespace IsbaSatisBlazor.Server.Services.Services
{
    public class PhoneService:IPhoneService
    {
        private readonly IMapper mapper;
        private readonly IsbaSatisDbContext context;
        private readonly IConfiguration configuration;
        public PhoneService(IMapper Mapper, IsbaSatisDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;
        }
        public async Task<PhoneDTO> CreatePhone(PhoneDTO Phone)
        {
            var dbPhone = await context.Phones.Where(i => i.Id == Phone.Id).FirstOrDefaultAsync();

            if (dbPhone != null)
                throw new Exception("Adres Zaten Mevcut");


            dbPhone = mapper.Map<Data.Models.Phone>(Phone);
            dbPhone.CreateDate = DateTime.Now;
            await context.Phones.AddAsync(dbPhone);
            int result = await context.SaveChangesAsync();

            return mapper.Map<PhoneDTO>(dbPhone);
        }

        public async Task<bool> DeletePhoneId(Guid Id)
        {
            var dbPhone = await context.Phones.Where(i => i.Id == Id).FirstOrDefaultAsync();

            if (dbPhone == null)
                throw new Exception("Adres Bulunamadı");
            context.Phones.Remove(dbPhone);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<PhoneDTO> GetPhoneById(Guid Id)
        {
            return await context.Phones
                .Where(i => i.Id == Id).Include(c => c.Customer).Include(c => c.PhoneAdressType)
                .ProjectTo<PhoneDTO>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<List<PhoneDTO>> GetPhones()
        {
            return await context.Phones.Include(c => c.Customer).Include(c => c.PhoneAdressType)
                    .ProjectTo<PhoneDTO>(mapper.ConfigurationProvider)
                    .ToListAsync();
        }

        public async Task<List<PhoneDTO>> GetPhonesById(Guid Id)
        {
            return await context.Phones.Include(c => c.Customer).Include(c => c.PhoneAdressType)
                     .Where(c => c.CustomerId == Id)
                     .ProjectTo<PhoneDTO>(mapper.ConfigurationProvider)
                     .ToListAsync();
        }

        public async Task<PhoneDTO> UpdatePhone(PhoneDTO Phone)
        {
            var dbPhone = await context.Phones.Where(i => i.Id == Phone.Id).FirstOrDefaultAsync();

            if (dbPhone == null)
                throw new Exception("Adres bulunamadı");


            mapper.Map(Phone, dbPhone);

            int result = await context.SaveChangesAsync();

            return mapper.Map<PhoneDTO>(dbPhone);
        }
    }
}
