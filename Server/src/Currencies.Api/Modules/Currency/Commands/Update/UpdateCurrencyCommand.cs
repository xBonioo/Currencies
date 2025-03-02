using Currencies.Contracts.ModelDtos.Currency;
using MediatR;

namespace Currencies.Api.Modules.Currency.Commands.Update;

public class UpdateCurrencyCommand : IRequest<CurrencyDto>
{
    public int Id { get; set; }
    public BaseCurrencyDto Dto { get; set; }

    public UpdateCurrencyCommand(int id, BaseCurrencyDto dto)
    {
        Id = id;
        Dto = dto;
    }
}