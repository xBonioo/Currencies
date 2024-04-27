using Currencies.Contracts.Interfaces;
using Currencies.Contracts.ModelDtos.ExchangeRate;
using Currencies.Contracts.ModelDtos.Role;
using Currencies.DataAccess.Services;
using MediatR;

namespace Currencies.Api.Functions.ExchangeRate.Commands.Update;

public class UpdateExchangeRateCommandHandler : IRequestHandler<UpdateExchangeRateCommand, ExchangeRateDto>
{
    private readonly IExchangeRateService _exchangeRateService;

    public UpdateExchangeRateCommandHandler(IExchangeRateService exchangeRateService)
    {
        _exchangeRateService = exchangeRateService;
    }

    public async Task<ExchangeRateDto?> Handle(UpdateExchangeRateCommand request, CancellationToken cancellationToken)
    {
        return await _exchangeRateService.UpdateAsync(request.Id, request.Dto, cancellationToken);
    }
}