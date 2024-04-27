using Currencies.Api.Functions.Currency.Commands.Update;
using Currencies.Models;
using FluentValidation;

namespace Currencies.Api.Validators.ExchangeRate;

public class UpdateExchangeRateCommandValidator : AbstractValidator<UpdateCurrencyCommand>
{
    public UpdateExchangeRateCommandValidator(TableContext dbContext)
    {
        RuleFor(x => x.Dto.FromCurrencyID)
            .NotNull()
            .NotEmpty()
            .MaximumLength(15)
            .Custom((value, context) =>
            {
                var editedExchangeRate = context.InstanceToValidate;
                var isFromCurrencyIDAlreadyTaken = dbContext.ExchangeRate.Any(p => p.FromCurrencyID == value && p.Id != editedExchangeRate.Id);
                if (isFromCurrencyIDAlreadyTaken)
                {
                    context.AddFailure("FromCurrencyID", "This ExchangeRate's ID has been already taken");
                }
            });


        RuleFor(x => x.Dto.ToCurrencyID)
            .NotNull()
            .NotEmpty()
            .MaximumLength(15)
            .Custom((value, context) =>
            {
                var editedExchangeRate = context.InstanceToValidate;
                var isToCurrencyIDAlreadyTaken = dbContext.ExchangeRate.Any(p => p.ToCurrencyID == value && p.Id != editedExchangeRate.Id);
                if (isToCurrencyIDAlreadyTaken)
                {
                    context.AddFailure("ToCurrencyID", "This ExchangeRate's ID has been already taken");
                }
            });

            RuleFor(x => x.Dto.Rate)
            .NotNull()
            .NotEmpty()
            .MaximumLength(24)
            .Custom((value, context) =>
            {
                var editedExchangeRate = context.InstanceToValidate;
                var isRateAlreadyTaken = dbContext.ExchangeRate.Any(p => p.Rate == value && p.Id != editedExchangeRate.Id);
                if (isRateAlreadyTaken)
                {
                    context.AddFailure("Rate", "This exchenage rate's ID has been already taken");
                }
            });

          RuleFor(x => x.Dto.Direction)
         .NotNull()
         .NotEmpty();

        RuleFor(x => x.Dto.IsActive)
            .NotNull()
            .NotEmpty();
    }
}