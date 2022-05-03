using GrupoA.Academic.Domain.Students.Entities;
using GrupoA.Academic.Infra.Data.Generals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrupoA.Academic.Infra.Data.Mappings.Students;

public class StudentMap : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder
            .ToTable(nameof(Student));
        

        builder
            .Property(p => p.Code)
            .HasColumnType(AcademicDataType.Integer)
            .HasDefaultValueSql(AcademicDataType.DetaultNextval(nameof(Student)));

        builder
            .Property(m => m.Id)
            .HasColumnType(AcademicDataType.Uuid)
            .IsRequired();

        builder
            .Property(m => m.CreatedAt)
            .HasColumnType(AcademicDataType.Date)
            .IsRequired();

        builder
            .Property(m => m.UpdatedAt)
            .HasColumnType(AcademicDataType.Date)
            .IsRequired();

        builder
            .Property(m => m.DeletedAt)
            .HasColumnType(AcademicDataType.Date);

        builder
            .Property(m => m.Name)
            .HasColumnType(AcademicDataType.String())
            .IsRequired();

        builder
            .Property(m => m.Email)
            .HasColumnType(AcademicDataType.String())
            .IsRequired();

        builder
            .Property(m => m.Cpf)
            .HasColumnType(AcademicDataType.String(11))
            .IsRequired();

        builder
            .Property(m => m.Ra)
            .HasColumnType(AcademicDataType.Integer)
            .IsRequired();

        builder
            .HasIndex(x => x.Ra)
            .IsUnique();
    }
}