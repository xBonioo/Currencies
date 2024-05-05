using Currencies.Contracts.ModelDtos.User.ExchangeHistory;
using MediatR;

namespace Currencies.Api.Functions.UserCurrencyAmount.Commands.Create;

public class AddUserExchangeHistoryCommand : IRequest<bool>
{
    public UserExchangeHistoryDto Data { get; set; } = null!;

    public AddUserExchangeHistoryCommand(UserExchangeHistoryDto dto)
    {
        Data = dto;
    }
}
