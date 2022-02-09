using Core.Layers.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Core.Layers.DAL.Repositories
{
    public interface IGenericRepository<TEntity, TKey> :
            IAsyncRepository<TEntity, TKey>,
            ISyncRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>, new()
        where TKey : IEquatable<TKey>
    {
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
    }
}
