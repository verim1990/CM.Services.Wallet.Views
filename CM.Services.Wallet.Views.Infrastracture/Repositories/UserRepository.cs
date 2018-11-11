using CM.Services.Wallet.Views.Contract.Domain.Models;
using CM.Shared.Kernel.Others.Redis;
using StackExchange.Redis;

namespace CM.Services.Wallet.Views.Infrastracture.Repositories
{
    public class UserRepository : RedisRepository<User>
    {
        public UserRepository(RedisConnector redisConnector) : base(redisConnector) {
        }
    }
}
