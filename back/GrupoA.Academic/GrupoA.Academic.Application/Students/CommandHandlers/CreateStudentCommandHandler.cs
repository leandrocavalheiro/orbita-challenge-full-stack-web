using AutoMapper;
using GrupoA.Academic.Application.Abstractions.Models;
using GrupoA.Academic.Application.Resources;
using GrupoA.Academic.Application.Students.Commands;
using GrupoA.Academic.Application.Students.ViewModels;
using GrupoA.Academic.Commom.Extensions;
using GrupoA.Academic.Commom.Interfaces;
using GrupoA.Academic.Domain.Students.Entities;
using GrupoA.Academic.Domain.Students.Interfaces;
using GrupoA.Academic.Infra.Data.UoW;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GrupoA.Academic.Application.Students.CommandHandlers;

public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, CommandResult<StudentViewModel>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly INotificationContext _notificationContext;
    private readonly IStudentService _studentService;

    public CreateStudentCommandHandler(IUnitOfWork uow, INotificationContext notificationContext, IMapper mapper, IStudentService studentService)
    {
        _uow = uow;
        _mapper = mapper;
        _notificationContext = notificationContext;
        _studentService = studentService;
    }

    public async Task<CommandResult<StudentViewModel>> Handle(CreateStudentCommand command, CancellationToken cancellationToken)
    {
        command.Cpf = command.Cpf.RemoveCpfMask();

        if (!await Validations(command))
            return new CommandResult<StudentViewModel>();

        var newStudent = _mapper.Map<Student>(command);
        await _uow.Students.Add(newStudent);

        if (await _uow.Commit())
            return new CommandResult<StudentViewModel>(true, _mapper.Map<StudentViewModel>(newStudent));

        _notificationContext.BadRequest(nameof(Messages.UnableToSaveRecord), Messages.UnableToSaveRecord);
        return new CommandResult<StudentViewModel>();
    }

    private async Task<bool> Validations(CreateStudentCommand command)
    {
        await _studentService.StudentAlreadyRegistered(command.Ra, command.Cpf);
        return !_notificationContext.HasNotifications();
    }
}