using Currencies.Contracts.Helpers.Forms;
using MediatR;

namespace Currencies.Api.Functions.UserCurrencyAmount.Queries.GetEditForm;

public record GetUserCurrencyAmountEditFormQuery(int Id) : IRequest<UserCurrencyAmountEditForm>;
