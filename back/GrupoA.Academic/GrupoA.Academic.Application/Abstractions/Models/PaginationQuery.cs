using MediatR;

namespace GrupoA.Academic.Application.Abstractions.Models;

public class PaginationQuery<TResponse> : IRequest<TResponse>
{
    public string Filter { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }

    public PaginationQuery(string filter, int page, int pageSize)
    {
        Filter = filter;
        Page = page;
        PageSize = pageSize;
    }
}