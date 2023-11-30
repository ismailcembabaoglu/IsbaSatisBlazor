using IsbaSatisBlazor.Shared.DTO;

namespace IsbaSatisBlazor.Server.Services.Infrastruce
{
    public interface IAdressService
    {
        public Task<AdressDTO> GetAdressById(Guid Id);

        public Task<List<AdressDTO>> GetAdresss();
        public Task<List<AdressDTO>> GetAdresssById(Guid Id);

        public Task<AdressDTO> CreateAdress(AdressDTO Adress);

        public Task<AdressDTO> UpdateAdress(AdressDTO Adress);

        public Task<bool> DeleteAdressId(Guid Id);
    }
}
