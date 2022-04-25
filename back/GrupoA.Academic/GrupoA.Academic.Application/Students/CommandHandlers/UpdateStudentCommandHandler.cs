using AutoMapper;
using GrupoA.Academic.Application.Abstractions.Models;
using GrupoA.Academic.Application.Resources;
using GrupoA.Academic.Application.Students.Commands;
using GrupoA.Academic.Application.Students.ViewModels;
using GrupoA.Academic.Commom.Interfaces;
using GrupoA.Academic.Domain.Students.Entities;
using GrupoA.Academic.Infra.Data.UoW;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GrupoA.Academic.Application.Students.CommandHandlers;

public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, CommandResult<StudentViewModel>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly INotificationContext _notificationContext;

    public UpdateStudentCommandHandler(IUnitOfWork uow, INotificationContext notificationContext, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
        _notificationContext = notificationContext;
    }

    public async Task<CommandResult<StudentViewModel>> Handle(UpdateStudentCommand command, CancellationToken cancellationToken)
    {
        var student = await _uow.Students.GetById(command.Id);
        if (student == null)
        {
            _notificationContext.NotFound(nameof(Messages.StudentNotFound), Messages.StudentNotFound);
            return new CommandResult<StudentViewModel>();
        }

        UpdateStundentData(student, command);

        if (await _uow.Commit())
            return new CommandResult<StudentViewModel>(true, _mapper.Map<StudentViewModel>(student));

        _notificationContext.BadRequest(nameof(Messages.UnableToSaveRecord), Messages.UnableToSaveRecord);
        return new CommandResult<StudentViewModel>();
    }


    private void UpdateStundentData(Student student, UpdateStudentCommand command)
    {
        student.Name = command.Name;
        student.Email = command.Email;
        _uow.Students.Update(student);
    }
}