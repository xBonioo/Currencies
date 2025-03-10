﻿using AutoMapper;
using Currencies.Contracts.Interfaces;
using Currencies.Contracts.ModelDtos.User.CurrencyAmount;
using MediatR;

namespace Currencies.Api.Modules.UserCurrencyAmount.Queries.GetSingle;

public class GetSinglUserCurrencyAmountQueryHandler : IRequestHandler<GetSingleUserCurrencyAmountQuery, List<UserCurrencyAmountDto>>
{
    private readonly IUserCurrencyAmountService _userCurrencyAmountService;
    private readonly IMapper _mapper;

    public GetSinglUserCurrencyAmountQueryHandler(IUserCurrencyAmountService userCurrencyAmountService, IMapper mapper)
    {
        _userCurrencyAmountService = userCurrencyAmountService;
        _mapper = mapper;
    }

    public async Task<List<UserCurrencyAmountDto>> Handle(GetSingleUserCurrencyAmountQuery request, CancellationToken cancellationToken)
    {
        var result = await _userCurrencyAmountService.GetByUserIdAsync(request.Id, cancellationToken);
        if (result == null)
        {
            return null;
        }

        return _mapper.Map<List<UserCurrencyAmountDto>>(result);
    }
}
