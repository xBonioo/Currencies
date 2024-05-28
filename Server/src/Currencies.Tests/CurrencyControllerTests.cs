using Currencies.Contracts.Interfaces;
using Currencies.Contracts.ModelDtos.Currency;
using Currencies.DataAccess.Services;
using Currencies.Models;
using Currencies.Api.Functions.Currency.Queries.GetAll;
using Currencies.Api.Functions.Currency.Queries.GetSingle;
using Currencies.Api.Functions.Currency.Commands.Create;
using Currencies.Api.Functions.Currency.Commands.Update;
using Currencies.Api.Functions.Currency.Commands.Delete;
using Xunit;
using AutoMapper;
using Currencies.DataAccess.Mappings;
using Currencies.Contracts.Helpers.Forms;
using Currencies.Api.Functions.Currency.Queries.GetEditForm;
using Currencies.Contracts.Response;

namespace Currencies.Tests;

public class CurrencyControllerTests : IClassFixture<BaseTestFixture>
{
    private readonly TableContext _dbContext;
    private readonly ICurrencyService _currencyService;
    private readonly IMapper _mapper;

    public CurrencyControllerTests(BaseTestFixture fixture)
    {
        _dbContext = fixture._dbContext;
        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new AutoMapperProfile());
        });
        _mapper = mappingConfig.CreateMapper();
        _currencyService = new CurrencyService(_dbContext, _mapper);
    }

    [Fact]
    public async Task GetAll_Currencies_ReturnPageResult()
    {
        // arrange
        FilterCurrencyDto filter = new()
        {
            PageNumber = 1,
            PageSize = 10
        };

        GetCurrenciesListQuery query = new(filter);
        GetCurrenciesListQueryHandler handler = new(_currencyService);

        // act
        var result = await handler.Handle(query, new CancellationToken());

        // assert
        Assert.NotNull(result);
        Assert.IsAssignableFrom<PageResult<CurrencyDto>>(result);
    }

    [Fact]
    public async Task GetById_Currency_ReturnCurrency()
    {
        // arrange
        var id = 1;

        GetSingleCurrencyQuery query = new(id);
        GetSingleCurrencyQueryHandler handler = new(_currencyService, _mapper);

        // act
        var result = await handler.Handle(query, new CancellationToken());

        // assert
        Assert.NotNull(result);
        Assert.Equal(id, result!.Id);
    }

    [Fact]
    public async Task Create_Currency_ReturnNewCurrency()
    {
        // arrange
        BaseCurrencyDto dto = new()
        {
            Name = "Name",
            Symbol = "#",
            Description = "Description of new currency",
        };

        CreateCurrencyCommand command = new(dto);
        CreateCurrencyCommandHandler handler = new(_currencyService);

        // act
        var result = await handler.Handle(command, new CancellationToken());

        // assert
        Assert.NotNull(result);
        Assert.IsAssignableFrom<CurrencyDto>(result);
    }

    [Fact]
    public async Task Update_Currency_ReturnUpdatedCurrency()
    {
        // arrange
        var id = 1;
        BaseCurrencyDto dto = new()
        {
            Name = "Update name",
            Symbol = "#",
            Description = "Description of update currency",
            IsActive = true
        };

        UpdateCurrencyCommand command = new(id, dto);
        UpdateCurrencyCommandHandler handler = new(_currencyService);

        // act
        var result = await handler.Handle(command, new CancellationToken());

        // assert
        Assert.NotNull(result);
        Assert.IsAssignableFrom<CurrencyDto>(result);
    }

    [Fact]
    public async Task Delete_Currency_ReturnTrue()
    {
        // arrange
        var id = 1;

        DeleteCurrencyCommand command = new(id);
        DeleteCurrencyCommandHandler handler = new(_currencyService);

        // act
        var result = await handler.Handle(command, new CancellationToken());

        // assert
        Assert.True(result);
    }

    [Fact]
    public async Task GetEditForm_Currency_ReturnCurrencyEmptyEditForm()
    {
        // arrange
        var id = 0;

        GetCurrencyEditFormQuery query = new(id);
        GetCurrencyEditFormQueryHandler handler = new(_currencyService);

        // act
        var result = await handler.Handle(query, new CancellationToken());

        // assert
        Assert.NotNull(result);
        Assert.Equal(string.Empty, result.Name.Value);
        Assert.Equal(string.Empty, result.Symbol.Value);
        Assert.Null(result.Description.Value);
        Assert.True(result.IsActive.Value);
        Assert.IsAssignableFrom<CurrencyEditForm>(result);
    }
}
