using CM.Services.Wallet.Views.Contract.Application.Queries;
using CM.Services.Wallet.Views.Contract.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CM.Services.Wallet.Views.Contract.Domain.Services
{
    public interface IUserService
    {
        Task<User> GetUser(Guid id, CancellationToken token);

        Task<Tuple<IEnumerable<User>, long>> GetUsers(GetUserListQuery query, CancellationToken token);

        Task SaveUser(User user, CancellationToken token);

        Task DeleteUser(User user, CancellationToken token);
    }
}