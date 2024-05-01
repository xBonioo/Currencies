using Currencies.Contracts.ModelDtos.ExchangeRate;
using Currencies.Contracts.ModelDtos.Role;
using MediatR;

namespace Currencies.Api.Functions.ExchangeRate.Commands.Create;

public class CreateExchangeRateCommand : IRequest<ExchangeRateDto>
{
    public BaseExchangeRateDto Data { get; set; } = null!;

    public CreateExchangeRateCommand(BaseExchangeRateDto dto)
    {
        Data = dto;
    }
}