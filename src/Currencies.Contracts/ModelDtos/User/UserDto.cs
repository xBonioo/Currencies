﻿namespace Currencies.Contracts.ModelDtos.User;

public class UserDto
{
    public string Id { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public bool IsActive { get; set; }
}
