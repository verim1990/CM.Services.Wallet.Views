using CM.Services.Wallet.Views.Contract.Application.Queries;
using FluentValidation;

namespace CM.Services.Wallet.Views.Concrete.Application.Validators
{
    public class GetUserQueryValidator : AbstractValidator<GetUserQuery>
    {
        public GetUserQueryValidator()
        {
            RuleFor(cmd => cmd.Id)
                .NotEmpty();
        }
    }
}
