using GrupoA.Academic.Domain.Students.Interfaces;
using GrupoA.Academic.Infra.Data.Context;
using GrupoA.Academic.Infra.Data.Repositories.Students;
using System.Threading.Tasks;

namespace GrupoA.Academic.Infra.Data.UoW;

public class UnitOfWork : IUnitOfWork
{
    private readonly AcademicDbContext _academicDbContext;
    private IStudentRepository _students;
    public IStudentRepository Students => _students ??= new StudentRepository(_academicDbContext);
    public UnitOfWork(AcademicDbContext academicDbContext)
    {
        _academicDbContext = academicDbContext;
    }
    public async Task<bool> Commit()
    {
        if (!_academicDbContext.ChangeTracker.HasChanges())
            return true;

        return await _academicDbContext.SaveChangesAsync() > 0;
    }
    public void Dispose()
    {
        _academicDbContext.Dispose();
    }
}