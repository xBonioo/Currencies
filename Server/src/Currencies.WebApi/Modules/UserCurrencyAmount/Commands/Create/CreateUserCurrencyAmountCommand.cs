using Currencies.Contracts.ModelDtos.User.CurrencyAmount;
using MediatR;

namespace Currencies.Api.Modules.UserCurrencyAmount.Commands.Create;

public class CreateUserCurrencyAmountCommand : IRequest<UserCurrencyAmountDto>
{
    public BaseUserCurrencyAmountDto Data { get; set; } = null!;

    public CreateUserCurrencyAmountCommand(BaseUserCurrencyAmountDto dto)
    {
        Data = dto;
    }
}
