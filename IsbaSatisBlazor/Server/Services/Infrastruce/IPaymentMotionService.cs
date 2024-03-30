using IsbaSatisBlazor.Shared.DTO;

namespace IsbaSatisBlazor.Server.Services.Infrastruce
{
    public interface IPaymentMotionService
    {
        public Task<PaymentMotionDTO> GetPaymentMotionById(Guid Id);

        public Task<List<PaymentMotionDTO>> GetPaymentMotions();
        public Task<List<PaymentMotionDTO>> GetPaymentMotionsById(Guid Id);

        public Task<PaymentMotionDTO> CreatePaymentMotion(PaymentMotionDTO PaymentMotion);

        public Task<PaymentMotionDTO> UpdatePaymentMotion(PaymentMotionDTO PaymentMotion);

        public Task<bool> DeletePaymentMotionId(Guid Id);
    }
}
