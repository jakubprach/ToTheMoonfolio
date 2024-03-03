using ToTheMoonfolio.DataBroker.Core.Abstractions;
using ToTheMoonfolio.DataBroker.Publisher;
using ToTheMoonfolio.DataProcessor;
using ToTheMoonfolio.ServiceBus;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.AddTransient<IEventBus, EventBus>();

var eventsToConsume = new List<Type>
{
    typeof(GeneralStockInformationHandler)
};

builder.Services.AddServiceBusWithConsumers(eventsToConsume);

var host = builder.Build();
host.Run();