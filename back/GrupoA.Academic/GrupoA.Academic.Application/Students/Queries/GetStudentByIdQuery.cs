using GrupoA.Academic.Application.Students.ViewModels;
using MediatR;
using System;

namespace GrupoA.Academic.Application.Students.Queries;

public class GetStudentByIdQuery : IRequest<StudentViewModel>
{
    public Guid Id { get; private set; }
    public GetStudentByIdQuery(Guid id)
    {
        Id = id;
    }
}