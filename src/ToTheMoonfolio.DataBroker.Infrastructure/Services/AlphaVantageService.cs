using Microsoft.Extensions.Options;
using ToTheMoonfolio.DataBroker.Core.Abstractions;
using ToTheMoonfolio.DataBroker.Core.Models;
using ToTheMoonfolio.DataBroker.Infrastructure.Abstractions;
using ToTheMoonfolio.DataBroker.Infrastructure.Configuration;
using ToTheMoonfolio.DataBroker.Infrastructure.Extensions;

namespace ToTheMoonfolio.DataBroker.Infrastructure.Services;

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