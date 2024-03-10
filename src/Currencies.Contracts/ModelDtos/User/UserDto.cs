namespace Currencies.Contracts.ModelDtos.User;

public class UserDto
{
    public string Id { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string? FirstName { get; set; }
    public string? SecondName { get; set; }
    public bool IsActive { get; set; }
}
