using Currencies.Contracts.ModelDtos.ExchangeRate;
using MediatR;

namespace Currencies.Api.Modules.ExchangeRate.Commands.Update;

public class UpdateExchangeRateCommand : IRequest<ExchangeRateDto>
{
    public int Id { get; set; }
    public BaseExchangeRateDto Dto { get; set; }

    public UpdateExchangeRateCommand(int id, BaseExchangeRateDto dto)
    {
        Id = id;
        Dto = dto;
    }
}