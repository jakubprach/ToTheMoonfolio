using ToTheMoonfolio.DataBroker.Core.Models;
using ToTheMoonfolio.DataBroker.Infrastructure.Models;

namespace ToTheMoonfolio.DataBroker.Infrastructure.Extensions;

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