using CovenDash.CovenDash.Core.Services;
using CovenDash.CovenDash.Widgets;

namespace CovenDash.CovenDash.Console;

public class Program
{
    public static void Main(string[] args)
    {
        var moonService = new MoonPhaseService();
        var systemInfoService = new SystemInfoService();
        var tarotService = new TarotService();

        var widgets = new List<IDashboardWidget>
        {
            new MoonWidget(moonService),
            new SystemInfoWidget(systemInfoService),
            new TarotWidget(tarotService),
        };

        var dashboard = new DashboardApp(widgets);

        dashboard.Render();
    }
}
