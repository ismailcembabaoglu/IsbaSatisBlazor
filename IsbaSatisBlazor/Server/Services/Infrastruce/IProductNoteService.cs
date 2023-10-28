using IsbaSatisBlazor.Shared.DTO;

namespace IsbaSatisBlazor.Server.Services.Infrastruce
{
    public interface IProductNoteService
    {
        public Task<ProductNoteDTO> GetUProductNoteById(Guid Id);

        public Task<List<ProductNoteDTO>> GetProductNotes();
        public Task<List<ProductNoteDTO>> GetProductNotesById(Guid Id);
        public Task<ProductNoteDTO> CreateProductNote(ProductNoteDTO ProductNote);

        public Task<ProductNoteDTO> UpdateProductNote(ProductNoteDTO ProductNote);

        public Task<bool> DeleteProductNoteById(Guid Id);
    }
}
