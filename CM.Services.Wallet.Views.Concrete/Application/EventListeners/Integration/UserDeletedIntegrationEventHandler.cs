using CM.Services.Wallet.Contract.Application.Events.Integration;
using CM.Services.Wallet.Views.Contract.Domain.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CM.Services.Wallet.Views.Concrete.Application.EventListeners.Integration
{
    public class UserDeletedIntegrationEventHandler : IRequestHandler<UserDeletedIntegrationEvent>
    {
        private readonly IUserService UserService;

        public UserDeletedIntegrationEventHandler(IUserService userService)
        {
            UserService = userService;
        }

        public async Task<Unit> Handle(UserDeletedIntegrationEvent integrationEvent, CancellationToken cancellationToken)
        {
            var user = await UserService.GetUser(integrationEvent.AggregateRootId, cancellationToken);

            await UserService.DeleteUser(user, cancellationToken);

            return Unit.Value;
        }
    }
}