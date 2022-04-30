using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GrupoA.Academic.Domain.Abstractions.Interfaces;
public interface IRepository<TEntity> where TEntity : class
{
    Task<TEntity> GetById(Guid id, bool asNoTracking = false);
    IQueryable<TEntity> GetAll(string filter = "", string sortBy = "Code", bool sortDesc = true);
    Task Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity, bool destroy = false);
    Task<int> SaveChanges();
    Task<bool> Exists(Expression<Func<TEntity, bool>> predicate);
}