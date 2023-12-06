using MarketPlace.SharedKernel.Abstractions;

namespace MarketPlace.Domain.Abstractions
{
    public class Entity<TEntityId> : IEntity
    {
        private readonly List<IDomainEvent> _domainEvents = new();

        protected Entity(TEntityId id) => Id = id;

        protected Entity() { }

        public TEntityId Id { get; init; }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        public IReadOnlyList<IDomainEvent> GetDomainEvents()
        {
            return _domainEvents.ToList();
        }
    }
}
