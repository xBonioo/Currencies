namespace Currencies.Contracts.ModelDtos.Currency;

public class FilterRoleDto : FilterDto
{
    public DateTime From { get; set; }
    public DateTime To { get; set; }
}
