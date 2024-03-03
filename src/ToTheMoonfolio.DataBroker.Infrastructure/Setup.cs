using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using ToTheMoonfolio.DataBroker.Core.Abstractions;
using ToTheMoonfolio.DataBroker.Infrastructure.Abstractions;
using ToTheMoonfolio.DataBroker.Infrastructure.Configuration;
using ToTheMoonfolio.DataBroker.Infrastructure.Services;

namespace ToTheMoonfolio.DataBroker.Infrastructure;

public static class Setup
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AlphaVantageApiConfiguration>(configuration.GetSection(nameof(AlphaVantageApiConfiguration)));
        
        services
            .AddRefitClient<IAlphaVantageApi>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://www.alphavantage.co"));
        
        services.AddScoped<IFinancialDataProvider, AlphaVantageService>();

        return services;
    }
}