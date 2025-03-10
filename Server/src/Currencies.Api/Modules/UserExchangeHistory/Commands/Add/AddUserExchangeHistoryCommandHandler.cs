﻿using Currencies.Contracts.Interfaces;
using MediatR;

namespace Currencies.Api.Modules.UserExchangeHistory.Commands.Add;

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
