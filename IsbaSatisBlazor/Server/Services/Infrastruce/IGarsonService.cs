using IsbaSatisBlazor.Shared.DTO;

namespace IsbaSatisBlazor.Server.Services.Infrastruce
{
    public interface IGarsonService
    {
        public Task<GarsonDTO> GetGarsonById(Guid Id);

        public Task<List<GarsonDTO>> GetGarsons();
        public Task<List<GarsonDTO>> GetGarsonsById(Guid Id);

        public Task<GarsonDTO> CreateGarson(GarsonDTO Garson);

        public Task<GarsonDTO> UpdateGarson(GarsonDTO Garson);

        public Task<bool> DeleteGarsonId(Guid Id);
    }
}
