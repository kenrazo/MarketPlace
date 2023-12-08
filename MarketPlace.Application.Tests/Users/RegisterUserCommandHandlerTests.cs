using FluentAssertions;
using MarketPlace.Application.Authentication;
using MarketPlace.Application.Users;
using MarketPlace.Domain.Abstractions;
using MarketPlace.Domain.Users;
using NSubstitute;

namespace MarketPlace.Application.Tests.Users
{
    public class RegisterUserCommandHandlerTests
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly RegisterUserCommandHandler _registerCommandHandler;

        public RegisterUserCommandHandlerTests()
        {
            _authenticationService = Substitute.For<IAuthenticationService>();
            _userRepository = Substitute.For<IUserRepository>();
            _unitOfWork = Substitute.For<IUnitOfWork>();

            _registerCommandHandler = new RegisterUserCommandHandler(_authenticationService,
                _userRepository, _unitOfWork);
        }

        [Fact]
        public async Task Handle_Should_ReturnIsFailureTrue_WhenIdentityIdIsNullOrEmpty()
        {
            var request = new RegisterUserCommand("email@gmail.com", "first",
                "last", "mobile", "password");


            _authenticationService.RegisterAsync(Arg.Any<User>(), Arg.Any<string>())
                .Returns(string.Empty);

            var result = await _registerCommandHandler.Handle(request, Arg.Any<CancellationToken>());

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(UserErrors.IdentityIdNotSaved);

        }

        [Fact]
        public async Task Handle_Should_ReturnSuccess_WhenInputIsValid()
        {

            var request = new RegisterUserCommand("email@gmail.com", "first",
        "last", "mobile", "password");

            _authenticationService.RegisterAsync(Arg.Any<User>(), Arg.Any<string>())
                .Returns("tesasedasdasdasdsa");


            var result = await _registerCommandHandler.Handle(request,
                default);

            result.Value.Should().NotBeEmpty();
        }
    }
}
