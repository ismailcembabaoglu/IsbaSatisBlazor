using IsbaSatisBlazor.Shared.DTO;

namespace IsbaSatisBlazor.Server.Services.Infrastruce
{
    public interface IPortionService
    {
        public Task<PortionDTO> GetPortionById(Guid Id);

        public Task<List<PortionDTO>> GetPortions();

        public Task<PortionDTO> CreatePortion(PortionDTO portion);

        public Task<PortionDTO> UpdatePortion(PortionDTO portion);

        public Task<bool> DeletePortionId(Guid Id);
    }
}
