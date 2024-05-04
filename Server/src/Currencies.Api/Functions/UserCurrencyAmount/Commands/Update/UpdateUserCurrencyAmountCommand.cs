using Currencies.Contracts.ModelDtos.Role;
using Currencies.Contracts.ModelDtos.User.CurrencyAmount;
using MediatR;

namespace Currencies.Api.Functions.Role.Commands.Update;

public class UpdateUserCurrencyAmountCommand : IRequest<UserCurrencyAmountDto>
{
    public int Id { get; set; }
    public BaseUserCurrencyAmountDto Dto { get; set; }

    public UpdateUserCurrencyAmountCommand(int id, BaseUserCurrencyAmountDto dto)
    {
        Id = id;
        Dto = dto;
    }
}
