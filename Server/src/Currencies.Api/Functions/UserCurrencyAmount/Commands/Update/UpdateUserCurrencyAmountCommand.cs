using Currencies.Contracts.ModelDtos.User.CurrencyAmount;
using MediatR;

namespace Currencies.Api.Functions.UserCurrencyAmount.Commands.Update;

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
