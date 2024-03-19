using IsbaSatisBlazor.Shared.DTO;

namespace IsbaSatisBlazor.Server.Services.Infrastruce
{
    public interface ILinktestService
    {
        public Task<LinkTestDTO> GetLinkTestById(Guid Id);

        public Task<List<LinkTestDTO>> GetLinkTest();

        public Task<LinkTestDTO> CreateLinkTest(LinkTestDTO LinkTest);

        public Task<LinkTestDTO> UpdateLinkTest(LinkTestDTO LinkTest);

        public Task<bool> DeleteLinkTestId(Guid Id);
    }
}
