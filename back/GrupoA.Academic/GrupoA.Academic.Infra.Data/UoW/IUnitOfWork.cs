using GrupoA.Academic.Domain.Students.Interfaces;
using System;
using System.Threading.Tasks;

namespace GrupoA.Academic.Infra.Data.UoW;

public interface IUnitOfWork : IDisposable
{
    IStudentRepository Students { get; }
    Task<bool> Commit();
}