using MarketPlace.Domain.Abstractions;

namespace MarketPlace.Application.Authentication
{
    public interface IJwtService
    {
        Task<Result<string>> GetAccessTokenAsync(string email,
            string password,
            CancellationToken cancellationToken = default);
    }
}
