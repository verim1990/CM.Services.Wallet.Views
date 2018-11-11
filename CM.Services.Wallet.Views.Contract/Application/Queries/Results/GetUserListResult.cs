using CM.Services.Wallet.Views.Contract.Presentation.ViewModels;
using CM.Shared.Kernel.Application.Bus.Models;
using System.Collections.Generic;

namespace CM.Services.Wallet.Views.Contract.Application.Queries.Results
{
    public class GetUserListResult : QueryResult
    {
        public IEnumerable<UserViewModel> Items { get; set; }

        public long Total { get; set; }
    }
}