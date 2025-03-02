using MediatR;

namespace Currencies.Api.Modules.UserCurrencyAmount.Commands.Delete;

public class DeleteUserCurrencyAmountCommand : IRequest<bool>
{
    public int Id { get; set; }

    public DeleteUserCurrencyAmountCommand(int id)
    {
        Id = id;
    }
}
