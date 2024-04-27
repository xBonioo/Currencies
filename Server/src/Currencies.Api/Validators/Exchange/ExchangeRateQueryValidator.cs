using Currencies.Api.Functions.Currency.Queries.GetAll;
using Currencies.Contracts.Helpers;
using FluentValidation;

namespace Currencies.Api.Validators.ExchangeRate;

public class ExchangeRateQueryValidator : AbstractValidator<GetCurrenciesListQuery>
{
    public ExchangeRateQueryValidator()
    {
        RuleFor(r => r.Filter.PageNumber).GreaterThanOrEqualTo(1);
        RuleFor(r => r.Filter.PageSize).Custom((value, context) =>
        {
            if (!PropertyForQuery.AllowedPageSizes.Contains(value))
            {
                context.AddFailure("PageSize", $"PageSize must in [{string.Join(", ", PropertyForQuery.AllowedPageSizes)}]");
            }
        });
    }
}