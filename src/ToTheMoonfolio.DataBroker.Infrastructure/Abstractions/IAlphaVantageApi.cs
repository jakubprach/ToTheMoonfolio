using Refit;
using ToTheMoonfolio.DataBroker.Infrastructure.Models;

namespace ToTheMoonfolio.DataBroker.Infrastructure.Abstractions;

public interface IAlphaVantageApi
{
    [Get("/query?function=GLOBAL_QUOTE&symbol={ticker}&apikey={apiKey}")]
    Task<GlobalQuoteResponse> GetGeneralStockInformation(string ticker, string apiKey);
}