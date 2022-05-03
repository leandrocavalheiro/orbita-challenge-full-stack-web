using GrupoA.Academic.Commom.Extensions;
using GrupoA.Academic.Domain.Students.Entities;
using GrupoA.Academic.Domain.Students.Interfaces;
using GrupoA.Academic.Infra.Data.Context;
using GrupoA.Academic.Infra.Data.Extensions;
using GrupoA.Academic.Infra.Data.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace GrupoA.Academic.Infra.Data.Repositories.Students;

public class StudentRepository : Repository<Student, AcademicDbContext>, IStudentRepository
{
    public StudentRepository(AcademicDbContext context) : base(context)
    {
    }
    public override IQueryable<Student> GetAll(string filter = "", string sortBy = "Code", bool sortDesc = true)
    {
        var query = _context.Students.AsNoTrackingWithIdentityResolution();
        if (!string.IsNullOrEmpty(filter))
            query = query.Where(x => x.Name.ToLower().Contains(filter.ToLower()) ||
                                     x.Email.ToLower().Contains(filter.ToLower()) ||
                                     x.Cpf.Contains(filter.RemoveCpfMask())||
                                     x.Ra.ToString().Contains(filter) ||
                                     x.Code.ToString().Contains(filter));

        query =  query
                    .AddSort(sortBy, sortDesc);

        return query;
    }
}