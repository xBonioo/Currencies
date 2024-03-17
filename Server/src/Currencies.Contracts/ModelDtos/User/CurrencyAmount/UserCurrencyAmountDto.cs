namespace Currencies.Contracts.ModelDtos.User.CurrencyAmount;

public class UserCurrencyAmountDto : BaseUserCurrencyAmountDto
{
    public int Id { get; set; }
    public int CurrencyAmountId { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }
}
