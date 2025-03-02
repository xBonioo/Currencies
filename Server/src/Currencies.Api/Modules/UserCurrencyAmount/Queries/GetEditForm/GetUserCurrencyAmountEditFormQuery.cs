using Currencies.Contracts.Helpers.Forms;
using MediatR;

namespace Currencies.Api.Modules.UserCurrencyAmount.Queries.GetEditForm;

public record GetUserCurrencyAmountEditFormQuery(int Id) : IRequest<UserCurrencyAmountEditForm>;
