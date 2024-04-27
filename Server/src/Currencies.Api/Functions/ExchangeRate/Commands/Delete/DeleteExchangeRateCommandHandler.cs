using Currencies.Contracts.Interfaces;
using MediatR;

namespace Currencies.Api.Functions.ExchangeRate.Commands.Delete;

public class DeleteExchangeRateCommandHandler : IRequestHandler<DeleteExchangeRateCommand, bool>
{
    private readonly IRoleService _roleService;

    public DeleteExchangeRateCommandHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<bool> Handle(DeleteExchangeRateCommand request, CancellationToken cancellationToken)
    {
        return await _roleService.DeleteAsync(request.Id, cancellationToken);
    }
}