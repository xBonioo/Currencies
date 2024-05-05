using Currencies.Contracts.Interfaces;
using Currencies.Contracts.ModelDtos.User.CurrencyAmount;
using MediatR;

namespace Currencies.Api.Functions.UserCurrencyAmount.Commands.Create;

public class CreateUserCurrencyAmountCommandHandler : IRequestHandler<CreateUserCurrencyAmountCommand, UserCurrencyAmountDto?>
{
    private readonly IUserCurrencyAmountService _userCurrencyAmountService;

    public CreateUserCurrencyAmountCommandHandler(IUserCurrencyAmountService userCurrencyAmountService)
    {
        _userCurrencyAmountService = userCurrencyAmountService;
    }

    public async Task<UserCurrencyAmountDto?> Handle(CreateUserCurrencyAmountCommand request, CancellationToken cancellationToken)
    {
        return await _userCurrencyAmountService.AddAsync(request.Data, cancellationToken);
    }
}
