using Currencies.Api.Modules.ExchangeRate.Commands.Create;
using Currencies.Models;
using FluentValidation;

namespace Currencies.Api.Validators.ExchangeRate;

public class CreateExchangeRateValidator : AbstractValidator<CreateExchangeRateCommand>
{
    public CreateExchangeRateValidator(TableContext dbContext)
    {
        RuleFor(x => x.Date)
            .NotNull()
            .NotEmpty()
            .GreaterThanOrEqualTo(DateTime.Today.AddDays(-3)).WithMessage("Date cannot be in the past.")
            .LessThan(DateTime.Today.AddYears(1)).WithMessage("Date cannot be more than one year in the future.");
    }
}