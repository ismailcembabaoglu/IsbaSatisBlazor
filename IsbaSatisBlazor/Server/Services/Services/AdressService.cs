using AutoMapper;
using AutoMapper.QueryableExtensions;
using IsbaSatisBlazor.Data.Context;
using IsbaSatisBlazor.Server.Services.Infrastruce;
using IsbaSatisBlazor.Shared.DTO;
using Microsoft.EntityFrameworkCore;

namespace IsbaSatisBlazor.Server.Services.Services
{
    public class AdressService:IAdressService
    {
        private readonly IMapper mapper;
        private readonly IsbaSatisDbContext context;
        private readonly IConfiguration configuration;
        public AdressService(IMapper Mapper, IsbaSatisDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;
        }
        public async Task<AdressDTO> CreateAdress(AdressDTO Adress)
        {
            var dbAdress = await context.Addresses.Where(i => i.Id == Adress.Id).FirstOrDefaultAsync();

            if (dbAdress != null)
                throw new Exception("Adres Zaten Mevcut");


            dbAdress = mapper.Map<Data.Models.Address>(Adress);
            dbAdress.CreateDate = DateTime.Now;
            await context.Addresses.AddAsync(dbAdress);
            int result = await context.SaveChangesAsync();

            return mapper.Map<AdressDTO>(dbAdress);
        }

        public async Task<bool> DeleteAdressId(Guid Id)
        {
            var dbAdress = await context.Addresses.Where(i => i.Id == Id).FirstOrDefaultAsync();

            if (dbAdress == null)
                throw new Exception("Adres Bulunamadı");
            context.Addresses.Remove(dbAdress);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<AdressDTO> GetAdressById(Guid Id)
        {
            return await context.Addresses
                .Where(i => i.Id == Id).Include(c => c.Customer).Include(c => c.PhoneAdressType)
                .ProjectTo<AdressDTO>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<List<AdressDTO>> GetAdresss()
        {
            return await context.Addresses.Include(c => c.Customer).Include(c => c.PhoneAdressType)
                    .ProjectTo<AdressDTO>(mapper.ConfigurationProvider)
                    .ToListAsync();
        }

        public async Task<List<AdressDTO>> GetAdresssById(Guid Id)
        {
            return await context.Addresses.Include(c => c.Customer).Include(c => c.PhoneAdressType)
                     .Where(c => c.CustomerId == Id)
                     .ProjectTo<AdressDTO>(mapper.ConfigurationProvider)
                     .ToListAsync();
        }

        public async Task<AdressDTO> UpdateAdress(AdressDTO Adress)
        {
            var dbAdress = await context.Addresses.Where(i => i.Id == Adress.Id).FirstOrDefaultAsync();

            if (dbAdress == null)
                throw new Exception("Adres bulunamadı");


            mapper.Map(Adress, dbAdress);

            int result = await context.SaveChangesAsync();

            return mapper.Map<AdressDTO>(dbAdress);
        }
    }
}
