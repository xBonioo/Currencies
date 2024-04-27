using Currencies.Api.Functions.Currency.Commands.Create;
using Currencies.Api.Functions.ExchangeRate.Commands.Create;
using Currencies.Api.Validators.Currency;
using FluentValidation;

namespace Currencies.Api.Validators.ExchangeRate;

public class CreateExchangeRateValidator : AbstractValidator<CreateExchangeRateCommand>
{
    public CreateExchangeRateValidator(ExchangeRateDtoValidator exchangeRateValidator)
    {
        RuleFor(x => x.Data).SetValidator(exchangeRateValidator);
    }
}