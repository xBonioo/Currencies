using Currencies.Contracts.ModelDtos.Role;
using Currencies.Contracts.ModelDtos.User.CurrencyAmount;
using MediatR;

namespace Currencies.Api.Functions.UserCurrencyAmount.Commands.Create;

public class CreateUserCurrencyAmountCommand : IRequest<UserCurrencyAmountDto>
{
    public int Id { get; set; }
    public BaseUserCurrencyAmountDto Data { get; set; } = null!;

    public CreateUserCurrencyAmountCommand(int id, BaseUserCurrencyAmountDto dto)
    {
        Id = id;
        Data = dto;
    }
}
