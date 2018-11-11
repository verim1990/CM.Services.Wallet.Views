using CM.Services.Wallet.Views.Contract.Domain.Models;
using CM.Services.Wallet.Views.Contract.Presentation.ViewModels;
using CM.Shared.Kernel.Application.Interfaces;

namespace CM.Services.Wallet.Views.Concrete.Presentation.Mappers
{
    public class UserMapper : IMapper<User, UserViewModel>
    {
        public UserViewModel ToDto(User model, bool throwIfNull = true)
        {
            return new UserViewModel()
            {
                Id = model.Id,
                Username = model.Username,
                Email = model.Email
            };
        }
    }
}
