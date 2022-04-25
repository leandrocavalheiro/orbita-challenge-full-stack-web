using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GrupoA.Academic.Api.Configurations
{
    public static class FluentValidationConfiguration
    {
        public static void AddFluentValidation(this IServiceCollection services)
        {
            services.AddControllers(options => { options.Filters.Add(typeof(FluentValidationFilter)); });
            services.AddMvcCore()
                         .AddFluentValidation(c =>
                         {
                             c.RegisterValidatorsFromAssemblies(new[]
                             {
                                    AppDomain.CurrentDomain.Load("GrupoA.Academic.Application"),
                                });

                             c.DisableDataAnnotationsValidation = false;
                         });
            services.AddScoped<FluentValidationFilter>();
            services.AddScoped<IValidatorInterceptor, FluentValidationInterceptor>();
            services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);
        }
    }
}