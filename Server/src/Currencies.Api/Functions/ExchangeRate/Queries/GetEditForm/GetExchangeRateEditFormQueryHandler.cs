using AutoMapper;
using Currencies.Api.Functions.Role.Queries.GetEditForm;
using Currencies.Common.Infrastucture;
using Currencies.Contracts.Helpers.Controls;
using Currencies.Contracts.Helpers.Forms;
using Currencies.Contracts.Interfaces;
using Currencies.DataAccess.Services;
using Currencies.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Currencies.Api.Functions.ExchangeRate.Queries.GetEditForm;

public class GetExchangeRateEditFormQueryHandler : IRequestHandler<GetExchangeRateEditFormQuery, ExchangeRateEditForm?>
{
    private readonly IExchangeRateService _exchangeRateService;
    private readonly IMapper _mapper;
    private readonly TableContext _dbContext;

    public GetExchangeRateEditFormQueryHandler(IExchangeRateService exchangeRateService, IMapper mapper, TableContext dbContext)
    {
        _exchangeRateService = exchangeRateService;
        _mapper = mapper;
        _dbContext = dbContext;
    }

    public async Task<ExchangeRateEditForm?> Handle(GetExchangeRateEditFormQuery request, CancellationToken cancellationToken)
    {
        var exchangeRate = await _exchangeRateService.GetByIdAsync(request.id, cancellationToken);
        if (exchangeRate == null || !exchangeRate.IsActive)
        {
            return null;
        }

        var editForm = new ExchangeRateEditForm()
        {
            FromCurrencyId = new IntegerControl()
            {
                IsRequired = true,
                Value = exchangeRate.FromCurrencyID,
                MinValue = 1,
                MaxValue = 15
            },
            ToCurrencyId = new IntegerControl()
            {
                IsRequired = true,
                Value = exchangeRate.ToCurrencyID,
                MinValue = 1,
                MaxValue = 15
            },
            Rate = new DecimalControl()
            {
                IsRequired = true,
                Value = exchangeRate.Rate,
                MinValue = 0.1m,
                MaxValue = 24
            },
            Direction = new EnumControl<Direction>()
            {
                IsRequired = true,
                Value = exchangeRate.Direction
            },
            IsActive = new BoolControl()
            {
                IsRequired = true,
                Value = exchangeRate.IsActive
            }
        };

        return editForm;
    }
}