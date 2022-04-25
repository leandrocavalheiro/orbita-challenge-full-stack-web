using GrupoA.Academic.Application.Abstractions.Interfaces;
using System;

namespace GrupoA.Academic.Application.Students.Commands;

public class DeleteStudentCommand : ICommand<bool>
{
    public Guid Id { get; private set; }
    public DeleteStudentCommand(Guid id)
    {
        Id = id;
    }
}