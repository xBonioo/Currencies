using Currencies.Contracts.ModelDtos.User.CurrencyAmount;
using MediatR;

namespace Currencies.Api.Functions.UserCurrencyAmount.Commands.Delete;

public class ConvertUserCurrencyAmountCommand : IRequest<UserCurrencyAmountDto>
{
    public ConvertUserCurrencyAmountDto Data { get; set; } = null!;

    public ConvertUserCurrencyAmountCommand(ConvertUserCurrencyAmountDto dto)
    {
        Data = dto;
    }
}
