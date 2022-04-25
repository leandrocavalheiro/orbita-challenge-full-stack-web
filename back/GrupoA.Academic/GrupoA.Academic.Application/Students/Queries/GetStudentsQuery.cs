using GrupoA.Academic.Application.Abstractions.Models;
using GrupoA.Academic.Application.Students.ViewModels;
using GrupoA.Academic.Commom.ViewModels;

namespace GrupoA.Academic.Application.Students.Queries;

public class GetStudentsQuery : PaginationQuery<PaginationViewModel<StudentListViewModel>>
{
    public GetStudentsQuery(string filter, int page, int pageSize) : base(filter, page, pageSize)
    {
    }
}