using AutoMapper;
using Currencies.Contracts.ModelDtos.Currency;
using Currencies.Contracts.ModelDtos.Role;
using Currencies.Contracts.ModelDtos.ExchangeRate;
using Currencies.Models.Entities;

namespace Currencies.DataAccess.Mappings;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<CurrencyDto, Currency>();
        CreateMap<Currency, CurrencyDto>();
        CreateMap<Currency, BaseCurrencyDto>();
        CreateMap<RoleDto, Role>();
        CreateMap<Role, RoleDto>();
        CreateMap<Role, BaseRoleDto>();
        CreateMap<ExchangeRateDto, ExchangeRate>();
        CreateMap<ExchangeRate, ExchangeRateDto>();
        CreateMap<ExchangeRate, BaseExchangeRateDto>();
    }
}