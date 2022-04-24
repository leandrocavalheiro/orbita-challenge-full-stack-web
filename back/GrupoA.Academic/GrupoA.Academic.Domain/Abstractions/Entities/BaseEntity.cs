using GrupoA.Academic.Commom.Generals;
using System;

namespace GrupoA.Academic.Domain.Abstractions.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public bool IsActive()
    {
        return DeletedAt.Equals(null);
    }
    public BaseEntity(Guid id)
    {
        Id = id;
        CreatedAt = AcademicMethods.Now();
        UpdatedAt = CreatedAt;
    }
    public BaseEntity()
    {

    }
}