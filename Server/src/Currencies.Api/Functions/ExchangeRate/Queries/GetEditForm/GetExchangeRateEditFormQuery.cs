using Currencies.Contracts.Helpers.Forms;
using MediatR;

namespace Currencies.Api.Functions.ExchangeRate.Queries.GetEditForm;

public record GetExchangeRateEditFormQuery(int id) : IRequest<ExchangeRateEditForm?>;