using Currencies.Api.Modules.ExchangeRate.Commands.Update;
using Currencies.Models;
using FluentValidation;

namespace Currencies.Api.Validators.ExchangeRate;

public class UpdateExchangeRateCommandValidator : AbstractValidator<UpdateExchangeRateCommand>
{
    public UpdateExchangeRateCommandValidator(TableContext dbContext)
    {
        RuleFor(x => x.Dto.FromCurrencyId)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.Dto.ToCurrencyId)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.Dto.Rate)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.Dto.Direction)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.Dto.IsActive)
            .NotNull()
            .NotEmpty();
    }
}