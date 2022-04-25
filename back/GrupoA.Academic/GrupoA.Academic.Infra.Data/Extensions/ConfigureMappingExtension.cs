using GrupoA.Academic.Infra.Data.Mappings.Students;
using Microsoft.EntityFrameworkCore;

namespace GrupoA.Academic.Infra.Data.Extensions;

public static class ConfigureMappingExtension
{
    public static void AddMappings(this ModelBuilder builder)
    {
        builder.ApplyConfiguration(new StudentMap());
    }
}