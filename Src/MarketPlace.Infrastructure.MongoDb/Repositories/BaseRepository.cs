using MarketPlace.Infrastructure.MongoDb.Abstractions;
using MarketPlace.Infrastructure.MongoDb.Entities;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace MarketPlace.Infrastructure.MongoDb.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepositoryBase<TEntity>
        where TEntity : RootEntity<TEntity>
    {
        protected readonly IMongoCollection<TEntity> Collection;
        private readonly Func<DateTime> _currentDate;

        public BaseRepository(IMongoCollection<TEntity> collection)
        {
            Collection = collection;
            _currentDate = GetCurrentUtcDate;
        }

        public async Task<IEnumerable<TEntity>> FindItems(Expression<Func<TEntity, bool>> filter)
        {
            return await Collection.Find(filter).ToListAsync();
        }

        public async Task<TEntity> GetItemById(string id)
        {
            var entity = await Collection.Find(e => e.Id == id).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception($"Entity of type:${typeof(TEntity)} with Id: ${id} was not found");
            }

            return entity;
        }

        public async Task Insert(TEntity entity)
        {
            SetDates(entity);
            await Collection.InsertOneAsync(entity);
        }

        public bool TryGetItem(Expression<Func<TEntity, bool>> filter, out TEntity result)
        {
            var entity = Collection.Find(filter).FirstOrDefault();
            result = entity;
            return result != null;
        }

        public async Task Update(TEntity entity)
        {
            var filter = entity.Filter();
            SetDates(entity);
            await Collection.ReplaceOneAsync(filter, entity, options: new ReplaceOptions { IsUpsert = true });
        }

        private DateTime GetCurrentUtcDate()
        {
            return DateTime.UtcNow;
        }

        private void SetDates(TEntity entity, bool isUpdate = true)
        {
            if (!(entity is ITimeStamped trackingOne))
            {
                return;
            }

            if (isUpdate)
            {
                trackingOne.ModifiedOn = _currentDate();
            }
            else
            {
                trackingOne.CreatedOn = _currentDate();
            }
        }
    }
}
