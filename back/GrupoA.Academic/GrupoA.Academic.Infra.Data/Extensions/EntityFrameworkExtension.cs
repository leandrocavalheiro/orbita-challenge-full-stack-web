using GrupoA.Academic.Commom.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GrupoA.Academic.Infra.Data.Extensions
{
    public static class EntityFrameworkExtension
    {
        public static IQueryable<TEntity> AddSort<TEntity>(this IQueryable<TEntity> value, string sortby = "CreatedAt", bool sortDesc = true)
        {
            if (sortDesc)
                return value
                            .OrderByDescending(p => EF.Property<object>(p, sortby.PascalCase()));
            else
                return value
                            .OrderBy(p => EF.Property<object>(p, sortby.PascalCase()));
        }
    }
}
