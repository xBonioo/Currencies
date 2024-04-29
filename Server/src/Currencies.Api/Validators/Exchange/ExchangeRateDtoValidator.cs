using Currencies.Contracts.ModelDtos.Currency;
using Currencies.Contracts.ModelDtos.ExchangeRate;
using Currencies.Models;
using FluentValidation;

namespace Currencies.Api.Validators.ExchangeRate;

public class ExchangeRateDtoValidator : AbstractValidator<BaseExchangeRateDto>
{
    public ExchangeRateDtoValidator(TableContext dbContext)
    {
        RuleFor(x => x.FromCurrencyId)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.ToCurrencyId)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.Rate)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.IsActive)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.Direction)
            .NotNull()
            .NotEmpty();
    }
}