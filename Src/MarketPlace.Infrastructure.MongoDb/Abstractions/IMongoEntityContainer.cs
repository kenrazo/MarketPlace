namespace MarketPlace.Infrastructure.MongoDb.Abstractions
{
    public interface IMongoEntityContainer<out TEntity>
    {
        TEntity AsState();
    }
}
