using ToTheMoonfolio.DataBroker.Core.Models;

namespace ToTheMoonfolio.DataBroker.Core.Abstractions;

public interface IFinancialDataProvider
{
    Task<GeneralStockInformation> GetGeneralStockInformation(string ticker);
}