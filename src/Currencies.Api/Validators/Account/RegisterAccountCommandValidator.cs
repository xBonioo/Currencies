using Currencies.Api.Functions.Account.Commands.Register;
using FluentValidation;

namespace Currencies.Api.Validators.Account;

public class RegisterAccountCommandValidator : AbstractValidator<RegisterAccountCommand>
{
    public RegisterAccountCommandValidator(RegisterAccountDtoValidator validator)
    {
        RuleFor(x => x.RegisterUserDto).SetValidator(validator);
    }
}