using Currencies.Contracts.Interfaces;
using Currencies.Contracts.ModelDtos.Currency;
using MediatR;

namespace Currencies.Api.Functions.Currency.Commands.Create;

public class CreateCurrencyCommandHandler : IRequestHandler<CreateCurrencyCommand, CurrencyDto?>
{
    private readonly ICurrencyService _currencyService;

    public CreateCurrencyCommandHandler(ICurrencyService currencyService)
    {
        _currencyService = currencyService;
    }

    public async Task<CurrencyDto?> Handle(CreateCurrencyCommand request, CancellationToken cancellationToken)
    {
        return await _currencyService.CreateCurrencyAsync(request.Data, cancellationToken);
    }
}