using Currencies.Contracts.ModelDtos.Currency;
using Currencies.Models;
using FluentValidation;

namespace Currencies.Api.Validators.Currency;

public class CurrencyDtoValidator : AbstractValidator<BaseCurrencyDto>
{
    private readonly TableContext _dbContext;

    public CurrencyDtoValidator(TableContext dbContext)
    {
        _dbContext = dbContext;

        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(1024)
            .Custom((value, context) =>
            {
                var isNameAlreadyTaken = dbContext.Currencies.Any(p => p.Name == value);
                if (isNameAlreadyTaken)
                {
                    context.AddFailure("Name", "This currency's name has been already taken");
                }
            });


        RuleFor(x => x.Symbol)
            .NotNull()
            .NotEmpty()
            .MaximumLength(3)
            .Custom((value, context) =>
            {
                var isAliasAlreadyTaken = dbContext.Currencies.Any(p => p.Symbol == value);
                if (isAliasAlreadyTaken)
                {
                    context.AddFailure("Symbol", "This currency's symbol has been already taken");
                }
            });

        RuleFor(x => x.IsActive)
            .NotNull()
            .NotEmpty();
    }
}