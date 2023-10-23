using AutoMapper;
using AutoMapper.QueryableExtensions;
using IsbaSatisBlazor.Data.Context;
using IsbaSatisBlazor.Data.Models;
using IsbaSatisBlazor.Server.Services.Infrastruce;
using IsbaSatisBlazor.Shared.DTO;
using Microsoft.EntityFrameworkCore;

namespace IsbaSatisBlazor.Server.Services.Services
{
    public class ProductGroupService : IProductGroupService
    {
        private readonly IMapper mapper;
        private readonly IsbaSatisDbContext context;
        private readonly IConfiguration configuration;
        public ProductGroupService(IMapper Mapper, IsbaSatisDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;
        }
        public async Task<ProductGroupDTO> CreateProductGroup(ProductGroupDTO ProductGroup)
        {
            var dbProductGroup = await context.ProductGroups.Where(i => i.Id == ProductGroup.Id).FirstOrDefaultAsync();

            if (dbProductGroup != null)
                throw new Exception("Grup Zaten Mevcut");


            dbProductGroup = mapper.Map<Data.Models.ProductGroup>(ProductGroup);
            dbProductGroup.CreateDate = DateTime.Now;
            await context.ProductGroups.AddAsync(dbProductGroup);
            int result = await context.SaveChangesAsync();

            return mapper.Map<ProductGroupDTO>(dbProductGroup);
        }

        public async Task<bool> DeleteProductGroupById(Guid Id)
        {
            var dbProductGroup = await context.ProductGroups.Where(i => i.Id == Id).FirstOrDefaultAsync();

            if (dbProductGroup == null)
                throw new Exception("Grup Bulunamadı");
            context.ProductGroups.Remove(dbProductGroup);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<List<ProductGroupDTO>> GetProductGroups()
        {
            return await context.ProductGroups
                    .ProjectTo<ProductGroupDTO>(mapper.ConfigurationProvider)
                    .ToListAsync();
        }

        public async Task<ProductGroupDTO> GetUProductGroupById(Guid Id)
        {
            return await context.ProductGroups
                      .Where(i => i.Id == Id)
                      .ProjectTo<ProductGroupDTO>(mapper.ConfigurationProvider)
                      .FirstOrDefaultAsync();
        }

        public async Task<ProductGroupDTO> UpdateProductGroup(ProductGroupDTO ProductGroup)
        {
            var dbProductGroup = await context.ProductGroups.Where(i => i.Id == ProductGroup.Id).FirstOrDefaultAsync();

            if (dbProductGroup == null)
                throw new Exception("Grup bulunamadı");


            mapper.Map(ProductGroup, dbProductGroup);

            int result = await context.SaveChangesAsync();

            return mapper.Map<ProductGroupDTO>(dbProductGroup);
        }
    }
}
