using IsbaSatisBlazor.Shared.DTO;

namespace IsbaSatisBlazor.Server.Services.Infrastruce
{
    public interface IUnitService
    {
        public Task<UnitDTO> GetUnitById(Guid Id);

        public Task<List<UnitDTO>> GetUnits();

        public Task<UnitDTO> CreateUnit(UnitDTO Unit);

        public Task<UnitDTO> UpdateUnit(UnitDTO Unit);

        public Task<bool> DeleteUnitId(Guid Id);
    }
}
