namespace Currencies.Common.Infrastructure;

public interface IModifable
{
    public DateTime? ModifiedOn { get; set; }
}