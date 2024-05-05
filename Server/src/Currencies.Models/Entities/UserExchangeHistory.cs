using Currencies.Common.Enum;
using Currencies.Common.Infrastructure;

namespace Currencies.Models.Entities;

public class UserExchangeHistory : ICreatable
{
    public int Id { get; set; }
    public string UserID { get; set; }
    public int RateID { get; set; }
    public decimal Amount { get; set; }
    public int AccountID { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public PaymentType PaymentType { get; set; }
    public DateTime CreatedOn { get; set; }

    public virtual ApplicationUser User { get; set; }
    public virtual ExchangeRate Rate { get; set; }
    public virtual UserCurrencyAmount Account { get; set; }
}
