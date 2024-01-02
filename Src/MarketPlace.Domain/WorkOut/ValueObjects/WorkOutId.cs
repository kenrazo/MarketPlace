namespace MarketPlace.Domain.WorkOut.ValueObjects
{
    public record WorkOutId(Guid Value)
    {
        public static WorkOutId FromValue(Guid Value) => new(Value);
        public static WorkOutId New() => FromValue(Guid.NewGuid());
    }
}
