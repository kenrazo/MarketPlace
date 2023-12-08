using FluentValidation;

namespace MarketPlace.Application.Users
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(c => c.FirstName).NotEmpty();
            RuleFor(c => c.LastName).NotEmpty();
            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();
            RuleFor(c => c.Password).NotEmpty();
            RuleFor(c => c.MobileNumber).NotEmpty();
        }
    }
}
