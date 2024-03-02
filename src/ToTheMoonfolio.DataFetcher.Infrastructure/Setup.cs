using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using ToTheMoonfolio.DataFetcher.Core.Abstractions;
using ToTheMoonfolio.DataFetcher.Infrastructure.Abstractions;
using ToTheMoonfolio.DataFetcher.Infrastructure.Configuration;
using ToTheMoonfolio.DataFetcher.Infrastructure.Services;

namespace ToTheMoonfolio.DataFetcher.Infrastructure;

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