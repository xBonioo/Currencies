using Currencies.Contracts.ModelDtos.ExchangeRate;
using Currencies.Contracts.ModelDtos.Role;
using MediatR;

namespace Currencies.Api.Functions.ExchangeRate.Commands.Create;

public class CreateExchangeRateCommand : IRequest<List<ExchangeRateDto>>
{
    public DateTime Date { get; set; }

    public CreateExchangeRateCommand(DateTime date)
    {
        Date = date;
    }
}