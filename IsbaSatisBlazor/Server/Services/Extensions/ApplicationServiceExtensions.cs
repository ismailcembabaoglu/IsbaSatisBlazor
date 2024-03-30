using FluentValidation;
using IsbaSatisBlazor.Server.Services.Infrastruce;
using IsbaSatisBlazor.Server.Services.Services;
using IsbaSatisBlazor.Shared.DTO;

namespace IsbaSatisBlazor.Server.Services.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection service)
        {
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IProductGroupService, ProductGroupService>();
            service.AddScoped<IProductService, ProductService>();
            service.AddScoped<IUnitService, UnitService>();
            service.AddScoped<IPortionService, PortionService>();
            service.AddScoped<ISupplementaryMaterialService, SupplementaryMaterialService>();
            service.AddScoped<IProductNoteService, ProductNoteService>();
            service.AddScoped<ILinktestService, LinktestService>();
            service.AddScoped<IAdisyonSevice, AdisyonSevice>();
            service.AddScoped<IAdressService, AdressService>();
            service.AddScoped<ICustomerService, CustomerService>();
            service.AddScoped<IDeskLocationService, DeskLocationService>();
            service.AddScoped<IDeskSevice, DeskSevice>();
            service.AddScoped<IGarsonService, GarsonService>();
            service.AddScoped<IPaymentMotionService, PaymentMotionService>();
            service.AddScoped<IPhoneService, PhoneService>();
            service.AddScoped<IProductMotionService, ProductMotionService>();
            service.AddScoped<ISupplementaryMaterialMotionService, SupplementaryMaterialMotionService>();
            
           
            return service;
        }
    }
}
