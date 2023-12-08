using MarketPlace.Domain.Abstractions;
using MarketPlace.Domain.Users.ValueObjects;

namespace MarketPlace.Domain.Users.Events
{
    public record UserCreatedDomainEvent(UserId UserId) : IDomainEvent;
}
