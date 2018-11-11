using CM.Services.Wallet.Views.Contract.Application.Queries;
using CM.Services.Wallet.Views.Contract.Domain.Models;
using CM.Services.Wallet.Views.Contract.Domain.Services;
using CM.Services.Wallet.Views.Infrastracture.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CM.Services.Wallet.Views.Concrete.Domain.Services
{
    public class UserService: IUserService
    {
        private readonly UserRepository userRepository;

        public UserService(
            UserRepository userRepository
        )
        {
            this.userRepository = userRepository;
        }

        public async Task<User> GetUser(Guid id, CancellationToken token)
        {
            return await userRepository.GetAsync(id);
        }

        public async Task<Tuple<IEnumerable<User>, long>> GetUsers(GetUserListQuery query, CancellationToken token)
        {
            var entities = await userRepository.GetAllAsync();
            var total = entities.Count();

            return new Tuple<IEnumerable<User>, long>(await entities.ToAsyncEnumerable().ToList(), total);
        }

        public async Task SaveUser(User user, CancellationToken token)
        {
            await userRepository.InsertAsync(user);
        }

        public async Task DeleteUser(User user, CancellationToken token)
        {
            await userRepository.DeleteAsync(user);
        }
    }
}