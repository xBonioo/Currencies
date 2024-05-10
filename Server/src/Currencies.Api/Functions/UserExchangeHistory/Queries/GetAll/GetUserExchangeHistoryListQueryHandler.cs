using Currencies.Contracts.Interfaces;
using Currencies.Contracts.ModelDtos.User.ExchangeHistory;
using Currencies.Contracts.Response;
using MediatR;

namespace Currencies.Api.Functions.UserExchangeHistory.Queries.GetAll;

public class GetUserExchangeHistoryListQueryHandler : IRequestHandler<GetUserExchangeHistoryListQuery, PageResult<UserExchangeHistoryDto>?>
{
    private readonly IUserExchangeHistoryService _userExchangeHistoryService;

    public GetUserExchangeHistoryListQueryHandler(IUserExchangeHistoryService userExchangeHistoryService)
    {
        _userExchangeHistoryService = userExchangeHistoryService;
    }

    public async Task<PageResult<UserExchangeHistoryDto>?> Handle(GetUserExchangeHistoryListQuery request, CancellationToken cancellationToken)
    {
        return await _userExchangeHistoryService.GetAllUserExchangeHistoryServiceiesAsync(request.Filter, cancellationToken);
    }
}