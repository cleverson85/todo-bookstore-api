using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using ToDo.Application.Mappers;

namespace ToDo.Infrastructure.IoC
{
    public static class InjectAutoMapper
    {
        public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSingleton<IConfigurationProvider>(RegisterMapper.Register());

            return services;
        }
    }
}
