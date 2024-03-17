using AutoMapper;
using Currencies.Contracts.ModelDtos.Currency;
using Currencies.Models.Entities;

namespace Currencies.DataAccess.Mappings;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<CurrencyDto, Currency>();
        CreateMap<Currency, CurrencyDto>();
        CreateMap<Currency, CreateCurrencyDto>();
    }
}