using Currencies.Common.Infrastructure;

namespace Currencies.Models.Entities;

public class UserExchangeHistory : ICreatable, IModifable
{
    public int Id { get; set; }
    public string UserID { get; set; }
    public int FromCurrencyID { get; set; }
    public int ToCurrencyID { get; set; }
    public decimal Amount { get; set; }
    public decimal ExchangeRate { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }

    public virtual User User { get; set; }
    public virtual Currency FromCurrency { get; set; }
    public virtual Currency ToCurrency { get; set; }
}