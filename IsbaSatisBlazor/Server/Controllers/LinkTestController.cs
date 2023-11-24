using IsbaSatisBlazor.Server.Services.Infrastruce;
using IsbaSatisBlazor.Shared.DTO;
using IsbaSatisBlazor.Shared.ResponseModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IsbaSatisBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LinkTestController : ControllerBase
    {
        private readonly ILinktestService linkTestService;
        public LinkTestController(ILinktestService LinkTestService)
        {
            linkTestService = LinkTestService;
        }
        [HttpGet("LinkTests")]
        public async Task<ServiceResponse<List<LinkTestDTO>>> GetLinkTests()
        {
            return new ServiceResponse<List<LinkTestDTO>>()
            {
                Value = await linkTestService.GetLinkTest()
            };
        }
        [HttpPost("Create")]
        public async Task<ServiceResponse<LinkTestDTO>> CreateLinkTest([FromBody] LinkTestDTO linkTestDTO)
        {
            return new ServiceResponse<LinkTestDTO>()
            {
                Value = await linkTestService.CreateLinkTest(linkTestDTO)
            };
        }
        [HttpPost("Update")]
        public async Task<ServiceResponse<LinkTestDTO>> UpdateLinkTest([FromBody] LinkTestDTO linkTestDTO)
        {
            return new ServiceResponse<LinkTestDTO>()
            {
                Value = await linkTestService.UpdateLinkTest(linkTestDTO)
            };
        }
        [HttpGet("LinkTestById/{Id}")]
        public async Task<ServiceResponse<LinkTestDTO>> GetLinkTestById(Guid Id)
        {
            return new ServiceResponse<LinkTestDTO>()
            {
                Value = await linkTestService.GetLinkTestById(Id)
            };
        }
        [HttpPost("Delete")]
        public async Task<ServiceResponse<bool>> DeleteLinkTest([FromBody] Guid id)
        {
            return new ServiceResponse<bool>()
            {
                Value = await linkTestService.DeleteLinkTestId(id)
            };
        }
    }
}
