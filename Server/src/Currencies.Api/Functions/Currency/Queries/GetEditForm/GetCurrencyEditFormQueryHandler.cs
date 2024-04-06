using AutoMapper;
using Currencies.Contracts.Helpers.Controls;
using Currencies.Contracts.Helpers.Forms;
using Currencies.Contracts.Interfaces;
using Currencies.Contracts.ModelDtos.Currency;
using Currencies.DataAccess.Services;
using Currencies.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Currencies.Api.Functions.Currency.Queries.GetEditForm;

public class GetCurrencyEditFormQueryHandler : IRequestHandler<GetCurrencyEditFormQuery, CurrencyEditForm?>
{
    private readonly ICurrencyService _currencyService;
    private readonly IMapper _mapper;
    private readonly TableContext _dbContext;

    public GetCurrencyEditFormQueryHandler(ICurrencyService currencyService, IMapper mapper, TableContext dbContext)
    {
        _currencyService = currencyService;
        _mapper = mapper;
        _dbContext = dbContext;
    }

    public async Task<CurrencyEditForm> Handle(GetCurrencyEditFormQuery request, CancellationToken cancellationToken)
    {
        var currency = await _currencyService.GetByIdAsync(request.id, cancellationToken);
        if (currency == null || !currency.IsActive)
        {
            var createForm = new CurrencyEditForm()
            {
                Name = new StringControl()
                {
                    IsRequired = true,
                    Value = string.Empty,
                    MinLenght = 1,
                    MaxLenght = 64
                },
                Symbol = new StringControl()
                {
                    IsRequired = true,
                    Value = string.Empty,
                    MinLenght = 1,
                    MaxLenght = 3
                },
                Description = new StringControl()
                {
                    IsRequired = false,
                    Value = null,
                    MinLenght = 1,
                    MaxLenght = 256
                },
                IsActive = new BoolControl()
                {
                    IsRequired = true,
                    Value = true
                }
            };

            return createForm;
        }

        var editForm = new CurrencyEditForm()
        {
            Name = new StringControl()
            {
                IsRequired = true,
                Value = currency.Name,
                MinLenght = 1,
                MaxLenght = 64
            },
            Symbol = new StringControl()
            {
                IsRequired = true,
                Value = currency.Symbol,
                MinLenght = 1,
                MaxLenght = 3
            },
            Description = new StringControl()
            {
                IsRequired = false,
                Value = currency.Description,
                MinLenght = 1,
                MaxLenght = 256
            },
            IsActive = new BoolControl()
            {
                IsRequired = true,
                Value = currency.IsActive
            }
        };

        return editForm;
    }
}