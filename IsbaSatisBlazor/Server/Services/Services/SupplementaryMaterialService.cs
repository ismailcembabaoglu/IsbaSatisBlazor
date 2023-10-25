using AutoMapper;
using AutoMapper.QueryableExtensions;
using IsbaSatisBlazor.Data.Context;
using IsbaSatisBlazor.Data.Models;
using IsbaSatisBlazor.Server.Services.Infrastruce;
using IsbaSatisBlazor.Shared.DTO;
using Microsoft.EntityFrameworkCore;

namespace IsbaSatisBlazor.Server.Services.Services
{
    public class SupplementaryMaterialService : ISupplementaryMaterialService
    {
        private readonly IMapper mapper;
        private readonly IsbaSatisDbContext context;
        private readonly IConfiguration configuration;
        public SupplementaryMaterialService(IMapper Mapper, IsbaSatisDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;
        }
        public async Task<SupplementaryMaterialDTO> CreateSupplementaryMaterial(SupplementaryMaterialDTO supplementary)
        {
            var dbSupplementaryMaterials = await context.SupplementaryMaterials.Where(i => i.Id == supplementary.Id).FirstOrDefaultAsync();

            if (dbSupplementaryMaterials != null)
                throw new Exception("Ek Malzeme Zaten Mevcut");


            dbSupplementaryMaterials = mapper.Map<Data.Models.SupplementaryMaterial>(supplementary);
            dbSupplementaryMaterials.CreateDate = DateTime.Now;
            await context.SupplementaryMaterials.AddAsync(dbSupplementaryMaterials);
            int result = await context.SaveChangesAsync();

            return mapper.Map<SupplementaryMaterialDTO>(dbSupplementaryMaterials);
        }

        public async Task<bool> DeleteSupplementaryMaterialId(Guid Id)
        {
            var dbSupplementaryMaterials = await context.SupplementaryMaterials.Where(i => i.Id == Id).FirstOrDefaultAsync();

            if (dbSupplementaryMaterials == null)
                throw new Exception("Ürün Bulunamadı");
            context.SupplementaryMaterials.Remove(dbSupplementaryMaterials);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<SupplementaryMaterialDTO> GetSupplementaryMaterialById(Guid Id)
        {
            return await context.SupplementaryMaterials
                .Where(i => i.Id == Id).Include(c => c.Product)
                .ProjectTo<SupplementaryMaterialDTO>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<List<SupplementaryMaterialDTO>> GetSupplementaryMaterials()
        {
            return await context.SupplementaryMaterials.Include(c => c.Product)
                   .ProjectTo<SupplementaryMaterialDTO>(mapper.ConfigurationProvider)
                   .ToListAsync();
        }

        public async Task<List<SupplementaryMaterialDTO>> GetSupplementaryMaterialsById(Guid Id)
        {
            return await context.SupplementaryMaterials.Include(c => c.Product)
                   .Where(c => c.ProductId == Id)
                   .ProjectTo<SupplementaryMaterialDTO>(mapper.ConfigurationProvider)
                   .ToListAsync();
        }

        public async Task<SupplementaryMaterialDTO> UpdateSupplementaryMaterial(SupplementaryMaterialDTO supplementary)
        {
            var dbSupplementaryMaterial = await context.SupplementaryMaterials.Where(i => i.Id == supplementary.Id).FirstOrDefaultAsync();

            if (dbSupplementaryMaterial == null)
                throw new Exception("Ek Malzeme bulunamadı");


            mapper.Map(supplementary, dbSupplementaryMaterial);

            int result = await context.SaveChangesAsync();

            return mapper.Map<SupplementaryMaterialDTO>(dbSupplementaryMaterial);
        }
    }
}
