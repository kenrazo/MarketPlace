namespace MarketPlace.Domain.Users.ValueObjects
{
    public record UserId(Guid Value)
    {
        public static UserId FromValue(Guid Value) => new(Value);
        public static UserId New() => FromValue(Guid.NewGuid());
    }
}
