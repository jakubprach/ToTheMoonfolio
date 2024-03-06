using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace ToTheMoonfolio.ServiceBus;

public static class Setup
{
    public static void AddServiceBus(this IServiceCollection services)
    {
        services.AddMassTransit(busConfigurator =>
        {
            busConfigurator.SetKebabCaseEndpointNameFormatter();

            busConfigurator.UsingRabbitMq((context, configurator) =>
            {
                configurator.Host("rabbitmq", "/", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                configurator.ConfigureEndpoints(context);
            });
        });
    }
    
    public static void AddServiceBusWithConsumers(this IServiceCollection services, List<Type> events)
    {
        services.AddMassTransit(busConfigurator =>
        {
            foreach (var eventToConsume in events)
            {
                busConfigurator.AddConsumer(eventToConsume);    
            }
            
            busConfigurator.SetKebabCaseEndpointNameFormatter();

            busConfigurator.UsingRabbitMq((context, configurator) =>
            {
                configurator.Host("rabbitmq", "/", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                configurator.ConfigureEndpoints(context);
            });
        });
    }
}