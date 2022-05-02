using GrupoA.Academic.Application.Resources;
using GrupoA.Academic.Commom.Interfaces;
using GrupoA.Academic.Domain.Students.Interfaces;
using GrupoA.Academic.Infra.Data.UoW;
using System.Threading.Tasks;

namespace GrupoA.Academic.Application.Students.Services;

public class StudentService : IStudentService
{
    private readonly IUnitOfWork _uow;
    private readonly INotificationContext _notificationContext;
    public StudentService(IUnitOfWork uow, INotificationContext notificationContext)
    {
        _uow = uow;
        _notificationContext = notificationContext;
    }
    public async Task<bool> StudentAlreadyRegistered(int ra, string cpf)
    {        
        if (!await _uow.Students.Exists(p => p.Ra.Equals(ra) || p.Cpf.Equals(cpf)))
            return false;

        _notificationContext.BadRequest(nameof(Messages.StudentAlreadyRegistered), Messages.StudentAlreadyRegistered);
        return true;
    }
}