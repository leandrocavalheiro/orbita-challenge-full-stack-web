using Microsoft.AspNetCore.Builder;

namespace GrupoA.Academic.Api.Configurations
{
    public static class CorsConfiguration
    {
        public static IApplicationBuilder UseAcademicCors(this IApplicationBuilder app)
        {
            return app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });
        }
    }
}