using Currencies.Contracts.Interfaces;
using Currencies.Contracts.ModelDtos.User.CurrencyAmount;
using MediatR;

namespace Currencies.Api.Functions.UserCurrencyAmount.Commands.Create;

public class AddUserExchangeHistoryCommandHandler : IRequestHandler<AddUserExchangeHistoryCommand, bool>
{
    private readonly IUserExchangeHistoryService _userExchangeHistoryService;

    public AddUserExchangeHistoryCommandHandler(IUserExchangeHistoryService userExchangeHistoryService)
    {
        _userExchangeHistoryService = userExchangeHistoryService;
    }

    public async Task<bool> Handle(AddUserExchangeHistoryCommand request, CancellationToken cancellationToken)
    {
        return await _userExchangeHistoryService.AddUserExchangeHistoryAsync(request.Data, cancellationToken);
    }
}
