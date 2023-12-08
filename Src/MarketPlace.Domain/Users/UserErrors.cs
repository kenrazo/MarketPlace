using MarketPlace.Domain.Abstractions;

namespace MarketPlace.Domain.Users
{
    public static class UserErrors
    {
        private const string InvalidEmailCode = "Invalid.Email";
        private const string InvalidMobileNumberCode = "Invalid.Phone";

        public static readonly Error EmailIsNotValid = new(InvalidEmailCode, "Invalid email");
        public static readonly Error InvalidMobileNumber = new(InvalidMobileNumberCode, "Invalid mobile number");
    }
}
