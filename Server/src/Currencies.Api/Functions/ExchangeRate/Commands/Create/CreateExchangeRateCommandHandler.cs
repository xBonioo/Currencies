using Currencies.Contracts.Interfaces;
using Currencies.Contracts.ModelDtos.ExchangeRate;
using Currencies.Contracts.ModelDtos.Role;
using MediatR;

namespace Currencies.Api.Functions.ExchangeRate.Commands.Create;

public class CreateExchangeRateCommandHandler : IRequestHandler<CreateExchangeRateCommand, ExchangeRateDto?>
{
    private readonly IExchangeRateService _roleService;

    public CreateExchangeRateCommandHandler(IExchangeRateService roleService)
    {
        _roleService = roleService;
    }

    public async Task<ExchangeRateDto?> Handle(CreateExchangeRateCommand request, CancellationToken cancellationToken)
    {
        return await _roleService.CreateAsync(request.Data, cancellationToken);
    }
}