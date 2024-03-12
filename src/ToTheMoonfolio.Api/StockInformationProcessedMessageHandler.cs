using MassTransit;
using ToTheMoonfolio.ServiceBus.Messages;

namespace ToTheMoonfolio.Api;

public class StockInformationProcessedMessageHandler : IConsumer<StockInformationProcessed>
{
    public Task Consume(ConsumeContext<StockInformationProcessed> context)
    {
        var data = context.Message.Price;
        return Task.CompletedTask;
    }
}