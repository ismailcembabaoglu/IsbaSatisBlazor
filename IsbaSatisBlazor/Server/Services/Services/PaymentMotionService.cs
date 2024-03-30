using AutoMapper;
using AutoMapper.QueryableExtensions;
using IsbaSatisBlazor.Data.Context;
using IsbaSatisBlazor.Data.Models;
using IsbaSatisBlazor.Server.Services.Infrastruce;
using IsbaSatisBlazor.Shared.DTO;
using Microsoft.EntityFrameworkCore;

namespace IsbaSatisBlazor.Server.Services.Services
{
    public class PaymentMotionService : IPaymentMotionService
    {


        private readonly IMapper mapper;
        private readonly IsbaSatisDbContext context;
        private readonly IConfiguration configuration;

        public PaymentMotionService(IMapper Mapper, IsbaSatisDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;
        }
        public async Task<PaymentMotionDTO> CreatePaymentMotion(PaymentMotionDTO PaymentMotion)
        {
            var dbPaymentMotion = await context.PaymentMotions.Where(i => i.Id == PaymentMotion.Id).FirstOrDefaultAsync();

            if (dbPaymentMotion != null)
                throw new Exception("Ödeme Hareketi Zaten Mevcut");


            dbPaymentMotion = mapper.Map<Data.Models.PaymentMotion>(PaymentMotion);
            dbPaymentMotion.CreateDate = DateTime.Now;
            await context.PaymentMotions.AddAsync(dbPaymentMotion);
            int result = await context.SaveChangesAsync();

            return mapper.Map<PaymentMotionDTO>(dbPaymentMotion);
        }

        public async Task<bool> DeletePaymentMotionId(Guid Id)
        {
            var dbPaymentMotion = await context.PaymentMotions.Where(i => i.Id == Id).FirstOrDefaultAsync();

            if (dbPaymentMotion == null)
                throw new Exception("Ödeme Hareketi Bulunamadı");
            context.PaymentMotions.Remove(dbPaymentMotion);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<PaymentMotionDTO> GetPaymentMotionById(Guid Id)
        {
            return await context.PaymentMotions
                .Where(i => i.Id == Id).Include(c => c.PaymentType).Include(c => c.Adisyon)
                .ProjectTo<PaymentMotionDTO>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<List<PaymentMotionDTO>> GetPaymentMotions()
        {
            return await context.PaymentMotions.Include(c => c.PaymentType).Include(c => c.Adisyon)
                     .ProjectTo<PaymentMotionDTO>(mapper.ConfigurationProvider)
                     .ToListAsync();
        }

        public async Task<List<PaymentMotionDTO>> GetPaymentMotionsById(Guid Id)
        {
            return await context.PaymentMotions.Include(c => c.PaymentType).Include(c => c.Adisyon)
                     .Where(c => c.PaymentTypeId == Id)
                     .ProjectTo<PaymentMotionDTO>(mapper.ConfigurationProvider)
                     .ToListAsync(); ;
        }

        public async Task<PaymentMotionDTO> UpdatePaymentMotion(PaymentMotionDTO PaymentMotion)
        {
            var dbPaymentMotion = await
                context.PaymentMotions.Where(i => i.Id == PaymentMotion.Id).FirstOrDefaultAsync();

            if (dbPaymentMotion == null)
                throw new Exception("Ödeme Hareketi bulunamadı");


            mapper.Map(PaymentMotion, dbPaymentMotion);

            int result = await context.SaveChangesAsync();

            return mapper.Map<PaymentMotionDTO>(dbPaymentMotion);
        }
    }
}
