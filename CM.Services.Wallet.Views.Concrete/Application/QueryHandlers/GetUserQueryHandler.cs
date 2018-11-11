using CM.Services.Wallet.Views.Concrete.Presentation.Mappers;
using CM.Services.Wallet.Views.Contract.Application.Queries;
using CM.Services.Wallet.Views.Contract.Application.Queries.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using CM.Services.Wallet.Views.Contract.Domain.Services;

namespace CM.Services.Wallet.Views.Concrete.Application.QueryHandlers
{
    public class GetUserListHandler : IRequestHandler<GetUserQuery, GetUserResult>
    {
        private readonly IUserService userService;
        private readonly UserMapper userMapper;

        public GetUserListHandler(
            IUserService userService,
            UserMapper userMapper
        )
        {
            this.userService = userService;
            this.userMapper = userMapper;
        }

        public async Task<GetUserResult> Handle(GetUserQuery query, CancellationToken token)
        {
            var user = await userService.GetUser(query.Id, token);
            var viewModel = userMapper.ToDto(user);

            return new GetUserResult()
            {
                User = viewModel
            };
        }
    }
}