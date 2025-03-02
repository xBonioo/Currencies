using Currencies.Api.Modules.User.Commands.Register;
using FluentValidation;

namespace Currencies.Api.Validators.Account;

public class RegisterAccountCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterAccountCommandValidator(RegisterAccountDtoValidator validator)
    {
        RuleFor(x => x.RegisterUserDto).SetValidator(validator);
    }
}