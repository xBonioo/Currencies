using AutoMapper;
using Currencies.Contracts.Interfaces;
using Currencies.Contracts.ModelDtos.User.CurrencyAmount;
using MediatR;

namespace Currencies.Api.Functions.UserCurrencyAmount.Queries.GetSingle;

public class GetSinglUserCurrencyAmountQueryHandler : IRequestHandler<GetSingleUserCurrencyAmountQuery, UserCurrencyAmountDto?>
{
    private readonly IUserCurrencyAmountService _userCurrencyAmountService;
    private readonly IMapper _mapper;

    public GetSinglUserCurrencyAmountQueryHandler(IUserCurrencyAmountService userCurrencyAmountService, IMapper mapper)
    {
        _userCurrencyAmountService = userCurrencyAmountService;
        _mapper = mapper;
    }

    public async Task<UserCurrencyAmountDto?> Handle(GetSingleUserCurrencyAmountQuery request, CancellationToken cancellationToken)
    {
        var result = await _userCurrencyAmountService.GetByIdAsync(request.Id, cancellationToken);
        if (result == null || !result.IsActive)
        {
            return null;
        }

        return _mapper.Map<UserCurrencyAmountDto>(result);
    }
}
