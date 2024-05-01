using Currencies.Contracts.Interfaces;
using Currencies.Models.Entities;
using MediatR;

namespace Currencies.Api.Functions.ExchangeRate.Commands.Delete;

public class DeleteExchangeRateCommandHandler : IRequestHandler<DeleteExchangeRateCommand, bool>
{
    private readonly IExchangeRateService _exchangeRateService;

    public DeleteExchangeRateCommandHandler(IExchangeRateService exchangeRateService)
    {
        _exchangeRateService = exchangeRateService;
    }

    public async Task<bool> Handle(DeleteExchangeRateCommand request, CancellationToken cancellationToken)
    {
        return await _exchangeRateService.DeleteAsync(request.Id, cancellationToken);
    }
}