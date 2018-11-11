using CM.Services.Wallet.Contract.Application.Events.Integration;
using CM.Services.Wallet.Views.Contract.Domain.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CM.Services.Wallet.Views.Concrete.Application.EventListeners.Integration
{
    public class UserUpdatedIntegrationEventHandler : IRequestHandler<UserUpdatedIntegrationEvent>
    {
        public IUserService UserService { get; set; }

        public UserUpdatedIntegrationEventHandler(IUserService userService)
        {
            UserService = userService;
        }

        public async Task<Unit> Handle(UserUpdatedIntegrationEvent integrationEvent, CancellationToken cancellationToken)
        {
            var user = await UserService.GetUser(integrationEvent.AggregateRootId, cancellationToken);

            user.Apply(integrationEvent);

            await UserService.SaveUser(user, cancellationToken);

            return Unit.Value;
        }
    }
}