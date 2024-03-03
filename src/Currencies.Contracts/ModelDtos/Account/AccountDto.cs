namespace Currencies.Contracts.ModelDtos.Account;

public class AccountDto
{
    public string Id { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public bool IsActive { get; set; }
}
