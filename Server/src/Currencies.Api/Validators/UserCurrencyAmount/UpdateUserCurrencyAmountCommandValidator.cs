using Currencies.Api.Functions.UserCurrencyAmount.Commands.Update;
using Currencies.Models;
using FluentValidation;

namespace Currencies.Api.Validators.UserCurrencyAmount;

public class UpdateUserCurrencyAmountCommandValidator : AbstractValidator<UpdateUserCurrencyAmountCommand>
{
    public UpdateUserCurrencyAmountCommandValidator(TableContext dbContext)
    {
        RuleFor(x => x.Dto.UserId)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.Dto.CurrencyId)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.Dto.Amount)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.Dto.IsActive)
            .NotNull()
            .NotEmpty();
    }
}
