using GrupoA.Academic.Domain.Students.Entities;
using GrupoA.Academic.Domain.Students.Interfaces;
using GrupoA.Academic.Infra.Data.Context;
using GrupoA.Academic.Infra.Data.Extensions;
using GrupoA.Academic.Infra.Data.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GrupoA.Academic.Infra.Data.Repositories.Students;

public class StudentRepository : Repository<Student, AcademicDbContext>, IStudentRepository
{
    public StudentRepository(AcademicDbContext context) : base(context)
    {
    }
    public override IQueryable<Student> GetAll(string filter = "", string sortBy = "Code", bool sortDesc = true)
    {
        //TODO Corrigir o filtro para utilizar StringComparison.CurrentCultureIgnoreCase e não ToLower()
        //por hora ficou com ToLower(), pois está apresentando erro com "StringComparison.CurrentCultureIgnoreCase"
        IQueryable<Student> query = _context.Students.AsNoTrackingWithIdentityResolution();
        if (!string.IsNullOrEmpty(filter))
            query = query.Where(x => x.Name.ToLower().Contains(filter.ToLower()) ||
                                     x.Email.ToLower().Contains(filter.ToLower()));

        query =  query
                    .AddSort(sortBy, sortDesc);

        return query;
    }
}