using GrupoA.Academic.Application.Students.Services;
using GrupoA.Academic.Commom.Interfaces;
using GrupoA.Academic.Commom.Notifications;
using GrupoA.Academic.Domain.Students.Interfaces;
using GrupoA.Academic.Infra.Data.UoW;
using Microsoft.Extensions.DependencyInjection;

namespace GrupoA.Academic.Api.Configurations;
public static class AcademicServicesConfiguration
{
    public static void AddAcademicServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();        
        services.AddScoped<INotificationContext, NotificationContext>();

        services.AddScoped<IStudentService, StudentService>();
    }
}
