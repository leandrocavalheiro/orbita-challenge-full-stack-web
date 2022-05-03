using MediatR;

namespace GrupoA.Academic.Application.Abstractions.Models;

public class PaginationQuery<TResponse> : IRequest<TResponse>
{
    public string Filter { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
    public string SortBy { get; set; }
    public bool SortDesc { get; set; }

    public PaginationQuery(string filter, int page, int pageSize, string sortBy = "Code", bool sortDesc = true)
    {
        Filter = filter;
        Page = page;
        PageSize = pageSize;
        SortBy = sortBy;
        SortDesc = sortDesc;
    }
}