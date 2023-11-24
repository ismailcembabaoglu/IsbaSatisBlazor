using AutoMapper;
using AutoMapper.QueryableExtensions;
using IsbaSatisBlazor.Data.Context;
using IsbaSatisBlazor.Data.Models;
using IsbaSatisBlazor.Server.Services.Infrastruce;
using IsbaSatisBlazor.Shared.DTO;
using Microsoft.EntityFrameworkCore;

namespace IsbaSatisBlazor.Server.Services.Services
{
    public class LinktestService : ILinktestService
    {
        private readonly IMapper mapper;
        private readonly IsbaSatisDbContext context;
        private readonly IConfiguration configuration;
        public LinktestService(IMapper Mapper, IsbaSatisDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;
        }
        public async Task<LinkTestDTO> CreateLinkTest(LinkTestDTO LinkTest)
        {
            var dbLinkTest = await context.LinkTests.Where(i => i.Id == LinkTest.Id).FirstOrDefaultAsync();

            if (dbLinkTest != null)
                throw new Exception("Birim Zaten Mevcut");


            dbLinkTest = mapper.Map<Data.Models.LinkTest>(LinkTest);
            dbLinkTest.CreateDate = DateTime.Now;
            await context.LinkTests.AddAsync(dbLinkTest);
            int result = await context.SaveChangesAsync();

            return mapper.Map<LinkTestDTO>(dbLinkTest);
        }

        public async Task<bool> DeleteLinkTestId(Guid Id)
        {
            var dbLinkTest = await context.LinkTests.Where(i => i.Id == Id).FirstOrDefaultAsync();

            if (dbLinkTest == null)
                throw new Exception("Birim Bulunamadı");
            context.LinkTests.Remove(dbLinkTest);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<List<LinkTestDTO>> GetLinkTest()
        {
            return await context.LinkTests
                 .ProjectTo<LinkTestDTO>(mapper.ConfigurationProvider)
                 .ToListAsync();
        }

        public async Task<LinkTestDTO> GetLinkTestById(Guid Id)
        {
            return await context.LinkTests
               .Where(i => i.Id == Id)
               .ProjectTo<LinkTestDTO>(mapper.ConfigurationProvider)
               .FirstOrDefaultAsync(); ;
        }

        public async Task<LinkTestDTO> UpdateLinkTest(LinkTestDTO LinkTest)
        {
            var dbLinkTest = await context.LinkTests.Where(i => i.Id == LinkTest.Id).FirstOrDefaultAsync();

            if (dbLinkTest == null)
                throw new Exception("Birim bulunamadı");


            mapper.Map(LinkTest, dbLinkTest);

            int result = await context.SaveChangesAsync();

            return mapper.Map<LinkTestDTO>(dbLinkTest);
        }
    }
}
