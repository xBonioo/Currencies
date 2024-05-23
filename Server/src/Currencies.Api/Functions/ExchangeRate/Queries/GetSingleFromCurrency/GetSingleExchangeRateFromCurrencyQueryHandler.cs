using AutoMapper;
using Currencies.Contracts.Interfaces;
using Currencies.Contracts.ModelDtos.ExchangeRate;
using MediatR;

namespace Currencies.Api.Functions.ExchangeRate.Queries.GetSingleFromCurrency;

public class GetSingleExchangeRateFromCurrencyQueryHandler : IRequestHandler<GetSingleExchangeRateFromCurrencyQuery, ExchangeRateDto?>
{
    private readonly IExchangeRateService _exchangeRateService;
    private readonly IMapper _mapper;

    public GetSingleExchangeRateFromCurrencyQueryHandler(IExchangeRateService exchangeRateService, IMapper mapper)
    {
        _exchangeRateService = exchangeRateService;
        _mapper = mapper;
    }

    public async Task<ExchangeRateDto?> Handle(GetSingleExchangeRateFromCurrencyQuery request, CancellationToken cancellationToken)
    {
        var result = await _exchangeRateService.GetByIdFromCurrencyAsync(request.fromId, request.toId, cancellationToken);
        if (result == null || !result.IsActive)
        {
            return null;
        }

        return _mapper.Map<ExchangeRateDto>(result);
    }
}