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
                .ForMember(x => x.Password, y => y.MapFrom(z => PasswordEncrypter.Encrypt(z.Password)))
                .ForMember(c => c.CreateDate, y => y.MapFrom(z => z.CreateDate))
                .ForMember(c => c.UpdatedDate, y => y.MapFrom(z => z.UpdatedDate))
                .ForMember(c => c.UpdatedUser, y => y.MapFrom(z => z.UpdatedUser))
                .ForMember(c => c.CreatedUser, y => y.MapFrom(z => z.CreatedUser))
                .ForMember(c => c.Decription, y => y.MapFrom(z => z.Decription))
                ;


            CreateMap<ProductGroup, ProductGroupDTO>();
            CreateMap<ProductGroupDTO, ProductGroup>()
                .ForMember(c=>c.GroupName,y=>y.MapFrom(z=>z.GroupName))
                .ForMember(c => c.CreateDate, y => y.MapFrom(z => z.CreateDate))
                .ForMember(c => c.UpdatedDate, y => y.MapFrom(z => z.UpdatedDate))
                .ForMember(c => c.UpdatedUser, y => y.MapFrom(z => z.UpdatedUser))
                .ForMember(c => c.CreatedUser, y => y.MapFrom(z => z.CreatedUser))
                .ForMember(c => c.Decription, y => y.MapFrom(z => z.Decription))
                ; 



        }
    }
}
