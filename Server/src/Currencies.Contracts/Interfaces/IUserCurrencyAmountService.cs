using Currencies.Contracts.ModelDtos.User.CurrencyAmount;
using Currencies.Contracts.Response;
using Currencies.Models.Entities;

namespace Currencies.Contracts.Interfaces;

public interface IUserCurrencyAmountService : IEntityService<UserCurrencyAmount>
{
    Task<PageResult<UserCurrencyAmountDto>> GetAllUserCurrencyAmountsAsync(FilterUserCurrencyAmountDto filter, CancellationToken cancellationToken);
    Task<UserCurrencyAmountDto?> ConvertAsync(ConvertUserCurrencyAmountDto dto, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
    Task<UserCurrencyAmountDto?> AddAsync(BaseUserCurrencyAmountDto dto, CancellationToken cancellationToken);
    Task<UserCurrencyAmountDto?> UpdateAsync(int id, BaseUserCurrencyAmountDto dto, CancellationToken cancellationToken);
}