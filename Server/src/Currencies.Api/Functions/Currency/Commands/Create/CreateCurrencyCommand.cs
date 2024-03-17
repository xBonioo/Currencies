using Currencies.Contracts.ModelDtos.Currency;
using MediatR;

namespace Currencies.Api.Functions.Currency.Commands.Create;

public class CreateCurrencyCommand : IRequest<CurrencyDto>
{
    public CreateCurrencyDto Data { get; set; } = null!;

    public CreateCurrencyCommand(CreateCurrencyDto dto)
    {
        Data = dto;
    }
}