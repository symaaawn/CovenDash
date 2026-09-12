using CovenDash.CovenDash.Core.Interfaces;
using CovenDash.CovenDash.Core.Services;
using CovenDash.CovenDash.Widgets;
using Microsoft.Extensions.DependencyInjection;

namespace CovenDash.CovenDash.Console;

public class Program
{
    public static void Main(string[] args)
    {
        var services = new ServiceCollection();
        
        RegisterServices(services);

        RegisterWidgets(services);

        services.AddSingleton<DashboardApp>();

        var serviceProvider = services.BuildServiceProvider();
        var dashboard = serviceProvider.GetRequiredService<DashboardApp>();

        dashboard.Render();
    }

    private static void RegisterServices(IServiceCollection services)
    {
        services.AddSingleton<IMoonPhaseService, MoonPhaseService>();
        services.AddSingleton<ISystemInfoService, SystemInfoService>();
        services.AddSingleton<ITarotService, TarotService>();
    }

    private static void RegisterWidgets(IServiceCollection services)
    {
        services.AddSingleton<IDashboardWidget, MoonWidget>();
        services.AddSingleton<IDashboardWidget, SystemInfoWidget>();
        services.AddSingleton<IDashboardWidget, TarotWidget>();
    }
}
