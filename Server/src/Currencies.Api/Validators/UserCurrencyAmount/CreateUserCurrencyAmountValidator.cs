using Currencies.Api.Functions.Currency.Commands.Create;
using Currencies.Api.Functions.UserCurrencyAmount.Commands.Create;
using Currencies.Api.Validators.UserCurrencyAmount;
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
