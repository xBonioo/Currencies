using Currencies.Contracts.ModelDtos.Currency;
using MediatR;

namespace Currencies.Api.Functions.Currency.Commands.Create;

public class CreateCurrencyCommand : IRequest<CurrencyDto>
{
    public BaseCurrencyDto Data { get; set; } = null!;

    public CreateCurrencyCommand(BaseCurrencyDto dto)
    {
        Data = dto;
    }
}