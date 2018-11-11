using CM.Services.Wallet.Views.Contract.Presentation.ViewModels;
using CM.Shared.Kernel.Application.Bus.Models;

namespace CM.Services.Wallet.Views.Contract.Application.Queries.Results
{
    public class GetUserResult : QueryResult
    {
        public UserViewModel User { get; set; }
    }
}