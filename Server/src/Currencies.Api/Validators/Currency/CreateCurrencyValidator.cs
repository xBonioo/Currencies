using Currencies.Api.Functions.Currency.Commands.Create;
using FluentValidation;

namespace Currencies.Api.Validators.Currency;

public class CreateCurrencyValidator : AbstractValidator<CreateCurrencyCommand>
{
    public CreateCurrencyValidator(CurrencyDtoValidator currencyValidator)
    {
        RuleFor(x => x.Data).SetValidator(currencyValidator);
    }
}