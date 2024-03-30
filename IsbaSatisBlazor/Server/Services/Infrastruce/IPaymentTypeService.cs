using IsbaSatisBlazor.Shared.DTO;

namespace IsbaSatisBlazor.Server.Services.Infrastruce
{
    public interface IPaymentTypeService
    {
        public Task<PaymentTypeDTO> GetPaymentTypeById(Guid Id);

        public Task<List<PaymentTypeDTO>> GetPaymentTypes();
        public Task<List<PaymentTypeDTO>> GetPaymentTypesById(Guid Id);

        public Task<PaymentTypeDTO> CreatePaymentType(PaymentTypeDTO PaymentType);

        public Task<PaymentTypeDTO> UpdatePaymentType(PaymentTypeDTO PaymentType);

        public Task<bool> DeletePaymentTypeId(Guid Id);
    }
}
