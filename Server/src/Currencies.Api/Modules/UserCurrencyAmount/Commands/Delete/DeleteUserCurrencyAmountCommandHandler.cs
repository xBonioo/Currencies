﻿using Currencies.Contracts.Interfaces;
using MediatR;

namespace Currencies.Api.Modules.UserCurrencyAmount.Commands.Delete;

public class DeleteUserCurrencyAmountCommandHandler : IRequestHandler<DeleteUserCurrencyAmountCommand, bool>
{
    private readonly IUserCurrencyAmountService _userCurrencyAmountService;

    public DeleteUserCurrencyAmountCommandHandler(IUserCurrencyAmountService userCurrencyAmountService)
    {
        _userCurrencyAmountService = userCurrencyAmountService;
    }

    public async Task<bool> Handle(DeleteUserCurrencyAmountCommand request, CancellationToken cancellationToken)
    {
        return await _userCurrencyAmountService.DeleteAsync(request.Id, cancellationToken);
    }
}
