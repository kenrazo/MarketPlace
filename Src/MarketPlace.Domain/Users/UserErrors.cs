using MarketPlace.Domain.Abstractions;

namespace MarketPlace.Domain.Users
{
    public static class UserErrors
    {
        private const string IdentityIdNotSavedCode = "User.IdentityIdNotSaved";
        public static readonly Error IdentityIdNotSaved = new(IdentityIdNotSavedCode, "IdentityId not saved");
    }
}
