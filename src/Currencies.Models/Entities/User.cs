using Microsoft.AspNetCore.Identity;

namespace Currencies.Models.Entities;

public class User : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public bool IsActive { get; set; } = true;
    public virtual ICollection<UserExchangeHistory> UserExchangeHistory { get; set; }
}

public class TokenUser : IdentityUserToken<string>
{
    public DateTime ValidUntil { get; set; }
    public bool IsActive => DateTime.UtcNow <= ValidUntil;
}