namespace Currencies.Contracts.ModelDtos.User;

public class RegisterUserDto
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string ConfirmPassword { get; set; } = null!;
    public string UserName { get; set; } = null!;
}
