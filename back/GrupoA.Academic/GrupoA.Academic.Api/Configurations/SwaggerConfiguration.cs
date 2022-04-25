using Microsoft.AspNetCore.Builder;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace GrupoA.Academic.Api.Configurations;

public static class SwaggerConfiguration
{
    public static IApplicationBuilder UseAcademicSwagger(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.DocExpansion(DocExpansion.None);            
            options.DisplayRequestDuration();
            options.DocumentTitle = "Academic";
        });

        return app;
    }
}