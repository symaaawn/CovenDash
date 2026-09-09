using CovenDash.Core.Services;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace CovenDash.Widgets;

public class SystemInfoWidget : IDashboardWidget
{
    private readonly SystemInfoService _service;

    public string Title => "sysInfo";

    public SystemInfoWidget(SystemInfoService service)
    {
        _service = service;
    }

    public IRenderable Render()
    {
        var sysName = Environment.MachineName;
        var osVersion = Environment.OSVersion;
        var uptime = _service.GetUptime();
        var userName = Environment.UserName;

        return new Panel(
            $"System: {sysName}\nOS: {osVersion}\nUptime: {uptime}\n\nHello {userName} "
        )
            .Header("System Info")
            .Border(BoxBorder.Rounded)
            .BorderColor(Spectre.Console.Color.Aqua)
            .Expand();
    }
}
