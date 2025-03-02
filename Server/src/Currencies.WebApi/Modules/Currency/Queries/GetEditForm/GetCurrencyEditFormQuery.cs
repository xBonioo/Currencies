using Currencies.Contracts.Helpers.Forms;
using MediatR;

namespace Currencies.Api.Modules.Currency.Queries.GetEditForm;

public record GetCurrencyEditFormQuery(int id) : IRequest<CurrencyEditForm>;