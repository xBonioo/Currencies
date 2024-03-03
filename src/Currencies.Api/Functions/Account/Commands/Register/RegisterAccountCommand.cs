using MediatR;
using Currencies.Contracts.ModelDtos.Account;

namespace Currencies.Api.Functions.Account.Commands.Register;

public class RegisterAccountCommand : IRequest<AccountDto>
{
    public RegisterUserDto RegisterUserDto { get; set; } = null!;
}