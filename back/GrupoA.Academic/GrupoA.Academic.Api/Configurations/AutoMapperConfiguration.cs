using Microsoft.Extensions.DependencyInjection;
using System;

namespace GrupoA.Academic.Api.Configurations;

public static class AutoMapperConfiguration
{
    public static void AddAutoMapper(this IServiceCollection services)
    {
        var assembly = AppDomain.CurrentDomain.Load("GrupoA.Academic.Application");
        services.AddAutoMapper(assembly);
    }
}