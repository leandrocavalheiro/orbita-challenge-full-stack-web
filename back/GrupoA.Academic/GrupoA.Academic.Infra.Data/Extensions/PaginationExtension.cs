using AutoMapper;
using AutoMapper.QueryableExtensions;
using GrupoA.Academic.Commom.ViewModels;
using GrupoA.Academic.Domain.Abstractions.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GrupoA.Academic.Infra.Data.Extensions;

public static class PaginationExtension
{
    public static async Task<PaginationViewModel<TViewModel>> PaginationAsync<TEntity, TViewModel>(this IQueryable<TEntity> query, IMapper mapper, int page = 1, int pageSize = 25, CancellationToken cancellationToken = default) where TEntity : BaseEntity
    {
        var skip = (page - 1) * pageSize;
        query = query.Where(p => p.DeletedAt.Equals(null));
        var totalRecords = await query.CountAsync(cancellationToken);
        var totalPages = (int)Math.Ceiling((totalRecords / (decimal)pageSize));

        var list = await
            query
                .Skip(skip)
                .Take(pageSize)
                .ProjectTo<TViewModel>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

        return new PaginationViewModel<TViewModel>(list, page, pageSize, totalRecords, totalPages);
    }
}