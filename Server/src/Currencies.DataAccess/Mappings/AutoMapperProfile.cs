using AutoMapper;
using Currencies.Contracts.ModelDtos.Currency;
using Currencies.Contracts.ModelDtos.Role;
using Currencies.Contracts.ModelDtos.ExchangeRate;
using Currencies.Contracts.ModelDtos.User.CurrencyAmount;
using Currencies.Models.Entities;
using Currencies.Contracts.ModelDtos.User;
using Currencies.Contracts.ModelDtos.User.ExchangeHistory;
using Currencies.Contracts.Helpers;

namespace Currencies.DataAccess.Mappings;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<CurrencyDto, Currency>();
        CreateMap<Currency, CurrencyDto>();
        CreateMap<Currency, BaseCurrencyDto>();
        CreateMap<AnonymousTypeModel, CurrencyDto>();

        CreateMap<RoleDto, Role>();
        CreateMap<Role, RoleDto>();
        CreateMap<Role, BaseRoleDto>();

        CreateMap<ExchangeRateDto, ExchangeRate>();
        CreateMap<ExchangeRate, ExchangeRateDto>();
        CreateMap<ExchangeRate, BaseExchangeRateDto>();

        CreateMap<UserCurrencyAmountDto, UserCurrencyAmount>();
        CreateMap<UserCurrencyAmount, UserCurrencyAmountDto>();
        CreateMap<UserCurrencyAmount, BaseUserCurrencyAmountDto>();

        CreateMap<UserExchangeHistoryDto, UserExchangeHistory>();
        CreateMap<UserExchangeHistory, UserExchangeHistoryDto>();
        CreateMap<UserExchangeHistory, BaseUserExchangeHistoryDto>();

        CreateMap<ApplicationUser, UserDto>();
    }
}