using MassTransit;
using ToTheMoonfolio.DataProcessor;

namespace ToTheMoonfolio.Api;

public class MqHandler : IConsumer<StockInformationProcessed>
{
    public Task Consume(ConsumeContext<StockInformationProcessed> context)
    {
        var data = context.Message.Price;
        return Task.CompletedTask;
    }
}