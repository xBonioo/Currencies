using MediatR;

namespace Currencies.Api.Functions.ExchangeRate.Commands.Delete;

public class DeleteExchangeRateCommand : IRequest<bool>
{
    public int Id { get; set; }

    public DeleteExchangeRateCommand(int id)
    {
        Id = id;
    }
}