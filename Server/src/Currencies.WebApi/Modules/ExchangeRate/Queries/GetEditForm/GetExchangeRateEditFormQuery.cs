using Currencies.Contracts.Helpers.Forms;
using MediatR;

namespace Currencies.Api.Modules.ExchangeRate.Queries.GetEditForm;

public record GetExchangeRateEditFormQuery(int id) : IRequest<ExchangeRateEditForm?>;