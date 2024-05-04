using Currencies.Contracts.Interfaces;
using Currencies.Contracts.ModelDtos.ExchangeRate;
using Currencies.Contracts.ModelDtos.Role;
using Currencies.Models.Entities;
using MediatR;
using System.Text.Json;

namespace Currencies.Api.Functions.ExchangeRate.Commands.Create;

public class CreateExchangeRateCommandHandler : IRequestHandler<CreateExchangeRateCommand, List<ExchangeRateDto>?>
{
    private readonly IExchangeRateService _exchangeRate;

    public CreateExchangeRateCommandHandler(IExchangeRateService exchangeRate)
    {
        _exchangeRate = exchangeRate;
    }

    public async Task<List<ExchangeRateDto?>> Handle(CreateExchangeRateCommand request, CancellationToken cancellationToken)
    {
        var currencyExchangeRateList = new List<CurrencyExchangeRateDto>();
        string[] currencies = { "USD", "EUR", "GBP", "PLN" };
        var httpClient = new HttpClient();

        foreach (var currency in currencies)
        {
            var apiUrl = $"https://api.nbp.pl/api/exchangerates/rates/c/{currency}/{request.Date:yyyy-MM-dd}/?format=json";
            try
            {
                var response = await httpClient.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    using (JsonDocument doc = JsonDocument.Parse(jsonResponse))
                    {
                        var root = doc.RootElement;
                        var rates = root.GetProperty("rates");
                        if (rates.GetArrayLength() > 0)
                        {
                            var rate = rates[0];

                            var exchangeRate = new CurrencyExchangeRateDto
                            {
                                Code = root.GetProperty("code").GetString(),
                                Ask = rate.GetProperty("ask").GetDecimal(),
                                Bid = rate.GetProperty("bid").GetDecimal()
                            };
                            currencyExchangeRateList.Add(exchangeRate);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
        }

        httpClient.Dispose();

        return await _exchangeRate.CreateAsync(currencyExchangeRateList, cancellationToken);
    }
}