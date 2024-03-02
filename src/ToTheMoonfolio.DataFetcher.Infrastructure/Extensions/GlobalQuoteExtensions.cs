using ToTheMoonfolio.DataFetcher.Core.Models;

namespace ToTheMoonfolio.DataFetcher.Infrastructure.Extensions;

public static class GlobalQuoteExtensions
{
    public static GeneralStockInformation ToGeneralStockInformation(this GlobalQuoteResponse response)
    {
        return new GeneralStockInformation(
            response.GlobalQuote.Symbol,
            decimal.Parse(response.GlobalQuote.Price)
            );
    }
}