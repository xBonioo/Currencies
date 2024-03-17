using Currencies.Api.Functions.Currency.Commands.Update;
using FluentValidation;

namespace Currencies.Api.Validators.Currency;

public class UpdateCurrencyCommandValidator : AbstractValidator<UpdateCurrencyCommand>
{
    public UpdateCurrencyCommandValidator(CurrencyDtoValidator currencyValidator)
    {
        RuleFor(x => x.Dto).SetValidator(currencyValidator);
    }
}