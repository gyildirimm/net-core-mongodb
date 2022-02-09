using Core.Layers.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Layers.DAL.Repositories
{
    public interface IAsyncRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>, new()
        where TKey : IEquatable<TKey>
    {
        Task<TEntity> AddAsync(TEntity createEntity);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);

        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate);

        Task<TEntity> GetByIdAsync(TKey key);

        Task<TEntity> UpdateAsync(TEntity updateEntity);

        Task RemoveAsync(TEntity deleteEntity);

        Task RemoveAsync(TKey key);
    }
}
