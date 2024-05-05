using Currencies.Contracts.ModelDtos.Role;
using Currencies.Contracts.ModelDtos.User.CurrencyAmount;
using MediatR;

namespace Currencies.Api.Functions.UserCurrencyAmount.Commands.Create;

public class CreateUserCurrencyAmountCommand : IRequest<UserCurrencyAmountDto>
{
    public BaseUserCurrencyAmountDto Data { get; set; } = null!;

    public CreateUserCurrencyAmountCommand(BaseUserCurrencyAmountDto dto)
    {
        Data = dto;
    }
}
