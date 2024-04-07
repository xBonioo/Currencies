using Currencies.Api.Functions.Role.Commands.Update;
using Currencies.Models;
using FluentValidation;

namespace Currencies.Api.Validators.Role;

public class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
{
    public UpdateRoleCommandValidator(TableContext dbContext)
    {
        RuleFor(x => x.Dto.Name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(64)
            .Custom((value, context) =>
            {
                var editedRole = context.InstanceToValidate;
                var isNameAlreadyTaken = dbContext.Currencies.Any(p => p.Name == value && p.Id != editedRole.Id);
                if (isNameAlreadyTaken)
                {
                    context.AddFailure("Name", "This role's name has been already taken");
                }
            });

        RuleFor(x => x.Dto.IsActive)
            .NotNull()
            .NotEmpty();
    }
}