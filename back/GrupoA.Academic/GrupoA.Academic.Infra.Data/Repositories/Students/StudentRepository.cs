using GrupoA.Academic.Domain.Students.Entities;
using GrupoA.Academic.Domain.Students.Interfaces;
using GrupoA.Academic.Infra.Data.Context;
using GrupoA.Academic.Infra.Data.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GrupoA.Academic.Infra.Data.Repositories.Students;

public class StudentRepository : Repository<Student, AcademicDbContext>, IStudentRepository
{
    public StudentRepository(AcademicDbContext context) : base(context)
    {
    }
    public override IQueryable<Student> GetAll(string filter)
    {
        IQueryable<Student> query = _context.Students.AsNoTrackingWithIdentityResolution();
        if (!string.IsNullOrEmpty(filter))
            query = query.Where(x => x.Name.Contains(filter));

        return query
                    .OrderBy(p => p.Code);
    }
}