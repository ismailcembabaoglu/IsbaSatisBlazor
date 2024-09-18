using AutoMapper;
using AutoMapper.QueryableExtensions;
using IsbaSatisBlazor.Data.Context;
using IsbaSatisBlazor.Data.Models;
using IsbaSatisBlazor.Server.Services.Infrastruce;
using IsbaSatisBlazor.Shared.DTO;
using Microsoft.EntityFrameworkCore;

namespace IsbaSatisBlazor.Server.Services.Services
{
    public class DeskSevice : IDeskSevice
    {

        private readonly IMapper mapper;
        private readonly IsbaSatisDbContext context;
        private readonly IConfiguration configuration;

        public DeskSevice(IMapper Mapper, IsbaSatisDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;

        }
        public async Task<DeskDTO> CreateDesk(DeskDTO Desk)
        {
            var dbDesk = await context.Desks.Where(i => i.Id == Desk.Id).FirstOrDefaultAsync();

            if (dbDesk != null)
                throw new Exception("Masa Zaten Mevcut");


            dbDesk = mapper.Map<Data.Models.Desk>(Desk);
            dbDesk.CreateDate = DateTime.Now;
            await context.Desks.AddAsync(dbDesk);
            int result = await context.SaveChangesAsync();

            return mapper.Map<DeskDTO>(dbDesk);
        }

        public async Task<bool> DeleteDeskId(Guid Id)
        {
            var dbDesk = await context.Desks.Where(i => i.Id == Id).FirstOrDefaultAsync();

            if (dbDesk == null)
                throw new Exception("Masa Bulunamadı");
            context.Desks.Remove(dbDesk);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<DeskDTO> GetDeskById(Guid Id)
        {
            return await context.Desks
                .Where(i => i.Id == Id).Include(c => c.DeskLocation)
                .ProjectTo<DeskDTO>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<List<DeskDTO>> GetDesks()
        {
            return await context.Desks.Include(c => c.DeskLocation)
                    .ProjectTo<DeskDTO>(mapper.ConfigurationProvider)
                    .ToListAsync();
        }

        public async Task<List<DeskDTO>> GetDesksById(Guid DeskLocationId)
        {
            return await context.Desks.Include(c => c.DeskLocation)
                      .Where(c => c.DeskLocationId == DeskLocationId)
                      .ProjectTo<DeskDTO>(mapper.ConfigurationProvider)
                      .ToListAsync();
        }

        public async Task<DeskDTO> UpdateDesk(DeskDTO Desk)
        {
            var dbDesk = await context.Desks.Where(i => i.Id == Desk.Id).FirstOrDefaultAsync();

            if (dbDesk == null)
                throw new Exception("Masa bulunamadı");


            mapper.Map(Desk, dbDesk);

            int result = await context.SaveChangesAsync();

            return mapper.Map<DeskDTO>(dbDesk);
        }
    }
}
