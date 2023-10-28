﻿using AutoMapper;
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
                .ForMember(x => x.Password, y => y.MapFrom(z => PasswordEncrypter.Encrypt(z.Password))) ;

            CreateMap<ProductGroup, ProductGroupDTO>();
            CreateMap<ProductGroupDTO, ProductGroup>();

            CreateMap<Product, ProductDTO>()
                .ForMember(c => c.GroupName, y => y.MapFrom(z => z.ProductGroup.GroupName));
            CreateMap<ProductDTO, Product>();

            CreateMap<Portion, PortionDTO>()
                .ForMember(c=>c.ProductName,y=>y.MapFrom(z=>z.Product.ProductName))
                .ForMember(c=>c.GroupName,y=>y.MapFrom(z=>z.Unit.GroupName));
            CreateMap<PortionDTO, Portion>();

            CreateMap<SupplementaryMaterial, SupplementaryMaterialDTO>()
                .ForMember(c => c.ProductName, y => y.MapFrom(z => z.Product.ProductName));
            CreateMap<SupplementaryMaterialDTO, SupplementaryMaterial>();

            CreateMap<Unit, UnitDTO>();
            CreateMap<UnitDTO, Unit>();

            CreateMap<ProductNote, ProductNoteDTO>();
            CreateMap<ProductNoteDTO, ProductNote>();



        }
    }
}
