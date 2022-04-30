using AutoMapper;
using GrupoA.Academic.Application.Students.Queries;
using GrupoA.Academic.Application.Students.ViewModels;
using GrupoA.Academic.Commom.ViewModels;
using GrupoA.Academic.Domain.Students.Entities;
using GrupoA.Academic.Infra.Data.Extensions;
using GrupoA.Academic.Infra.Data.UoW;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GrupoA.Academic.Application.Students.QueryHandlers;

public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, PaginationViewModel<StudentListViewModel>>
{

    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public GetStudentsQueryHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<PaginationViewModel<StudentListViewModel>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
    {
        return await _uow.Students.GetAll(request.Filter, request.SortBy, request.SortDesc)
                                    .PaginationAsync<Student, StudentListViewModel>(_mapper, request.Page, request.PageSize, cancellationToken);
    }
}