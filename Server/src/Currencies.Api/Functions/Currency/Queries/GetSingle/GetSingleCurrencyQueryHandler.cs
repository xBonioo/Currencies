using AutoMapper;
using Currencies.Contracts.Interfaces;
using Currencies.Contracts.ModelDtos.Currency;
using Currencies.DataAccess.Services;
using MediatR;

namespace Currencies.Api.Functions.Currency.Queries.GetSingle;

public class GetSingleCurrencyQueryHandler : IRequestHandler<GetSingleCurrencyQuery, CurrencyDto?>
{
    private readonly ICurrencyService _currencyService;
    private readonly IMapper _mapper;

    public GetSingleCurrencyQueryHandler(ICurrencyService currencyService, IMapper mapper)
    {
        _currencyService = currencyService;
        _mapper = mapper;
    }

    public async Task<CurrencyDto?> Handle(GetSingleCurrencyQuery request, CancellationToken cancellationToken)
    {
        var result = await _currencyService.GetByIdAsync(request.id, cancellationToken);
        if (result == null || !result.IsActive)
        {
            return null;
        }

        return _mapper.Map<CurrencyDto>(result);
    }
}