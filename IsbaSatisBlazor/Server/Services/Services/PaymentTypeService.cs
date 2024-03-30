using AutoMapper;
using AutoMapper.QueryableExtensions;
using IsbaSatisBlazor.Data.Context;
using IsbaSatisBlazor.Data.Models;
using IsbaSatisBlazor.Server.Services.Infrastruce;
using IsbaSatisBlazor.Shared.DTO;
using Microsoft.EntityFrameworkCore;

namespace IsbaSatisBlazor.Server.Services.Services
{
    public class PaymentTypeService : IPaymentTypeService
    {

        private readonly IMapper mapper;
        private readonly IsbaSatisDbContext context;
        private readonly IConfiguration configuration;


        public PaymentTypeService(IMapper Mapper, IsbaSatisDbContext Context, IConfiguration Configuration)
        {
            mapper = Mapper;
            context = Context;
            configuration = Configuration;
        }

        public async Task<PaymentTypeDTO> CreatePaymentType(PaymentTypeDTO PaymentType)
        {
            var dbPaymentType = await context.PaymentTypes.Where(i => i.Id == PaymentType.Id).FirstOrDefaultAsync();

            if (dbPaymentType != null)
                throw new Exception("Ödeme Türü Zaten Mevcut");


            dbPaymentType = mapper.Map<Data.Models.PaymentType>(PaymentType);
            dbPaymentType.CreateDate = DateTime.Now;
            await context.PaymentTypes.AddAsync(dbPaymentType);
            int result = await context.SaveChangesAsync();

            return mapper.Map<PaymentTypeDTO>(dbPaymentType);
        }

        public async Task<bool> DeletePaymentTypeId(Guid Id)
        {
            var dbPaymentType = await context.PaymentTypes.Where(i => i.Id == Id).FirstOrDefaultAsync();

            if (dbPaymentType == null)
                throw new Exception("Ödeme Türü Bulunamadı");
            context.PaymentTypes.Remove(dbPaymentType);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<PaymentTypeDTO> GetPaymentTypeById(Guid Id)
        {
            return await context.PaymentTypes
                .Where(i => i.Id == Id)
                .ProjectTo<PaymentTypeDTO>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<List<PaymentTypeDTO>> GetPaymentTypes()
        {
            return await context.PaymentTypes
                    .ProjectTo<PaymentTypeDTO>(mapper.ConfigurationProvider)
                    .ToListAsync();
        }

        public async Task<List<PaymentTypeDTO>> GetPaymentTypesById(Guid Id)
        {
            return await context.PaymentTypes
                      .ProjectTo<PaymentTypeDTO>(mapper.ConfigurationProvider)
                      .ToListAsync();
        }

        public async Task<PaymentTypeDTO> UpdatePaymentType(PaymentTypeDTO PaymentType)
        {
            var dbPaymentType = await context.PaymentTypes.Where(i => i.Id == PaymentType.Id).FirstOrDefaultAsync();

            if (dbPaymentType == null)
                throw new Exception("Ödeme Türü bulunamadı");


            mapper.Map(PaymentType, dbPaymentType);

            int result = await context.SaveChangesAsync();

            return mapper.Map<PaymentTypeDTO>(dbPaymentType);
        }
    }
}
