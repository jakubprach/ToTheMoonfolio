using MassTransit;
using ToTheMoonfolio.DataBroker.Core.Abstractions;
using ToTheMoonfolio.ServiceBus.Messages;

namespace ToTheMoonfolio.DataProcessor;

public class GeneralStockInformationHandler : IConsumer<StockInformationReceived>
{
    private readonly ILogger<GeneralStockInformationHandler> _logger;
    private readonly IEventBus _eventBus;
    

    public GeneralStockInformationHandler(ILogger<GeneralStockInformationHandler> logger, 
        IEventBus eventBus)
    {
        _logger = logger;
        _eventBus = eventBus;
    }

    public Task Consume(ConsumeContext<StockInformationReceived> context)
    {
        _logger.LogInformation("Received stock information for {Symbol}, Price: {Price}", context.Message.Symbol, context.Message.Price);
        _eventBus.PublishAsync(new StockInformationProcessed(context.Message.Symbol, context.Message.Price));
        return Task.CompletedTask;
    }
}