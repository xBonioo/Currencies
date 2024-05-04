using AutoMapper;
using Currencies.Api.Functions.UserCurrencyAmount.Queries.GetEditForm;
using Currencies.Contracts.Helpers.Controls;
using Currencies.Contracts.Helpers.Forms;
using Currencies.Contracts.Interfaces;
using Currencies.DataAccess.Services;
using Currencies.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Currencies.Api.Functions.UserCurrencyAmount.Queries.GetEditForm;

public class GetUserCurrencyAmountEditFormQueryHandler : IRequestHandler<GetUserCurrencyAmountEditFormQuery, UserCurrencyAmountEditForm?>
{
    private readonly IUserCurrencyAmountService _userCurrencyAmountService;
    private readonly IMapper _mapper;
    private readonly TableContext _dbContext;

    public GetUserCurrencyAmountEditFormQueryHandler(IUserCurrencyAmountService userCurrencyAmountService, IMapper mapper, TableContext dbContext)
    {
        _userCurrencyAmountService = userCurrencyAmountService;
        _mapper = mapper;
        _dbContext = dbContext;
    }

    public async Task<UserCurrencyAmountEditForm> Handle(GetUserCurrencyAmountEditFormQuery request, CancellationToken cancellationToken)
    {
        var userCurrencyAmount = await _userCurrencyAmountService.GetByIdAsync(request.Id, cancellationToken);
        if (userCurrencyAmount == null || !userCurrencyAmount.IsActive)
        {
            var createForm = new UserCurrencyAmountEditForm()
            {
                UserId = new StringControl()
                {
                    IsRequired = true,
                    Value = string.Empty,
                    MinLenght = 1,
                    MaxLenght = 15
                },
                CurrencyId = new IntegerControl()
                {
                    IsRequired = true,
                    Value = 0,
                    MinValue = 1,
                    MaxValue = 999999999
                },
                Amount = new DecimalControl()
                {
                    IsRequired = true,
                    Value = 0.0m,
                    MinValue = 0.1m,
                    MaxValue = 9999999999
                },
                IsActive = new BoolControl()
                {
                    IsRequired = true,
                    Value = true
                }
            };


            return createForm;
        }

        var editForm = new UserCurrencyAmountEditForm()
        {
             UserId = new StringControl()
             {
                 IsRequired = true,
                 Value = userCurrencyAmount.UserId,
                 MinLenght = 1,
                 MaxLenght = 15
             },
            CurrencyId = new IntegerControl()
            {
                IsRequired = true,
                Value = userCurrencyAmount.CurrencyId,
                MinValue = 1,
                MaxValue = 999999999
            },
            Amount = new DecimalControl()
            {
                IsRequired = true,
                Value = userCurrencyAmount.Amount,
                MinValue = 0.1m,
                MaxValue = 9999999999
            },
            IsActive = new BoolControl()
            {
                IsRequired = true,
                Value = true
            }
        };

        return editForm;
    }
}
