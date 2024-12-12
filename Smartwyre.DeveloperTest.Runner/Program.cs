using Microsoft.Extensions.DependencyInjection;
using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Data.Interfaces;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Services.Interfaces;

namespace Smartwyre.DeveloperTest.Runner;

class Program
{
    static void Main(string[] args)
    {
        var services = CreateServices();

        App app = services.GetRequiredService<App>();
        app.Run();
    }

    private static ServiceProvider CreateServices()
    {
        var serviceProvider = new ServiceCollection()
            .AddTransient<App>()
            .AddScoped<IRebateService, RebateService>()
            .AddScoped<IProductDataStore, ProductDataStore>()
            .AddScoped<IRebateDataStore, RebateDataStore>()
            .BuildServiceProvider();

        return serviceProvider;
    }
}
