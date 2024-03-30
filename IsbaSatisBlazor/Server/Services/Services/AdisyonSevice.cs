using AutoMapper;
using AutoMapper.QueryableExtensions;
using IsbaSatisBlazor.Data.Context;
using IsbaSatisBlazor.Data.Models;
using IsbaSatisBlazor.Server.Services.Infrastruce;
using IsbaSatisBlazor.Shared.DTO;
using Microsoft.EntityFrameworkCore;

namespace IsbaSatisBlazor.Server.Services.Services
{
    public class AdisyonSevice : IAdisyonSevice
    {

        private readonly IMapper mapper;
        private readonly IsbaSatisDbContext context;
        private readonly IConfiguration configuration;
        public AdisyonSevice(IMapper Mapper, IsbaSatisDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;

        }
        
        public async Task<AdisyonDTO> CreateAdisyon(AdisyonDTO Adisyon)
        {
            var dbAdisyon = await context.Adisyons.Where(i => i.Id == Adisyon.Id).FirstOrDefaultAsync();

            if (dbAdisyon != null)
                throw new Exception("Adisyon Zaten Mevcut");


            dbAdisyon = mapper.Map<Data.Models.Adisyon>(Adisyon);
            dbAdisyon.CreateDate = DateTime.Now;
            await context.Adisyons.AddAsync(dbAdisyon);
            int result = await context.SaveChangesAsync();

            return mapper.Map<AdisyonDTO>(dbAdisyon);
        }

        public async Task<bool> DeleteAdisyonId(Guid Id)
        {
            var dbAdisyon = await context.Adisyons.Where(i => i.Id == Id).FirstOrDefaultAsync();

            if (dbAdisyon == null)
                throw new Exception("Adisyon Bulunamadı");
            context.Adisyons.Remove(dbAdisyon);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<AdisyonDTO> GetAdisyonById(Guid Id)
        {
            return await context.Adisyons
                .Where(i => i.Id == Id).Include(c => c.Customer).Include(c => c.Desk).Include(c=>c.Garson)
                .ProjectTo<AdisyonDTO>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<List<AdisyonDTO>> GetAdisyons()
        {
            return await context.Adisyons.Include(c => c.Customer).Include(c => c.Desk).Include(c=>c.Garson)
                    .ProjectTo<AdisyonDTO>(mapper.ConfigurationProvider)
                    .ToListAsync();
        }

        public async Task<List<AdisyonDTO>> GetAdisyonsById(Guid Id)
        {
            return await context.Adisyons.Include(c => c.Customer).Include(c => c.Desk).Include (c => c.Garson)
                      .Where(c => c.CustomerId == Id)
                      .ProjectTo<AdisyonDTO>(mapper.ConfigurationProvider)
                      .ToListAsync();
        }

        public async Task<AdisyonDTO> UpdateAdisyon(AdisyonDTO Adisyon)
        {
            var dbAdisyon = await context.Adisyons.Where(i => i.Id == Adisyon.Id).FirstOrDefaultAsync();

            if (dbAdisyon == null)
                throw new Exception("Adisyon bulunamadı");


            mapper.Map(Adisyon, dbAdisyon);

            int result = await context.SaveChangesAsync();

            return mapper.Map<AdisyonDTO>(dbAdisyon);
        }
    }
}
