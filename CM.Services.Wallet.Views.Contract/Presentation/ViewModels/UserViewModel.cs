using CM.Shared.Kernel.Application.Base;
using System;

namespace CM.Services.Wallet.Views.Contract.Presentation.ViewModels
{
    public class UserViewModel : IDto
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }
    }
}
