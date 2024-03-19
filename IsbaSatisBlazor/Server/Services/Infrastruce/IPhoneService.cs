using IsbaSatisBlazor.Shared.DTO;

namespace IsbaSatisBlazor.Server.Services.Infrastruce
{
    public interface IPhoneService
    {
        public Task<PhoneDTO> GetPhoneById(Guid Id);

        public Task<List<PhoneDTO>> GetPhones();
        public Task<List<PhoneDTO>> GetPhonesById(Guid Id);

        public Task<PhoneDTO> CreatePhone(PhoneDTO Phone);

        public Task<PhoneDTO> UpdatePhone(PhoneDTO Phone);

        public Task<bool> DeletePhoneId(Guid Id);
    }
}
