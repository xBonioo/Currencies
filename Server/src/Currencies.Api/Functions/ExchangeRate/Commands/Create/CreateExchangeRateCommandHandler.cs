using Currencies.Contracts.Interfaces;
using Currencies.Contracts.ModelDtos.ExchangeRate;
using Currencies.Contracts.ModelDtos.Role;
using Currencies.Models.Entities;
using MediatR;

namespace Currencies.Api.Functions.ExchangeRate.Commands.Create;

public class CreateExchangeRateCommandHandler : IRequestHandler<CreateExchangeRateCommand, ExchangeRateDto?>
{
    private readonly IExchangeRateService _exchangeRate;

    public CreateExchangeRateCommandHandler(IExchangeRateService exchangeRate)
    {
        _exchangeRate = exchangeRate;
    }

    public async Task<ExchangeRateDto?> Handle(CreateExchangeRateCommand request, CancellationToken cancellationToken)
    {
        return await _exchangeRate.CreateAsync(request.Data, cancellationToken);
    }
}