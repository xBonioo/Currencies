namespace Currencies.Contracts.ModelDtos.Role;

public class RoleDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }
}