using AutoMapper;
using GrupoA.Academic.Application.Resources;
using GrupoA.Academic.Application.Students.Queries;
using GrupoA.Academic.Application.Students.ViewModels;
using GrupoA.Academic.Commom.Interfaces;
using GrupoA.Academic.Infra.Data.UoW;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GrupoA.Academic.Application.Students.QueryHandlers;

public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, StudentViewModel>
{

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _uow;
    private readonly INotificationContext _notificationContext;

    public GetStudentByIdQueryHandler(IUnitOfWork uow, IMapper mapper, INotificationContext notificationContext)
    {
        _mapper = mapper;
        _uow = uow;
        _notificationContext = notificationContext;
    }

    public async Task<StudentViewModel> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
    {

        var student = await _uow.Students.GetById(request.Id);
        if (student != null)
            return _mapper.Map<StudentViewModel>(student);

        _notificationContext.NotFound(nameof(Messages.StudentNotFound), Messages.StudentNotFound);
        return null;
    }
}