using CM.Services.Wallet.Views.Contract.Application.Queries.Results;
using CM.Shared.Kernel.Application.Bus.Models;
using System;

namespace CM.Services.Wallet.Views.Contract.Application.Queries
{
    public class GetUserQuery : Query<GetUserResult>
    {
        public Guid Id { get; set; }
    }
}