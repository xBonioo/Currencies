using Currencies.Api.Functions.Role.Commands.Create;
using FluentValidation;

namespace Currencies.Api.Validators.Role;

public class CreateRoleValidator : AbstractValidator<CreateRoleCommand>
{
    public CreateRoleValidator(RoleDtoValidator roleValidator)
    {
        RuleFor(x => x.Data).SetValidator(roleValidator);
    }
}