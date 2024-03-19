using IsbaSatisBlazor.Server.Services.Infrastruce;
using IsbaSatisBlazor.Server.Services.Services;
using IsbaSatisBlazor.Shared.DTO;
using IsbaSatisBlazor.Shared.Extensions;
using IsbaSatisBlazor.Shared.ResponseModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsbaSatisBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = RoleExtension.ProductNote)]
    public class ProductNoteController : ControllerBase
    {
        IProductNoteService productNoteService;
        public ProductNoteController(IProductNoteService ProductNoteService)
        {
            productNoteService = ProductNoteService;
        }
        [HttpGet("ProductNotes")]
        public async Task<ServiceResponse<List<ProductNoteDTO>>> GetProductNotes()
        {
            return new ServiceResponse<List<ProductNoteDTO>>()
            {
                Value = await productNoteService.GetProductNotes()
            };
        }
        [HttpGet("ProductNotesById/{Id}")]
        public async Task<ServiceResponse<List<ProductNoteDTO>>> GetProductNotesById(Guid Id)
        {
            return new ServiceResponse<List<ProductNoteDTO>>()
            {
                Value = await productNoteService.GetProductNotesById(Id)
            };
        }
        [HttpPost("Create")]
        public async Task<ServiceResponse<ProductNoteDTO>> CreateProductNote([FromBody] ProductNoteDTO productNote)
        {
            return new ServiceResponse<ProductNoteDTO>()
            {
                Value = await productNoteService.CreateProductNote(productNote)
            };
        }
        [HttpPost("Update")]
        public async Task<ServiceResponse<ProductNoteDTO>> UpdateProductNote([FromBody] ProductNoteDTO productNote)
        {
            return new ServiceResponse<ProductNoteDTO>()
            {
                Value = await productNoteService.UpdateProductNote(productNote)
            };
        }
        [HttpGet("ProductNoteById/{Id}")]
        public async Task<ServiceResponse<ProductNoteDTO>> GetProductNoteById(Guid Id)
        {
            return new ServiceResponse<ProductNoteDTO>()
            {
                Value = await productNoteService.GetUProductNoteById(Id)
            };
        }
        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeleteProductNote([FromBody] Guid id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await productNoteService.DeleteProductNoteById(id)
            };
        }
    }
}
