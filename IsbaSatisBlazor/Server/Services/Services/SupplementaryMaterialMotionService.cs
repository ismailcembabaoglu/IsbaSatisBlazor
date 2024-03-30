using AutoMapper;
using AutoMapper.QueryableExtensions;
using IsbaSatisBlazor.Data.Context;
using IsbaSatisBlazor.Data.Models;
using IsbaSatisBlazor.Server.Services.Infrastruce;
using IsbaSatisBlazor.Shared.DTO;
using Microsoft.EntityFrameworkCore;

namespace IsbaSatisBlazor.Server.Services.Services
{
    public class SupplementaryMaterialMotionService : ISupplementaryMaterialMotionService
    {
        private readonly IMapper mapper;
        private readonly IsbaSatisDbContext context;
        private readonly IConfiguration configuration;

        public SupplementaryMaterialMotionService(IMapper Mapper, IsbaSatisDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;
        }

        public async Task<SupplementaryMaterialMotionDTO> CreateSupplementaryMaterialMotion(SupplementaryMaterialMotionDTO SupplementaryMaterialMotion)
        {
            var dbSupplementaryMaterialMotion = await context.SupplementaryMaterialMotions.Where(i => i.Id == SupplementaryMaterialMotion.Id).FirstOrDefaultAsync();

            if (dbSupplementaryMaterialMotion != null)
                throw new Exception("Tamamlayıcı Materyal Hareketi Zaten Mevcut");


            dbSupplementaryMaterialMotion = mapper.Map<Data.Models.SupplementaryMaterialMotion>(SupplementaryMaterialMotion);
            dbSupplementaryMaterialMotion.CreateDate = DateTime.Now;
            await context.SupplementaryMaterialMotions.AddAsync(dbSupplementaryMaterialMotion);
            int result = await context.SaveChangesAsync();

            return mapper.Map<SupplementaryMaterialMotionDTO>(dbSupplementaryMaterialMotion);
        }

        public async Task<bool> DeleteSupplementaryMaterialMotionId(Guid Id)
        {
            var dbSupplementaryMaterialMotion = await context.SupplementaryMaterialMotions.Where(i => i.Id == Id).FirstOrDefaultAsync();

            if (dbSupplementaryMaterialMotion == null)
                throw new Exception("Tamamlayıcı Materyal Hareketi Bulunamadı");
            context.SupplementaryMaterialMotions.Remove(dbSupplementaryMaterialMotion);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<SupplementaryMaterialMotionDTO> GetSupplementaryMaterialMotionById(Guid Id)
        {
            return await context.SupplementaryMaterialMotions
           .Where(i => i.Id == Id).Include(c => c.SupplementaryMaterial).Include(c => c.ProductMotion)
                .ProjectTo<SupplementaryMaterialMotionDTO>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<List<SupplementaryMaterialMotionDTO>> GetSupplementaryMaterialMotions()
        {
            return await context.SupplementaryMaterialMotions.Include(c => c.SupplementaryMaterial).Include(c => c.ProductMotion)
                    .ProjectTo<SupplementaryMaterialMotionDTO>(mapper.ConfigurationProvider)
                    .ToListAsync();
        }

        public async Task<List<SupplementaryMaterialMotionDTO>> GetSupplementaryMaterialMotionsById(Guid Id)
        {
            return await context.SupplementaryMaterialMotions.Include(c => c.SupplementaryMaterial).Include(c => c.ProductMotion)
                     .Where(c => c.SupplementaryMaterialId == Id)
                     .ProjectTo<SupplementaryMaterialMotionDTO>(mapper.ConfigurationProvider)
                     .ToListAsync();
        }

        public async Task<SupplementaryMaterialMotionDTO> UpdateSupplementaryMaterialMotion(SupplementaryMaterialMotionDTO SupplementaryMaterialMotion)
        {
            var dbSupplementaryMaterialMotion = await context.SupplementaryMaterialMotions.Where(i => i.Id == SupplementaryMaterialMotion.Id).FirstOrDefaultAsync();

            if (dbSupplementaryMaterialMotion == null)
                throw new Exception("Tamamlayıcı Materyal Hareketi bulunamadı");


            mapper.Map(SupplementaryMaterialMotion, dbSupplementaryMaterialMotion);

            int result = await context.SaveChangesAsync();

            return mapper.Map<SupplementaryMaterialMotionDTO>(dbSupplementaryMaterialMotion);
        }
    }
}
