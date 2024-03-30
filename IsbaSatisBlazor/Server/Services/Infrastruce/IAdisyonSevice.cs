using IsbaSatisBlazor.Shared.DTO;

namespace IsbaSatisBlazor.Server.Services.Infrastruce
{
    public interface IAdisyonSevice
    {
        public Task<AdisyonDTO> GetAdisyonById(Guid Id);

        public Task<List<AdisyonDTO>> GetAdisyons();
        public Task<List<AdisyonDTO>> GetAdisyonsById(Guid Id);

        public Task<AdisyonDTO> CreateAdisyon(AdisyonDTO Adisyon);

        public Task<AdisyonDTO> UpdateAdisyon(AdisyonDTO Adisyon);

        public Task<bool> DeleteAdisyonId(Guid Id);
    }
}
