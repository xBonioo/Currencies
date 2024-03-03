using Currencies.Common.Infrastructure;

namespace Currencies.Models.Entities;

public class Role : ICreatable, IModifable
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }
}
