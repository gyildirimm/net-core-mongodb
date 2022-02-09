using Core.Layers.Domain.Entities;
using Core.Utilities.Settings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Extensions.Database;
using Microsoft.Extensions.Options;
using MongoDB.Bson;

namespace Core.Layers.DAL.Repositories.MongoDb
{
    public class MongoBaseRepository<TEntity> 
            : IGenericRepository<TEntity, string>
        where TEntity : MongoBaseEntity, new()
    {
        private readonly IMongoCollection<TEntity> _collection;

        public MongoBaseRepository(IOptions<MongoDbSetting> options)
        {
            _collection = options.Value.GetCollection<TEntity>();
        }

        public TEntity Add(TEntity createEntity)
        {
            var options = new InsertOneOptions { BypassDocumentValidation = false };
            _collection.InsertOne(createEntity, options);

            return createEntity;
        }

        public async Task<TEntity> AddAsync(TEntity createEntity)
        {
            var options = new InsertOneOptions { BypassDocumentValidation = false };
            await _collection.InsertOneAsync(createEntity, options);

            return createEntity;
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _collection.Find(predicate).FirstOrDefault();
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return _collection.Find(predicate).ToEnumerable();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = await _collection.FindAsync(predicate);

            return entities.ToEnumerable();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entity = await _collection.FindAsync(predicate);

            return await entity.FirstOrDefaultAsync();
        }

        public TEntity GetById(string key)
        {
            return _collection.Find(x => x.Id == key).FirstOrDefault();
        }

        public async Task<TEntity> GetByIdAsync(string key)
        {
            return await _collection.Find(x => x.Id == key).FirstOrDefaultAsync();
        }

        public void Remove(TEntity deleteEntity)
        {
            _collection.FindOneAndDelete(x => x.Id.Equals(deleteEntity.Id));
        }

        public void Remove(string key)
        {
            _collection.FindOneAndDelete(x => x.Id == key);
        }

        public async Task RemoveAsync(TEntity deleteEntity)
        {
            await _collection.FindOneAndDeleteAsync(x => x.Id.Equals(deleteEntity.Id));
        }

        public async Task RemoveAsync(string key)
        {
           await _collection.FindOneAndDeleteAsync(x => x.Id == key);
        }

        public TEntity Update(TEntity updateEntity)
        {
            return _collection.FindOneAndReplace(x => x.Id == updateEntity.Id, updateEntity);
        }

        public async Task<TEntity> UpdateAsync(TEntity updateEntity)
        {
            await _collection.ReplaceOneAsync(x => x.Id == updateEntity.Id, updateEntity);
           
            return updateEntity;
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return predicate == null
                ? _collection.AsQueryable()
                : _collection.AsQueryable().Where(predicate);
        }
    }
}
