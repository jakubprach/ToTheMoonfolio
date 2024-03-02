using ToTheMoonfolio.DataFetcher.Core.Models;

namespace ToTheMoonfolio.DataFetcher.Core.Abstractions;

public interface IFinancialDataProvider
{
    Task<GeneralStockInformation> GetGeneralStockInformation(string ticker);
}