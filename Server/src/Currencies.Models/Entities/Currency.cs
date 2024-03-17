using Currencies.Common.Infrastructure;

namespace Currencies.Models.Entities;

public class Currency : ICreatable, IModifable
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Symbol { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }
}