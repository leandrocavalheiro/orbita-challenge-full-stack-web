using GrupoA.Academic.Application.Abstractions.Interfaces;
using GrupoA.Academic.Application.Students.ViewModels;
using System;

namespace GrupoA.Academic.Application.Students.Commands;
public class CreateStudentCommand : ICommand<StudentViewModel>
{
    public Guid Id { get; private set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int Ra { get; set; }
    public string Cpf { get; set; }
    public CreateStudentCommand()
    {
        Id = Guid.NewGuid();
    }
}