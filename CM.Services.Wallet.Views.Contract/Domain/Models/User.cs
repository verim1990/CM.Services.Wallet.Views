using CM.Services.Wallet.Contract.Application.Events.Integration;
using CM.Shared.Kernel.Application.Base;

namespace CM.Services.Wallet.Views.Contract.Domain.Models
{
    public class User : AggregateRoot
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public User()
        {
            Register<UserCreatedIntegrationEvent>(When);
            Register<UserUpdatedIntegrationEvent>(When);
        }

        public static User Create(string username, string email)
        {
            return new User()
            {
                Username = username,
                Email = email
            };
        }

        protected void When(UserCreatedIntegrationEvent @event)
        {
            Id = @event.AggregateRootId;
        }

        protected void When(UserUpdatedIntegrationEvent @event)
        {
            Username = @event.Username;
            Email = @event.Email;
        }
    }
}
