using AutoMapper;
using AutoMapper.QueryableExtensions;
using IsbaSatisBlazor.Data.Context;
using IsbaSatisBlazor.Data.Models;
using IsbaSatisBlazor.Server.Services.Infrastruce;
using IsbaSatisBlazor.Shared.DTO;
using Microsoft.EntityFrameworkCore;

namespace IsbaSatisBlazor.Server.Services.Services
{
    public class GarsonService : IGarsonService
    {

        private readonly IMapper mapper;
        private readonly IsbaSatisDbContext context;
        private readonly IConfiguration configuration;
        public GarsonService(IMapper Mapper, IsbaSatisDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;

        }
        public async Task<GarsonDTO> CreateGarson(GarsonDTO Garson)
        {
            var dbGarson = await context.Garsons.Where(i => i.Id == Garson.Id).FirstOrDefaultAsync();

            if (dbGarson != null)
                throw new Exception("Garson Zaten Mevcut");


            dbGarson = mapper.Map<Data.Models.Garson>(Garson);
            dbGarson.CreateDate = DateTime.Now;
            await context.Garsons.AddAsync(dbGarson);
            int result = await context.SaveChangesAsync();

            return mapper.Map<GarsonDTO>(dbGarson);
        }

        public async Task<bool> DeleteGarsonId(Guid Id)
        {
            var dbGarson = await context.Garsons.Where(i => i.Id == Id).FirstOrDefaultAsync();

            if (dbGarson == null)
                throw new Exception("Garson Bulunamadı");
            context.Garsons.Remove(dbGarson);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<GarsonDTO> GetGarsonById(Guid Id)
        {
            return await context.Garsons
                .Where(i => i.Id == Id)
                .ProjectTo<GarsonDTO>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<List<GarsonDTO>> GetGarsons()
        {
            return await context.Garsons
                    .ProjectTo<GarsonDTO>(mapper.ConfigurationProvider)
                    .ToListAsync();
        }

        public async Task<List<GarsonDTO>> GetGarsonsById(Guid Id)
        {
            return await context.Garsons
                       .ProjectTo<GarsonDTO>(mapper.ConfigurationProvider)
                       .ToListAsync();
        }

        public async Task<GarsonDTO> UpdateGarson(GarsonDTO Garson)
        {
            var dbGarson = await context.Garsons.Where(i => i.Id == Garson.Id).FirstOrDefaultAsync();

            if (dbGarson == null)
                throw new Exception("Garson bulunamadı");


            mapper.Map(Garson, dbGarson);

            int result = await context.SaveChangesAsync();

            return mapper.Map<GarsonDTO>(dbGarson);
        }
    }
}
