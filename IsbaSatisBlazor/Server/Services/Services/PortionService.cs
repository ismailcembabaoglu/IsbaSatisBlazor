using AutoMapper;
using AutoMapper.QueryableExtensions;
using IsbaSatisBlazor.Data.Context;
using IsbaSatisBlazor.Data.Models;
using IsbaSatisBlazor.Server.Services.Infrastruce;
using IsbaSatisBlazor.Shared.DTO;
using Microsoft.EntityFrameworkCore;

namespace IsbaSatisBlazor.Server.Services.Services
{

    public class PortionService : IPortionService
    {
        private readonly IMapper mapper;
        private readonly IsbaSatisDbContext context;
        private readonly IConfiguration configuration;
        public PortionService(IMapper Mapper, IsbaSatisDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;
        }
        public async Task<PortionDTO> CreatePortion(PortionDTO portion)
        {
            var dbPortion = await context.Portions.Where(i => i.Id == portion.Id).FirstOrDefaultAsync();

            if (dbPortion != null)
                throw new Exception("Porsiyon Zaten Mevcut");


            dbPortion = mapper.Map<Data.Models.Portion>(portion);
            dbPortion.CreateDate = DateTime.Now;
            await context.Portions.AddAsync(dbPortion);
            int result = await context.SaveChangesAsync();

            return mapper.Map<PortionDTO>(dbPortion);
        }

        public async Task<bool> DeletePortionId(Guid Id)
        {
            var dbPortion = await context.Portions.Where(i => i.Id == Id).FirstOrDefaultAsync();

            if (dbPortion == null)
                throw new Exception("Porsiyon Bulunamadı");
            context.Portions.Remove(dbPortion);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<PortionDTO> GetPortionById(Guid Id)
        {
            return await context.Portions
                .Where(i => i.Id == Id).Include(c => c.Product).Include(c => c.Unit)
                .ProjectTo<PortionDTO>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<List<PortionDTO>> GetPortions()
        {
            return await context.Portions.Include(c => c.Product).Include(c => c.Unit)
                    .ProjectTo<PortionDTO>(mapper.ConfigurationProvider)
                    .ToListAsync();
        }

        public async Task<List<PortionDTO>> GetPortionsById(Guid Id)
        {
            return await context.Portions.Include(c => c.Product).Include(c => c.Unit)
                     .Where(c => c.ProductId == Id)
                     .ProjectTo<PortionDTO>(mapper.ConfigurationProvider)
                     .ToListAsync();
        }

        public async Task<PortionDTO> UpdatePortion(PortionDTO portion)
        {
            var dbPortion = await context.Portions.Where(i => i.Id == portion.Id).FirstOrDefaultAsync();

            if (dbPortion == null)
                throw new Exception("porsiyon bulunamadı");


            mapper.Map(portion, dbPortion);

            int result = await context.SaveChangesAsync();

            return mapper.Map<PortionDTO>(dbPortion);
        }
    }
}
