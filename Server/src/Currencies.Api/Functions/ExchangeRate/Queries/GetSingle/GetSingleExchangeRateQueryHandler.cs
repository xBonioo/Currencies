using AutoMapper;
using Currencies.Contracts.Interfaces;
using Currencies.Contracts.ModelDtos.ExchangeRate;
using Currencies.Contracts.ModelDtos.Role;
using Currencies.DataAccess.Services;
using MediatR;

namespace Currencies.Api.Functions.ExchangeRate.Queries.GetSingle;

public class GetSinglExchangeRateQueryHandler : IRequestHandler<GetSingleExchangeRateQuery, ExchangeRateDto?>
{
    private readonly IExchangeRateService _exchangeRateService;
    private readonly IMapper _mapper;

    public GetSinglExchangeRateQueryHandler(IExchangeRateService exchangeRateService, IMapper mapper)
    {
        _exchangeRateService = exchangeRateService;
        _mapper = mapper;
    }

    public async Task<ExchangeRateDto?> Handle(GetSingleExchangeRateQuery request, CancellationToken cancellationToken)
    {
        var result = await _exchangeRateService.GetByIdAsync(request.id, cancellationToken);
        if (result == null || !result.IsActive)
        {
            return null;
        }

        return _mapper.Map<ExchangeRateDto>(result);
    }
}