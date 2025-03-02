using MediatR;

namespace Currencies.Api.Modules.Currency.Commands.Delete;

public class DeleteCurrencyCommand : IRequest<bool>
{
    public int Id { get; set; }

    public DeleteCurrencyCommand(int id)
    {
        Id = id;
    }
}