using Currencies.Contracts.Interfaces;
using MediatR;

namespace Currencies.Api.Functions.Currency.Commands.Delete;

public class DeleteCurrencyCommandHandler : IRequestHandler<DeleteCurrencyCommand, bool>
{
    private readonly ICurrencyService _currencyService;

    public DeleteCurrencyCommandHandler(ICurrencyService currencyService)
    {
        _currencyService = currencyService;
    }

    public async Task<bool> Handle(DeleteCurrencyCommand request, CancellationToken cancellationToken)
    {
        return await _currencyService.DeleteCurrencyAsync(request.Id, cancellationToken);
    }
}