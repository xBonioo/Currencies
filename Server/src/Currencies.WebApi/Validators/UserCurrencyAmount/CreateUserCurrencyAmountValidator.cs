using Currencies.Api.Modules.UserCurrencyAmount.Commands.Create;
using Currencies.Api.Validators.UserCurrencyAmounts;
using FluentValidation;

namespace Currencies.Api.Validators.UserCurrencyAmount;

public class CreateUserCurrencyAmountValidator : AbstractValidator<CreateUserCurrencyAmountCommand>
{
    public CreateUserCurrencyAmountValidator(UserCurrencyAmountDtoValidator usercurrencyamountValidator)
    {
        RuleFor(x => x.Data).SetValidator(usercurrencyamountValidator);
    }
}
