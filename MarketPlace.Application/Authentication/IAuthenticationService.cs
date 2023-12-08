using MarketPlace.Domain.Users;

namespace MarketPlace.Application.Authentication
{
    public interface IAuthenticationService
    {
        Task<string> RegisterAsync(User user,
            string password,
            CancellationToken cancellationToken = default);
    }
}
