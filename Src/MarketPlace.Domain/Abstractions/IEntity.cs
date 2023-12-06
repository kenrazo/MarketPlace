using MarketPlace.Domain.Abstractions;

namespace MarketPlace.SharedKernel.Abstractions
{
    public interface IEntity
    {
        void ClearDomainEvents();
        IReadOnlyList<IDomainEvent> GetDomainEvents();
    }
}
