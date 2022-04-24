using System.Threading.Tasks;

namespace GrupoA.Academic.Domain.Students.Interfaces;

public interface IStudentService
{
    Task<bool> StudentAlreadyRegistered(string ra, string cpf);
}