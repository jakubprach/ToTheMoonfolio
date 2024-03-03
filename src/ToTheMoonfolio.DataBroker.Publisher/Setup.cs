using Microsoft.Extensions.DependencyInjection;
using ToTheMoonfolio.DataBroker.Core.Abstractions;
using ToTheMoonfolio.ServiceBus;

namespace ToTheMoonfolio.DataBroker.Publisher;

public static class Setup
{
    public static void AddPublisher(this IServiceCollection services)
    {
        services.AddServiceBus();
        services.AddTransient<IEventBus, EventBus>();
    }
}