using MarketPlace.Infrastructure.MongoDb.Abstractions;
using MongoDB.Driver;

namespace MarketPlace.Infrastructure.MongoDb.Entities.User
{
    public class User : RootEntity<User>, ITimeStamped
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public override FilterDefinition<User> Filter()
        {
            return Builders<User>.Filter.Eq(p => p.Id, Id);
        }
    }
}
