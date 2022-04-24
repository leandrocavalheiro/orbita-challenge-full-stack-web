using System.Linq.Expressions;

namespace GrupoA.Academic.Domain.Abstractions.Interfaces;
public interface IRepository<TEntity> where TEntity : class
{
    Task<TEntity> GetById(Guid id, bool asNoTracking = false);
    IQueryable<TEntity> GetAll();
    Task Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity, bool destroy = false);
    Task<int> SaveChanges();
    Task<bool> Exists(Expression<Func<TEntity, bool>> predicate);
}