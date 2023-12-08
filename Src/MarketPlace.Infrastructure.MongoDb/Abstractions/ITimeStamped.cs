namespace MarketPlace.Infrastructure.MongoDb.Abstractions
{
    public interface ITimeStamped
    {
        DateTime CreatedOn { get; set; }
        DateTime? ModifiedOn { get; set; }
    }
}
