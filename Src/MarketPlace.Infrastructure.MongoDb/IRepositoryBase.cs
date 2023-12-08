using MarketPlace.Infrastructure.MongoDb.Entities;
using System.Linq.Expressions;

namespace MarketPlace.Infrastructure.MongoDb
{
    public interface IRepositoryBase<TEntity> where TEntity : RootEntity<TEntity>
    {
        public bool TryGetItem(Expression<Func<TEntity, bool>> filter, out TEntity result);

        public Task<TEntity> GetItemById(string id);

        public Task Update(TEntity entity);

        public Task Insert(TEntity entity);

        public Task<IEnumerable<TEntity>> FindItems(Expression<Func<TEntity, bool>> filter);
    }
}
