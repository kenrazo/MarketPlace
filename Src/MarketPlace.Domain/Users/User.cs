using MarketPlace.Domain.Abstractions;
using MarketPlace.Domain.Users.Events;
using MarketPlace.Domain.Users.ValueObjects;

namespace MarketPlace.Domain.Users
{
    public class User : Entity<UserId>
    {

        private User()
        {
        }

        private User(UserId userId, FirstName firstName, LastName lastName, Email email, MobileNumber mobileNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            MobileNumber = mobileNumber;
        }

        public FirstName FirstName { get; private set; }
        public LastName LastName { get; private set; }
        public Email Email { get; private set; }
        public MobileNumber MobileNumber { get; private set; }
        public string Identity { get; set; } = string.Empty;

        public static User Create(FirstName firstName,
            LastName lastName,
            Email email,
            MobileNumber mobileNumber)
        {

            var user = new User(UserId.New(), firstName, lastName, email, mobileNumber);
            user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id));
            return user;
        }

        public void SetIdentityId(string identityId)
        {
            Identity = identityId;
        }
    }
}
