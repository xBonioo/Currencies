using Currencies.Api.Functions.User.Commands.Register;
using FluentValidation;

namespace Currencies.Api.Validators.User;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator(RegisterUserDtoValidator validator)
    {
        RuleFor(x => x.RegisterUserDto).SetValidator(validator);
    }
}