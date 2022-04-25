using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GrupoA.Academic.Commom.ViewModels;

public class PaginationViewModel<T>
{
    public ICollection<T> Items { get; set; }
    public int Page { get; }
    public int PageSize { get; }
    public int TotalRecords { get; set; }
    public int TotalPages { get; set; }

    public PaginationViewModel(ICollection<T> items, int page, int pageSize, int totalRecords, int totalPages)
    {
        Items = items ?? new Collection<T>();
        Page = page;
        PageSize = pageSize;
        TotalRecords = totalRecords;
        TotalPages = totalPages;
    }
}