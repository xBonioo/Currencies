using Currencies.Contracts.ModelDtos.ExchangeRate;
using Currencies.Contracts.ModelDtos.Role;
using MediatR;

namespace Currencies.Api.Functions.ExchangeRate.Commands.Update;

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