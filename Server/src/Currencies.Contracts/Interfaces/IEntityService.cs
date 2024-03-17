namespace Currencies.Contracts.Interfaces;

public interface IEntityService<T>
{
    Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken);
}
