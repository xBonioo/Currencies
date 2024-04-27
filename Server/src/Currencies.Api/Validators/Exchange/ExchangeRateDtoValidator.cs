using Currencies.Contracts.ModelDtos.Currency;
using Currencies.Contracts.ModelDtos.ExchangeRate;
using Currencies.Models;
using FluentValidation;

namespace Currencies.Api.Validators.ExchangeRate;

public class ExchangeRateDtoValidator : AbstractValidator<BaseExchangeRateDto>
{
    public ExchangeRateDtoValidator(TableContext dbContext)
    {
        RuleFor(x => x.FromCurrencyID)
            .NotNull()
            .NotEmpty()
            .MaximumLength(15)
            .Custom((value, context) =>
            {
                var isFromCurrencyIDAlreadyTaken = dbContext.ExchangeRate.Any(p => p.FromCurrencyID == value);
                if (isFromCurrencyIDAlreadyTaken)
                {
                    context.AddFailure("FromCurrencyID", "This exchenage rate's ID has been already taken");
                }
            });


        RuleFor(x => x.ToCurrencyID)
            .NotNull()
            .NotEmpty()
            .MaximumLength(15)
            .Custom((value, context) =>
            {
                var isToCurrencyIDAlreadyTaken = dbContext.ExchangeRate.Any(p => p.ToCurrencyID == value);
                if (isToCurrencyIDAlreadyTaken)
                {
                    context.AddFailure("ToCurrencyID", "This exchenage rate's ID has been already taken");
                }
            });

        RuleFor(x => x.Rate)
            .NotNull()
            .NotEmpty()
            .MaximumLength(24)
            .Custom((value, context) =>
            {
                var isRateAlreadyTaken = dbContext.ExchangeRate.Any(p => p.Rate == value);
                if (isRateAlreadyTaken)
                {
                    context.AddFailure("Rate", "This exchenage rate's ID has been already taken");
                }
            });

        RuleFor(x => x.IsActive)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.Direction)
        .NotNull()
        .NotEmpty();
    }
}