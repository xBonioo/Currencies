using Currencies.Api.Functions.Currency.Commands.Update;
using Currencies.Models;
using FluentValidation;

namespace Currencies.Api.Validators.Currency;

public class UpdateExchangeRateCommandValidator : AbstractValidator<UpdateCurrencyCommand>
{
    public UpdateExchangeRateCommandValidator(TableContext dbContext)
    {
        RuleFor(x => x.Dto.Name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(64)
            .Custom((value, context) =>
            {
                var editedCurrency = context.InstanceToValidate;
                var isNameAlreadyTaken = dbContext.Currencies.Any(p => p.Name == value && p.Id != editedCurrency.Id);
                if (isNameAlreadyTaken)
                {
                    context.AddFailure("Name", "This currency's name has been already taken");
                }
            });


        RuleFor(x => x.Dto.Symbol)
            .NotNull()
            .NotEmpty()
            .MaximumLength(3)
            .Custom((value, context) =>
            {
                var editedCurrency = context.InstanceToValidate;
                var isAliasAlreadyTaken = dbContext.Currencies.Any(p => p.Symbol == value && p.Id != editedCurrency.Id);
                if (isAliasAlreadyTaken)
                {
                    context.AddFailure("Symbol", "This currency's symbol has been already taken");
                }
            });

        RuleFor(x => x.Dto.IsActive)
            .NotNull()
            .NotEmpty();
    }
}