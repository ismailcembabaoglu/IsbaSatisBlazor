using AutoMapper;
using AutoMapper.QueryableExtensions;
using IsbaSatisBlazor.Data.Context;
using IsbaSatisBlazor.Data.Models;
using IsbaSatisBlazor.Server.Services.Infrastruce;
using IsbaSatisBlazor.Shared.DTO;
using Microsoft.EntityFrameworkCore;

namespace IsbaSatisBlazor.Server.Services.Services
{
    public class ProductMotionService : IProductMotionService
    {
        private readonly IMapper mapper;
        private readonly IsbaSatisDbContext context;
        private readonly IConfiguration configuration;
        public ProductMotionService(IMapper Mapper, IsbaSatisDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;
        }

        public async Task<ProductMotionDTO> CreateProductMotion(ProductMotionDTO ProductMotion)
        {
            var dbProductMotion = await context.ProductMotions.Where(i => i.Id == ProductMotion.Id).FirstOrDefaultAsync();

            if (dbProductMotion != null)
                throw new Exception("Ürün Hareketi Zaten Mevcut");


            dbProductMotion = mapper.Map<Data.Models.ProductMotion>(ProductMotion);
            dbProductMotion.CreateDate = DateTime.Now;
            await context.ProductMotions.AddAsync(dbProductMotion);
            int result = await context.SaveChangesAsync();

            return mapper.Map<ProductMotionDTO>(dbProductMotion);
        }

        public async Task<bool> DeleteProductMotionId(Guid Id)
        {
            var dbProductMotion = await context.ProductMotions.Where(i => i.Id == Id).FirstOrDefaultAsync();

            if (dbProductMotion == null)
                throw new Exception("Ürün Hareketi Bulunamadı");
            context.ProductMotions.Remove(dbProductMotion);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<ProductMotionDTO> GetProductMotionById(Guid Id)
        {
            return await context.ProductMotions
               .Where(i => i.Id == Id).Include(c => c.Product).Include(c => c.Portion).ThenInclude(c=>c.Unit).Include(c => c.Adisyon)
               .ProjectTo<ProductMotionDTO>(mapper.ConfigurationProvider)
               .FirstOrDefaultAsync();
        }

        public async Task<List<ProductMotionDTO>> GetProductMotions()
        {
            return await context.ProductMotions.Include(c => c.Product).Include(c => c.Portion).ThenInclude(c => c.Unit).Include(c => c.Adisyon)
                    .ProjectTo<ProductMotionDTO>(mapper.ConfigurationProvider)
                    .ToListAsync();
        }

        public async Task<List<ProductMotionDTO>> GetProductMotionsById(Guid Id)
        {
            return await context.ProductMotions.Include(c => c.Product).Include(c => c.Portion).ThenInclude(c => c.Unit).Include(c => c.Adisyon)
                    .Where(c => c.ProductId == Id)
                    .ProjectTo<ProductMotionDTO>(mapper.ConfigurationProvider)
                    .ToListAsync();
        }

        public async Task<ProductMotionDTO> UpdateProductMotion(ProductMotionDTO ProductMotion)
        {
            var dbProductMotion = await context.ProductMotions.Where(i => i.Id == ProductMotion.Id).FirstOrDefaultAsync();

            if (dbProductMotion == null)
                throw new Exception("Ürün Hareketi bulunamadı");


            mapper.Map(ProductMotion, dbProductMotion);

            int result = await context.SaveChangesAsync();

            return mapper.Map<ProductMotionDTO>(dbProductMotion);
        }
    }
}
