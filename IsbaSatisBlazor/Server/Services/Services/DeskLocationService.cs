using AutoMapper;
using AutoMapper.QueryableExtensions;
using IsbaSatisBlazor.Data.Context;
using IsbaSatisBlazor.Data.Models;
using IsbaSatisBlazor.Server.Services.Infrastruce;
using IsbaSatisBlazor.Shared.DTO;
using Microsoft.EntityFrameworkCore;

namespace IsbaSatisBlazor.Server.Services.Services
{
    public class DeskLocationService : IDeskLocationService
    {

        private readonly IMapper mapper;
        private readonly IsbaSatisDbContext context;
        private readonly IConfiguration configuration;

        public DeskLocationService(IMapper Mapper, IsbaSatisDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;

        }

        public async Task<DeskLocationDTO> CreateDeskLocation(DeskLocationDTO DeskLocation)
        {
            var dbDeskLocation = await context.DeskLocations.Where(i => i.Id == DeskLocation.Id).FirstOrDefaultAsync();

            if (dbDeskLocation != null)
                throw new Exception("Adisyon Lokasyonu Zaten Mevcut");


            dbDeskLocation = mapper.Map<Data.Models.DeskLocation>(DeskLocation);
            dbDeskLocation.CreateDate = DateTime.Now;
            await context.DeskLocations.AddAsync(dbDeskLocation);
            int result = await context.SaveChangesAsync();

            return mapper.Map<DeskLocationDTO>(dbDeskLocation);
        }

        public async Task<bool> DeleteDeskLocationId(Guid Id)
        {
            var dbDeskLocation = await context.DeskLocations.Where(i => i.Id == Id).FirstOrDefaultAsync();

            if (dbDeskLocation == null)
                throw new Exception("Adisyon Lokasyonu Bulunamadı");
            context.DeskLocations.Remove(dbDeskLocation);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<DeskLocationDTO> GetDeskLocationById(Guid Id)
        {
            return await context.DeskLocations
                .Where(i => i.Id == Id)
                .ProjectTo<DeskLocationDTO>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<List<DeskLocationDTO>> GetDeskLocations()
        {
            return await context.DeskLocations
                   .ProjectTo<DeskLocationDTO>(mapper.ConfigurationProvider)
                   .ToListAsync();
        }

        public async Task<List<DeskLocationDTO>> GetDeskLocationsById(Guid Id)
        {
            return await context.DeskLocations
                      
                      .ProjectTo<DeskLocationDTO>(mapper.ConfigurationProvider)
                      .ToListAsync();
        }

        public async Task<DeskLocationDTO> UpdateDeskLocation(DeskLocationDTO DeskLocation)
        {
            var dbDeskLocation = await context.DeskLocations.Where(i => i.Id == DeskLocation.Id).FirstOrDefaultAsync();

            if (dbDeskLocation == null)
                throw new Exception("Adisyon Lokasyonu bulunamadı");


            mapper.Map(DeskLocation, dbDeskLocation);

            int result = await context.SaveChangesAsync();

            return mapper.Map<DeskLocationDTO>(dbDeskLocation);
        }
    }
}
