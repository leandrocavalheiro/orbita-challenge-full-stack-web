using GrupoA.Academic.Domain.Students.Entities;
using GrupoA.Academic.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GrupoA.Academic.Infra.Data.Context;

public class AcademicDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public AcademicDbContext(DbContextOptions<AcademicDbContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }
    public DbSet<Student> Students { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var orbitaStringConnection = _configuration.GetSection("AcademicStringConnection").Value;
            optionsBuilder.UseNpgsql(orbitaStringConnection);
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.EnableDetailedErrors();
            base.OnConfiguring(optionsBuilder);
        }
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.AddSequences();
        builder.AddMappings();
    }
}
