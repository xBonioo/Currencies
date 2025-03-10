﻿using Currencies.Contracts.Interfaces;
using Currencies.Contracts.ModelDtos.Currency;
using MediatR;

namespace Currencies.Api.Modules.Currency.Commands.Update;

public class UpdateCurrencyCommandHandler : IRequestHandler<UpdateCurrencyCommand, CurrencyDto>
{
    private readonly ICurrencyService _currencyService;

    public UpdateCurrencyCommandHandler(ICurrencyService currencyService)
    {
        _currencyService = currencyService;
    }

    public async Task<CurrencyDto?> Handle(UpdateCurrencyCommand request, CancellationToken cancellationToken)
    {
        return await _currencyService.UpdateAsync(request.Id, request.Dto, cancellationToken);
    }
}