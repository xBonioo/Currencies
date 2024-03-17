using Currencies.Contracts.Helpers;
using Currencies.Contracts.ModelDtos.User.CurrencyAmount;

namespace Currencies.Contracts.Interfaces;

public interface IUserCurrencyAmountService
{
    Task<PageResult<UserCurrencyAmountDto>> GetAllUserCurrencyAmountsAsync(CancellationToken cancellationToken);
    Task<UserCurrencyAmountDto> GetUserCurrencyAmountByIdAsync(int userCurrencyAmountId, CancellationToken cancellationToken);
    Task<UserCurrencyAmountDto> ConvertCurrencyAsync(ConvertUserCurrencyAmountDto convertUserCurrencyAmountDto, CancellationToken cancellationToken);
    Task<bool> DeleteUserCurrencyAmountAsync(int userCurrencyAmountId, CancellationToken cancellationToken);
    Task<UserCurrencyAmountDto> AddUserCurrencyAmountAsync(int userCurrencyAmountId, UpdateUserCurrencyAmountDto userCurrencyAmountDto, CancellationToken cancellationToken);
    Task<UserCurrencyAmountDto> UpdateUserCurrencyAmountAsync(int userCurrencyAmountId, UpdateUserCurrencyAmountDto userCurrencyAmountDto, CancellationToken cancellationToken);
}