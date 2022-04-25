using GrupoA.Academic.Commom.Notifications;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System.Net.Mime;

namespace GrupoA.Academic.Api.Configurations;
public static class ExceptionHandlerMiddleware
{
    public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder app, IWebHostEnvironment environment)
    {
        return app.UseExceptionHandler(errorApp =>
        {
            errorApp.Run(async context =>
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = MediaTypeNames.Application.Json;

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (environment.IsProduction())
                    await context.Response.WriteAsync(new Notification("", nameof(StatusCodes.Status500InternalServerError), contextFeature?.Error?.Message, context.Response.StatusCode, contextFeature?.Error?.InnerException?.Message).ToString());
                else
                    await context.Response.WriteAsync(new Notification("", nameof(StatusCodes.Status500InternalServerError), contextFeature?.Error?.Message, context.Response.StatusCode, contextFeature?.Error?.InnerException?.Message, contextFeature?.Error?.StackTrace).ToString());

            });
        });
    }
}