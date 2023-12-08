using MarketPlace.Domain.Users.ValueObjects;

namespace MarketPlace.Domain.Users
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(UserId id, CancellationToken cancellationToken = default);
        Task Add(User user);
    }
}
