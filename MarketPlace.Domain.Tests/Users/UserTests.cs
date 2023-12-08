using FluentAssertions;
using MarketPlace.Domain.Users;
using MarketPlace.Domain.Users.Events;
using MarketPlace.Domain.Users.ValueObjects;

namespace MarketPlace.Domain.Tests.Users
{
    public class UserTests : BaseTest
    {

        [Fact]
        public void Create_Should_RaiseUserCreatedDomainEvents_WhenSuccess()
        {
            var firstName = new FirstName("First");
            var lastName = new LastName("Last");
            var email = new Email("test@gmail.com");
            var mobileNumber = new MobileNumber("09123456712");

            var result = User.Create(firstName, lastName, email, mobileNumber);
            var user = result;

            var userCreatedDomainEvent = AssertDomainEventWasPublished<UserCreatedDomainEvent>(user);
            userCreatedDomainEvent.UserId.Should().Be(result.Id);

        }
    }
}
