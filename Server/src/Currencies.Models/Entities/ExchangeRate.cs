using Currencies.Common.Infrastructure;

namespace Currencies.Models.Entities;

public class ExchangeRate : ICreatable, IModifable
{
    public int Id { get; set; }
    public int FromCurrencyID { get; set; }
    public int ToCurrencyID { get; set; }
    public decimal Rate { get; set; }
    public Direction Direction { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }

    public virtual Currency FromCurrency { get; set; }
    public virtual Currency ToCurrency { get; set; }
}