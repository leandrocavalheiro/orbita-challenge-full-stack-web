using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GrupoA.Academic.Api.Configurations;

public static class MediatorConfiguration
{
    public static void AddMediator(this IServiceCollection services)
    {
        var assembly = AppDomain.CurrentDomain.Load("GrupoA.Academic.Application");
        services.AddScoped<ServiceFactory>(p => p.GetService);
        services.AddMediatR(config => config.AsScoped(), assembly);
    }
}