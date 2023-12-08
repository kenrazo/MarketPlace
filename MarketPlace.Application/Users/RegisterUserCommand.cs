using MarketPlace.Application.Abstractions.Messaging;

namespace MarketPlace.Application.Users
{
    public record RegisterUserCommand(string Email,
        string FirstName,
        string LastName,
        string MobileNumber,
        string Password) : ICommand<Guid>;

}
