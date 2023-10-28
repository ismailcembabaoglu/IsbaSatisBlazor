using AutoMapper;
using AutoMapper.QueryableExtensions;
using IsbaSatisBlazor.Data.Context;
using IsbaSatisBlazor.Data.Models;
using IsbaSatisBlazor.Server.Services.Infrastruce;
using IsbaSatisBlazor.Shared.DTO;
using Microsoft.EntityFrameworkCore;

namespace IsbaSatisBlazor.Server.Services.Services
{
    public class ProductNoteService : IProductNoteService
    {
        private readonly IMapper mapper;
        private readonly IsbaSatisDbContext context;
        private readonly IConfiguration configuration;

        public ProductNoteService(IMapper Mapper, IsbaSatisDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;
        }
        public async Task<ProductNoteDTO> CreateProductNote(ProductNoteDTO ProductNote)
        {
            var dbProductNote = await context.ProductNotes.Where(i => i.Id == ProductNote.Id).FirstOrDefaultAsync();

            if (dbProductNote != null)
                throw new Exception("Ürün Notu Zaten Mevcut");


            dbProductNote = mapper.Map<Data.Models.ProductNote>(ProductNote);
            dbProductNote.CreateDate = DateTime.Now;
            await context.ProductNotes.AddAsync(dbProductNote);
            int result = await context.SaveChangesAsync();

            return mapper.Map<ProductNoteDTO>(dbProductNote);
        }

        public async Task<bool> DeleteProductNoteById(Guid Id)
        {
            var dbProductNote = await context.ProductNotes.Where(i => i.Id == Id).FirstOrDefaultAsync();

            if (dbProductNote == null)
                throw new Exception("Ürün Notu Bulunamadı");
            context.ProductNotes.Remove(dbProductNote);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<List<ProductNoteDTO>> GetProductNotes()
        {
            return await context.ProductNotes.Include(c=>c.Product)
                    .ProjectTo<ProductNoteDTO>(mapper.ConfigurationProvider)
                    .ToListAsync();
        }

        public async Task<List<ProductNoteDTO>> GetProductNotesById(Guid Id)
        {
            return await context.ProductNotes.Include(c => c.Product)
                       .Where(c => c.ProductId == Id)
                       .ProjectTo<ProductNoteDTO>(mapper.ConfigurationProvider)
                       .ToListAsync();
        }

        public async Task<ProductNoteDTO> GetUProductNoteById(Guid Id)
        {
            return await context.ProductNotes
              .Where(i => i.Id == Id).Include(c => c.Product)
              .ProjectTo<ProductNoteDTO>(mapper.ConfigurationProvider)
              .FirstOrDefaultAsync();
        }

        public async Task<ProductNoteDTO> UpdateProductNote(ProductNoteDTO ProductNote)
        {
            var dbProductNote = await context.ProductNotes.Where(i => i.Id == ProductNote.Id).FirstOrDefaultAsync();

            if (dbProductNote == null)
                throw new Exception("Ürün Notu bulunamadı");


            mapper.Map(ProductNote, dbProductNote);

            int result = await context.SaveChangesAsync();

            return mapper.Map<ProductNoteDTO>(dbProductNote);
        }
    }
}
