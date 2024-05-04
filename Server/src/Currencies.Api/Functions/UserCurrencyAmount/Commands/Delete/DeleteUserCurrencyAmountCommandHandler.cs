using Currencies.Contracts.Interfaces;
using Currencies.DataAccess.Services;
using MediatR;

namespace Currencies.Api.Functions.UserCurrencyAmount.Commands.Delete;

public class DeleteUserCurrencyAmountCommandHandler : IRequestHandler<DeleteUserCurrencyAmountCommand, bool>
{
    private readonly IUserCurrencyAmountService _userCurrencyAmountService;

    public DeleteUserCurrencyAmountCommandHandler(IUserCurrencyAmountService userCurrencyAmountService)
    {
        _userCurrencyAmountService = userCurrencyAmountService;
    }

    public async Task<bool> Handle(DeleteUserCurrencyAmountCommand request, CancellationToken cancellationToken)
    {
        return await _userCurrencyAmountService.DeleteAsync(request.Id, cancellationToken);
    }
}
