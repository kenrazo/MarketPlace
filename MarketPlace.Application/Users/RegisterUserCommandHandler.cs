using Ardalis.GuardClauses;
using MarketPlace.Application.Abstractions.Messaging;
using MarketPlace.Application.Authentication;
using MarketPlace.Domain.Abstractions;
using MarketPlace.Domain.Users;
using MarketPlace.Domain.Users.ValueObjects;

namespace MarketPlace.Application.Users
{
    public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, Guid>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RegisterUserCommandHandler(IAuthenticationService authenticationService,
            IUserRepository userRepository,
            IUnitOfWork unitOfWork)
        {
            Guard.Against.Null(authenticationService, nameof(authenticationService));
            Guard.Against.Null(userRepository, nameof(userRepository));
            Guard.Against.Null(unitOfWork, nameof(unitOfWork));

            _authenticationService = authenticationService;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = User.Create(new FirstName(request.FirstName),
                new LastName(request.LastName),
                new Email(request.Email),
                new MobileNumber(request.MobileNumber));

            try
            {
                var identityId = await _authenticationService.RegisterAsync(user, request.Password, cancellationToken);

                if (string.IsNullOrEmpty(identityId))
                {
                    return Result.Failure<Guid>(UserErrors.IdentityIdNotSaved);
                }

                user.SetIdentityId(identityId);

                await _userRepository.Add(user);

                await _unitOfWork.SaveChangesAsync();

                return user.Id.Value;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

}
