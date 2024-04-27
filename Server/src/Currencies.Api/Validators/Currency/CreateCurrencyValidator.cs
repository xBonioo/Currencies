using Currencies.Api.Functions.Currency.Commands.Create;
using Currencies.Api.Validators.Currency;
using FluentValidation;

namespace Currencies.Api.Validators.Currency;

public class CreateCurrencyValidator : AbstractValidator<CreateCurrencyCommand>
{
    public CreateCurrencyValidator(ExchangeRateDtoValidator currencyValidator)
    {
        RuleFor(x => x.Data).SetValidator(currencyValidator);
    }
}