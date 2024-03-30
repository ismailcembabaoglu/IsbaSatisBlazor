using IsbaSatisBlazor.Shared.DTO;

namespace IsbaSatisBlazor.Server.Services.Infrastruce
{
    public interface IDeskLocationService
    {

        public Task<DeskLocationDTO> GetDeskLocationById(Guid Id);

        public Task<List<DeskLocationDTO>> GetDeskLocations();
        public Task<List<DeskLocationDTO>> GetDeskLocationsById(Guid Id);

        public Task<DeskLocationDTO> CreateDeskLocation(DeskLocationDTO DeskLocation);

        public Task<DeskLocationDTO> UpdateDeskLocation(DeskLocationDTO DeskLocation);

        public Task<bool> DeleteDeskLocationId(Guid Id);

    }
}
