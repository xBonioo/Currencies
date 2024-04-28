using AutoMapper;
using Currencies.Api.Functions.Role.Queries.GetEditForm;
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

    public async Task<ExchangeRateEditForm> Handle(GetExchangeRateEditFormQuery request, CancellationToken cancellationToken)
    {
        var exchangeRate = await _exchangeRateService.GetByIdAsync(request.id, cancellationToken);
        if (exchangeRate == null || !exchangeRate.IsActive)
        {
            var createForm = new ExchangeRateEditForm()
            {
                FromCurrencyID = new IntegerControl()
                {
                    IsRequired = true,
                    Value = 0,
                    MinValue = 1,
                    MaxValue = 15
                },
                ToCurrencyID = new IntegerControl()
                {
                    IsRequired = true,
                    Value = 0,
                    MinValue = 1,
                    MaxValue = 15
                },
                Rate = new DecimalControl()
                {
                    IsRequired = true,
                    Value = 0,
                    MinValue = 0.1m,
                    MaxValue = 24
                },
                //Direction = new EnumControl()
                //{
                //    IsRequired = true,
                //    Value = 0
                //},
                IsActive = new BoolControl()
                {
                    IsRequired = true,
                    Value = true
                }
            };

            return createForm;
        }

        var editForm = new RoleEditForm()
        {
            Name = new StringControl()
            {
                IsRequired = true,
                Value = role.Name,
                MinLenght = 1,
                MaxLenght = 64
            },
            IsActive = new BoolControl()
            {
                IsRequired = true,
                Value = role.IsActive
            }
        };

        return editForm;
    }
}