using Currencies.Contracts.ModelDtos.ExchangeRate;
using MediatR;

namespace Currencies.Api.Modules.ExchangeRate.Commands.Create;

public class CreateExchangeRateCommand : IRequest<List<ExchangeRateDto>>
{
    public DateTime Date { get; set; }

    public CreateExchangeRateCommand(DateTime date)
    {
        Date = date;
    }
}