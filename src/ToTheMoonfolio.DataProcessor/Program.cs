using System.Threading;
using ToTheMoonfolio.DataBroker.Core.Abstractions;
using ToTheMoonfolio.DataBroker.Publisher;
using ToTheMoonfolio.ServiceBus;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using ToTheMoonfolio.DataProcessor;
using ToTheMoonfolio.DataProcessor.Handlers;

class Program
{
    static void Main(string[] args)
    {
        var builder = Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddTransient<IEventBus, EventBus>();

                var eventsToConsume = new List<Type>
                {
                    typeof(GeneralStockInformationHandler)
                };

                services.AddServiceBusWithConsumers(eventsToConsume);
            });

        var host = builder.Build();

        // Run the host in a separate thread
        new Thread(() => host.Run()).Start();

        // Keep the main thread running indefinitely
        while (true)
        {
            Thread.Sleep(Timeout.Infinite);
        }
    }
}