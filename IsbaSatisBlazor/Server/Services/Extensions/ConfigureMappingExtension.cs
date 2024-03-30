using AutoMapper;
using IsbaSatisBlazor.Data.Models;
using IsbaSatisBlazor.Shared.DTO;
using IsbaSatisBlazor.Shared.Utils;

namespace IsbaSatisBlazor.Server.Services.Extensions
{
    public static class ConfigureMappingExtension
    {
        public static IServiceCollection ConfigureMapping(this IServiceCollection service)
        {
            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });

            IMapper mapper = mappingConfig.CreateMapper();

            service.AddSingleton(mapper);

            return service;
        }
    }
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            AllowNullDestinationValues = true;
            AllowNullCollections = true;

            CreateMap<Users, UserDTO>();
            CreateMap<UserDTO, Users>()
                .ForMember(x => x.Password, y => y.MapFrom(z => PasswordEncrypter.Encrypt(z.Password)));

            CreateMap<ProductGroup, ProductGroupDTO>();
            CreateMap<ProductGroupDTO, ProductGroup>();

            CreateMap<Product, ProductDTO>()
                .ForMember(c => c.GroupName, y => y.MapFrom(z => z.ProductGroup.GroupName));
            CreateMap<ProductDTO, Product>();

            CreateMap<Portion, PortionDTO>()
                .ForMember(c => c.ProductName, y => y.MapFrom(z => z.Product.ProductName))
                .ForMember(c => c.UnitGroupName, y => y.MapFrom(z => z.Unit.GroupName));
            CreateMap<PortionDTO, Portion>();

            CreateMap<SupplementaryMaterial, SupplementaryMaterialDTO>()
                .ForMember(c => c.ProductName, y => y.MapFrom(z => z.Product.ProductName));
            CreateMap<SupplementaryMaterialDTO, SupplementaryMaterial>();

            CreateMap<Adisyon, AdisyonDTO>()
               .ForMember(c => c.CustomerName, y => y.MapFrom(z => z.Customer.CustomerName))
               .ForMember(c => c.GarsonName, y => y.MapFrom(z => z.Garson.Name))
               .ForMember(c => c.DeskName, y => y.MapFrom(z => z.Desk.Name));
            CreateMap<AdisyonDTO, Adisyon>();

            CreateMap<Address, AdressDTO>()
                .ForMember(c => c.CustomerName, y => y.MapFrom(z => z.Customer.CustomerName))
                .ForMember(c => c.CustomerSurname, y => y.MapFrom(z => z.Customer.CustomerSurname));
            CreateMap<AdressDTO, Address>();

            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>();

            CreateMap<Desk, DeskDTO>()
            .ForMember(c => c.DeskLocationName, y => y.MapFrom(z => z.DeskLocation.LocationName));
            CreateMap<DeskDTO, Desk>();

            CreateMap<Garson, GarsonDTO>();
            CreateMap<GarsonDTO, Garson>();

            CreateMap<PaymentMotion, PaymentMotionDTO>()
            .ForMember(c => c.PaymentName, y => y.MapFrom(z => z.PaymentType.PaymentName));
            CreateMap<PaymentMotionDTO, PaymentMotion>();

            CreateMap<PaymentType, PaymentTypeDTO>();
            CreateMap<PaymentTypeDTO, PaymentType>();

            CreateMap<Phone, PhoneDTO>()
            .ForMember(c => c.CustomerName, y => y.MapFrom(z => z.Customer.CustomerName))
            .ForMember(c => c.CustomerSurname, y => y.MapFrom(z => z.Customer.CustomerSurname));
            CreateMap<PhoneDTO, Phone>();

            CreateMap<SupplementaryMaterialMotion, SupplementaryMaterialMotionDTO>()
             .ForMember(c => c.SupplementaryMaterialName, y => y.MapFrom(z => z.SupplementaryMaterial.SupplementaryMaterialName));
            CreateMap<SupplementaryMaterialMotionDTO, SupplementaryMaterialMotion>();

            CreateMap<Unit, UnitDTO>();
            CreateMap<UnitDTO, Unit>();

            CreateMap<ProductNote, ProductNoteDTO>()
                .ForMember(c=>c.ProductName,y=>y.MapFrom(z=>z.Product.ProductName));
            CreateMap<ProductNoteDTO, ProductNote>();


            CreateMap<UserRole, UserRoleDTO>();
            CreateMap<UserRoleDTO, UserRole>();

            CreateMap<LinkTest, LinkTestDTO>();
            CreateMap<LinkTestDTO, LinkTest>();

            CreateMap<ProductMotion, ProductMotionDTO>()
                .ForMember(c=>c.ProductName,y=>y.MapFrom(z=>z.Product.ProductName))
                .ForMember(c=>c.Barcode,y=>y.MapFrom(z=>z.Product.Barcode))
                .ForMember(c=>c.PortionName,y=>y.MapFrom(z=>z.Portion.Name))
                .ForMember(c=>c.PortionPrice,y=>y.MapFrom(z=>z.Portion.Price))
                .ForMember(c=>c.UnitName,y=>y.MapFrom(z=>z.Portion.Unit.GroupName))
                .ForMember(c=>c.DeskName,y=>y.MapFrom(z=>z.Adisyon.Desk.Name))
                .ForMember(c=>c.CustomerName,y=>y.MapFrom(z=>z.Adisyon.Customer.CustomerName));

            CreateMap<ProductMotionDTO, ProductMotion>();



        }
    }
}
