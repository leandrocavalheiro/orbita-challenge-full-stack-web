using GrupoA.Academic.Domain.Students.Entities;
using GrupoA.Academic.Infra.Data.Generals;
using Microsoft.EntityFrameworkCore;

namespace GrupoA.Academic.Infra.Data.Extensions;
public static class ConfigureSequenceExtension
{
    public static void AddSequences(this ModelBuilder builder)
    {
        builder
            .HasSequence<int>(AcademicDataType.SequenceName(nameof(Student)));
    }
}