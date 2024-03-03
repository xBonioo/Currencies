using Currencies.Common.Infrastructure;

namespace Currencies.Models.Entities;

public class CurrencyAmount : ICreatable
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public int CurrencyId { get; set; }
    public decimal Amount { get; set; }
    public DateTime CreatedOn { get; set; }

    public virtual ApplicationUser User { get; set; }
    public virtual Currency Currency { get; set; }
}
