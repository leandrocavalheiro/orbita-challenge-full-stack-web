using GrupoA.Academic.Domain.Abstractions.Entities;
using GrupoA.Academic.Domain.Abstractions.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GrupoA.Academic.Infra.Data.Extensions;

namespace GrupoA.Academic.Infra.Data.Repositories.Abstractions;

public abstract class Repository<TEntity, TContext> : IRepository<TEntity> where TEntity : BaseEntity
                                                                           where TContext : DbContext
{
    protected readonly TContext _context;
    public Repository(TContext context)
    {
        _context = context;
    }
    public virtual async Task Add(TEntity entity)
        => await _context
                    .Set<TEntity>()
                    .AddAsync(entity);
    public virtual void Delete(TEntity entity, bool destroy = false)
    {
        if (destroy)
        {
            _context.Set<TEntity>().Remove(entity);
            return;
        }

        entity.DeletedAt = DateTime.UtcNow;
        Update(entity);
    }
    public virtual async Task<bool> Exists(Expression<Func<TEntity, bool>> predicate)
    {
        return await _context
                        .Set<TEntity>()
                        .AsNoTrackingWithIdentityResolution()
                        .Where(p => p.DeletedAt.Equals(null))
                        .AnyAsync(predicate);
    }
    public virtual IQueryable<TEntity> GetAll(string filter = "", string sortBy = "CreatedAt", bool sortDesc = true)
    {
        IQueryable<TEntity> query = _context
                                        .Set<TEntity>()
                                        .AsNoTrackingWithIdentityResolution()
                                        .Where(p => p.DeletedAt.Equals(null));        

        return query.AddSort(sortBy, sortDesc);
    }
    public virtual async Task<TEntity> GetById(Guid id, bool asNoTracking = false)
    {
        var query = _context.Set<TEntity>().AsQueryable();
        if (asNoTracking)
            query = query.AsNoTrackingWithIdentityResolution();

        return await query
                        .FirstOrDefaultAsync(e => e.Id == id);
    }
    public virtual void Update(TEntity entity)
        => _context
            .Set<TEntity>()
            .Update(entity);
    public virtual async Task<int> SaveChanges()
        => await _context.SaveChangesAsync();
    
}