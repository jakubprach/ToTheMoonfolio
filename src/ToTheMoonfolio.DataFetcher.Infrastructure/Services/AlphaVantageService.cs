using Microsoft.Extensions.Options;
using ToTheMoonfolio.DataFetcher.Core.Abstractions;
using ToTheMoonfolio.DataFetcher.Core.Models;
using ToTheMoonfolio.DataFetcher.Infrastructure.Abstractions;
using ToTheMoonfolio.DataFetcher.Infrastructure.Configuration;
using ToTheMoonfolio.DataFetcher.Infrastructure.Extensions;

namespace ToTheMoonfolio.DataFetcher.Infrastructure.Services;

public class AlphaVantageService : IFinancialDataProvider
{
    private readonly IAlphaVantageApi _alphaVantageApi;
    private readonly AlphaVantageApiConfiguration _alphaVantageApiConfiguration;

    public AlphaVantageService(IAlphaVantageApi alphaVantageApi, IOptions<AlphaVantageApiConfiguration> alphaVantageApiConfiguration)
    {
        _alphaVantageApi = alphaVantageApi;
        _alphaVantageApiConfiguration = alphaVantageApiConfiguration.Value;
    }

    public async Task<GeneralStockInformation> GetGeneralStockInformation(string ticker)
    {
        var result = await _alphaVantageApi.GetGeneralStockInformation(ticker, _alphaVantageApiConfiguration.ApiKey);

        return result.ToGeneralStockInformation();
    }
}