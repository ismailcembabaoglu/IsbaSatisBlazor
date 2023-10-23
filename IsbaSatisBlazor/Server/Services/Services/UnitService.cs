using AutoMapper;
using AutoMapper.QueryableExtensions;
using IsbaSatisBlazor.Data.Context;
using IsbaSatisBlazor.Data.Models;
using IsbaSatisBlazor.Server.Services.Infrastruce;
using IsbaSatisBlazor.Shared.DTO;
using Microsoft.EntityFrameworkCore;

namespace IsbaSatisBlazor.Server.Services.Services
{
    public class UnitService : IUnitService
    {
        private readonly IMapper mapper;
        private readonly IsbaSatisDbContext context;
        private readonly IConfiguration configuration;
        public UnitService(IMapper Mapper, IsbaSatisDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;
        }
        public async Task<UnitDTO> CreateUnit(UnitDTO Unit)
        {
            var dbUnit = await context.Units.Where(i => i.Id == Unit.Id).FirstOrDefaultAsync();

            if (dbUnit == null)
                throw new Exception("Birim Zaten Mevcut");


            dbUnit = mapper.Map<Data.Models.Unit>(Unit);
            dbUnit.CreateDate = DateTime.Now;
            await context.Units.AddAsync(dbUnit);
            int result = await context.SaveChangesAsync();

            return mapper.Map<UnitDTO>(dbUnit);
        }

        public async Task<bool> DeleteUnitId(Guid Id)
        {
            var dbUnit = await context.Units.Where(i => i.Id == Id).FirstOrDefaultAsync();

            if (dbUnit != null)
                throw new Exception("Birim Bulunamadı");
            context.Units.Remove(dbUnit);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<UnitDTO> GetUnitById(Guid Id)
        {
            return await context.Units
                 .Where(i => i.Id == Id)
                 .ProjectTo<UnitDTO>(mapper.ConfigurationProvider)
                 .FirstOrDefaultAsync();
        }

        public async Task<List<UnitDTO>> GetUnits()
        {
            return await context.Units
                   .ProjectTo<UnitDTO>(mapper.ConfigurationProvider)
                   .ToListAsync();
        }

        public async Task<UnitDTO> UpdateUnit(UnitDTO Unit)
        {
            var dbUnit = await context.Products.Where(i => i.Id == Unit.Id).FirstOrDefaultAsync();

            if (dbUnit == null)
                throw new Exception("Birim bulunamadı");


            mapper.Map(Unit, dbUnit);

            int result = await context.SaveChangesAsync();

            return mapper.Map<UnitDTO>(dbUnit);
        }
    }
}
