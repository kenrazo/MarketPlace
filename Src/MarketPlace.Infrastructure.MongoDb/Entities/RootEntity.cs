using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;

namespace MarketPlace.Infrastructure.MongoDb.Entities
{
    public abstract class RootEntity<TDataEntity> where TDataEntity : class
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        public abstract FilterDefinition<TDataEntity> Filter();
    }
}
