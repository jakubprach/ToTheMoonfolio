using Microsoft.AspNetCore.Mvc;
using ToTheMoonfolio.DataFetcher.Core.Abstractions;

namespace ToTheMoonfolio.DataFetcher.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FinanceController : ControllerBase
{
    private readonly IFinancialDataProvider _financialDataProvider;

    public FinanceController(IFinancialDataProvider financialDataProvider)
    {
        _financialDataProvider = financialDataProvider;
    }

    [HttpGet]
    public async Task<IActionResult> GetGeneralStockInformation(string ticker)
    {
        var generalStockInformation = await _financialDataProvider.GetGeneralStockInformation(ticker);

        return Ok(generalStockInformation);
    }
}