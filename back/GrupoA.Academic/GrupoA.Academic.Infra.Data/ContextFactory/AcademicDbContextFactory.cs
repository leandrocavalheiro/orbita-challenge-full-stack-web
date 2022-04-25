using GrupoA.Academic.Infra.Data.Context;
using GrupoA.Academic.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Reflection;

namespace GrupoA.Academic.Infra.Data.ContextFactory;

public class AcademicDbContextFactory : IDesignTimeDbContextFactory<AcademicDbContext>
{
    public AcademicDbContext CreateDbContext(string[] args)
    {
        var host = new HostBuilderContext(new Dictionary<object, object>()
        {
            {
                "ASPNETCORE_ENVIRONMENT", "Development"
            }
        });
        var configuration = new ConfigurationBuilder().Build();
        var optionsBuilder = new DbContextOptionsBuilder<AcademicDbContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Port=7432;Pooling=true;Database=DB_ACADEMIC;User Id=grupoa;Password=V4Tc3^wZF46S&&E;",
            builder => { builder.MigrationsAssembly(typeof(ConfigureMappingExtension).GetTypeInfo().Assembly.GetName().Name); });
        optionsBuilder.EnableSensitiveDataLogging();

        return new AcademicDbContext(optionsBuilder.Options, configuration);
    }
}
