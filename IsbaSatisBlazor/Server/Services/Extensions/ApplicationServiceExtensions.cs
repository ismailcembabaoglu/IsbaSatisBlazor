﻿using IsbaSatisBlazor.Server.Services.Infrastruce;
using IsbaSatisBlazor.Server.Services.Services;

namespace IsbaSatisBlazor.Server.Services.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection service)
        {
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IProductGroupService, ProductGroupService>();
            service.AddScoped<IProductService, ProductService>();
            return service;
        }
    }
}