using MediatR;

namespace Currencies.Api.Functions.UserCurrencyAmount.Commands.Delete;

public class DeleteUserCurrencyAmountCommand : IRequest<bool>
{
    public int Id { get; set; }

    public DeleteUserCurrencyAmountCommand(int id)
    {
        Id = id;
    }
}
