
using GrupoA.Academic.Application.Abstractions.Models;
using GrupoA.Academic.Application.Resources;
using GrupoA.Academic.Application.Students.Commands;
using GrupoA.Academic.Commom.Interfaces;
using GrupoA.Academic.Infra.Data.UoW;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GrupoA.Academic.Application.Students.CommandHandlers;

public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, CommandResult<bool>>
{
    private readonly IUnitOfWork _uow;
    private readonly INotificationContext _notificationContext;

    public DeleteStudentCommandHandler(IUnitOfWork uow, INotificationContext notificationContext)
    {
        _uow = uow;
        _notificationContext = notificationContext;
    }
    public async Task<CommandResult<bool>> Handle(DeleteStudentCommand command, CancellationToken cancellationToken)
    {

        var student = await _uow.Students.GetById(command.Id);
        if (student.Equals(null))
        {
            _notificationContext.NotFound(nameof(Messages.StudentNotFound), Messages.StudentNotFound);
            return new CommandResult<bool>();
        }

        _uow.Students.Delete(student);

        if (await _uow.Commit())
            return new CommandResult<bool>(true, true);

        _notificationContext.BadRequest(nameof(Messages.UnableToSaveRecord), Messages.UnableToSaveRecord);
        return new CommandResult<bool>();
    }
}