using CM.Services.Wallet.Views.Concrete.Presentation.Mappers;
using CM.Services.Wallet.Views.Contract.Application.Queries;
using CM.Services.Wallet.Views.Contract.Application.Queries.Results;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CM.Services.Wallet.Views.Contract.Domain.Services;

namespace CM.Services.Wallet.Views.Concrete.Application.QueryHandlers
{
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, GetUserListResult>
    {
        private readonly IUserService userService;
        private readonly UserMapper userMapper;

        public GetUserListQueryHandler(
            IUserService userService,
            UserMapper userMapper
        )
        {
            this.userService = userService;
            this.userMapper = userMapper;
        }

        public async Task<GetUserListResult> Handle(GetUserListQuery query, CancellationToken token)
        {
            var result = await userService.GetUsers(query, token);
            var viewModels = result.Item1.Select(user => userMapper.ToDto(user));

            return new GetUserListResult()
            {
                Items = viewModels,
                Total = result.Item2
            };
        }
    }
}