using IsbaSatisBlazor.Shared.DTO;

namespace IsbaSatisBlazor.Server.Services.Infrastruce
{
    public interface IDeskSevice
    {
        public Task<DeskDTO> GetDeskById(Guid Id);

        public Task<List<DeskDTO>> GetDesks();
        public Task<List<DeskDTO>> GetDesksById(Guid Id);

        public Task<DeskDTO> CreateDesk(DeskDTO Desk);

        public Task<DeskDTO> UpdateDesk(DeskDTO Desk);

        public Task<bool> DeleteDeskId(Guid Id);
    }
}
