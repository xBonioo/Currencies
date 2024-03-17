using Currencies.Contracts.ModelDtos.Currency;
using MediatR;

namespace Currencies.Api.Functions.Currency.Commands.Update;

public class UpdateCurrencyCommand : IRequest<CurrencyDto>
{
    public int Id { get; set; }
    public UpdateCurrencyDto Dto { get; set; }

    public UpdateCurrencyCommand(int id, UpdateCurrencyDto dto)
    {
        Id = id;
        Dto = dto;
    }
}