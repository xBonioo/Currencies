using Currencies.Contracts.ModelDtos.User.CurrencyAmount;
using Currencies.Models;
using FluentValidation;

namespace Currencies.Api.Validators.UserCurrencyAmounts;

public class UserCurrencyAmountDtoValidator : AbstractValidator<BaseUserCurrencyAmountDto>
{
    public UserCurrencyAmountDtoValidator(TableContext dbContext)
    {
        RuleFor(x => x.UserId)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.CurrencyId)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.Amount)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.IsActive)
            .NotNull()
            .NotEmpty();
    }
}
