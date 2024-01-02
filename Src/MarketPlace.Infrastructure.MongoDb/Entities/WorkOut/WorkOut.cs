using MarketPlace.Infrastructure.MongoDb.Abstractions;
using MongoDB.Driver;

namespace MarketPlace.Infrastructure.MongoDb.Entities.WorkOut
{
    public class WorkOut : RootEntity<WorkOut>, ITimeStamped
    {
        public Guid WorkOutId { get; set; }
        public DateTime WorkOutDate { get; set; }
        public List<Excercise> Excercises { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public override FilterDefinition<WorkOut> Filter()
        {
            throw new NotImplementedException();
        }
    }
}
