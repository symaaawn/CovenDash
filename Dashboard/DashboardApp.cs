using Spectre.Console;
using Spectre.Console.Rendering;
using CovenDash.Widgets;

namespace CovenDash.Dashboard;

public class DashboardApp
{
    private readonly IEnumerable<IDashboardWidget> _widgets;

    public DashboardApp(IEnumerable<IDashboardWidget> widgets)
    {
        _widgets = widgets.OrderBy(w => w.Order);
    }

    public void Render()
    {
        foreach (var widget in _widgets)
        {
            AnsiConsole.Write(widget.Render());
        }
    }
}
