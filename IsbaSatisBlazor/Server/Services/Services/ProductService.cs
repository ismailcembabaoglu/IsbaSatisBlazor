using AutoMapper;
using AutoMapper.QueryableExtensions;
using IsbaSatisBlazor.Data.Context;
using IsbaSatisBlazor.Data.Models;
using IsbaSatisBlazor.Server.Services.Infrastruce;
using IsbaSatisBlazor.Shared.DTO;
using Microsoft.EntityFrameworkCore;

namespace IsbaSatisBlazor.Server.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper mapper;
        private readonly IsbaSatisDbContext context;
        private readonly IConfiguration configuration;
        public ProductService(IMapper Mapper, IsbaSatisDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;
        }
        public async Task<ProductDTO> CreateProduct(ProductDTO Product)
        {
            var dbProduct = await context.Products.Where(i => i.Id == Product.Id).FirstOrDefaultAsync();

            if (dbProduct != null)
                throw new Exception("Ürün Zaten Mevcut");


            dbProduct = mapper.Map<Data.Models.Product>(Product);
            dbProduct.CreateDate = DateTime.Now;
            await context.Products.AddAsync(dbProduct);
            int result = await context.SaveChangesAsync();

            return mapper.Map<ProductDTO>(dbProduct);
        }

        public async Task<bool> DeleteProductById(Guid Id)
        {
            var dbProduct = await context.Products.Where(i => i.Id == Id).FirstOrDefaultAsync();

            if (dbProduct == null)
                throw new Exception("Ürün Bulunamadı");
            context.Products.Remove(dbProduct);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<List<ProductDTO>> GetProducts()
        {
            return await context.Products.Include(c=>c.ProductGroup)
                   .ProjectTo<ProductDTO>(mapper.ConfigurationProvider)
                   .ToListAsync();
        }

        public async Task<ProductDTO> GetUProductById(Guid Id)
        {
            return await context.Products
                  .Where(i => i.Id == Id).Include(c=>c.ProductGroup)
                  .ProjectTo<ProductDTO>(mapper.ConfigurationProvider)
                  .FirstOrDefaultAsync();
        }

        public async Task<ProductDTO> UpdateProduct(ProductDTO Product)
        {
            var dbProduct = await context.Products.Where(i => i.Id == Product.Id).FirstOrDefaultAsync();

            if (dbProduct == null)
                throw new Exception("Ürün bulunamadı");


            mapper.Map(Product, dbProduct);

            int result = await context.SaveChangesAsync();

            return mapper.Map<ProductDTO>(dbProduct);
        }
    }
}
