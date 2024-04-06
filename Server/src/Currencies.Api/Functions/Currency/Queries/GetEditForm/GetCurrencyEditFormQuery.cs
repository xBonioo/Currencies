using Currencies.Contracts.Helpers.Forms;
using Currencies.Contracts.ModelDtos.Currency;
using MediatR;

namespace Currencies.Api.Functions.Currency.Queries.GetEditForm;

public record GetCurrencyEditFormQuery(int id) : IRequest<CurrencyEditForm>;