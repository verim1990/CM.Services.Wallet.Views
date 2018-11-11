using CM.Services.Wallet.Contract.Application.Events.Integration;
using CM.Services.Wallet.Views.Contract.Domain.Models;
using CM.Services.Wallet.Views.Contract.Domain.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CM.Services.Wallet.Views.Concrete.Application.EventListeners.Integration
{
    public class UserCreatedIntegrationEventHandler : IRequestHandler<UserCreatedIntegrationEvent>
    {
        public IUserService UserService { get; set; }

        public UserCreatedIntegrationEventHandler(IUserService userService)
        {
            UserService = userService;
        }

        public async Task<Unit> Handle(UserCreatedIntegrationEvent integrationEvent, CancellationToken cancellationToken)
        {
            var user = User.Create(integrationEvent.Username, integrationEvent.Email);

            user.Apply(integrationEvent);

            await UserService.SaveUser(user, cancellationToken);

            return Unit.Value;
        }
    }
}