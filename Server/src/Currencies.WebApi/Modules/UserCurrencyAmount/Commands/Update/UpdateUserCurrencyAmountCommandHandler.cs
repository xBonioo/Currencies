using Currencies.Contracts.Interfaces;
using Currencies.Contracts.ModelDtos.User.CurrencyAmount;
using MediatR;

namespace Currencies.Api.Modules.UserCurrencyAmount.Commands.Update;

public class UpdateUserCurrencyAmountCommandHandler : IRequestHandler<UpdateUserCurrencyAmountCommand, UserCurrencyAmountDto>
{
    private readonly IUserCurrencyAmountService _userCurrencyAmountService;

    public UpdateUserCurrencyAmountCommandHandler(IUserCurrencyAmountService userCurrencyAmountService)
    {
        _userCurrencyAmountService = userCurrencyAmountService;
    }

    public async Task<UserCurrencyAmountDto?> Handle(UpdateUserCurrencyAmountCommand request, CancellationToken cancellationToken)
    {
        return await _userCurrencyAmountService.UpdateAsync(request.Id, request.Dto, cancellationToken);
    }
}
