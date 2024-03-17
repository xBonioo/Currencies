using Currencies.Common.Infrastructure;

namespace Currencies.Models.Entities;

public class UserCurrencyAmount : ICreatable, IModifable
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public int CurrencyId { get; set; }
    public decimal Amount { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }

    public virtual ApplicationUser User { get; set; }
    public virtual Currency Currency { get; set; }
}
