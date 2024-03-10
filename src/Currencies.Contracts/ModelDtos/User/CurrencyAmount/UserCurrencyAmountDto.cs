namespace Currencies.Contracts.ModelDtos.User.CurrencyAmount;

public class UserCurrencyAmountDto
{
    public int Id { get; set; }
    public string UserId { get; set; } = null!;
    public int CurrencyAmountId { get; set; }
    public decimal Amount { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }
}
