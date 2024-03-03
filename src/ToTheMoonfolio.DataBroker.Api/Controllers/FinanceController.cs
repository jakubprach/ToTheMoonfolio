using Microsoft.AspNetCore.Mvc;
using ToTheMoonfolio.DataBroker.Core.Abstractions;
using ToTheMoonfolio.DataBroker.Core.Messages;

namespace ToTheMoonfolio.DataBroker.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FinanceController : ControllerBase
{
    private readonly IFinancialDataProvider _financialDataProvider;
    private readonly IEventBus _eventBus;

    public FinanceController(IFinancialDataProvider financialDataProvider, 
        IEventBus eventBus)
    {
        _financialDataProvider = financialDataProvider;
        _eventBus = eventBus;
    }

    [HttpGet]
    public async Task<IActionResult> GetGeneralStockInformation(string ticker)
    {
        var generalStockInformation = await _financialDataProvider.GetGeneralStockInformation(ticker);

        await _eventBus.PublishAsync(new StockInformationReceived(generalStockInformation.Symbol, generalStockInformation.Price));
        
        return Ok(generalStockInformation);
    }
}