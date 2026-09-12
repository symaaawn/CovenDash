using CovenDash.CovenDash.Widgets;
using Spectre.Console;

namespace CovenDash.CovenDash.Console;

public class DashboardApp(IEnumerable<IDashboardWidget> widgets)
{
    private readonly List<IDashboardWidget> _widgets = widgets.ToList();

    public void Render()
    {
        if (_widgets.Count == 0)
        {
            AnsiConsole.MarkupLine("[red]No widgets to display![/]");
            return;
        }

        var layout = new Layout("root").SplitColumns(
            new Layout("left").Ratio(1),
            new Layout("right").Ratio(1),
            new Layout("placeholder").Ratio(3)
        );

        layout["left"]
            .SplitRows(new Layout("sysInfoLayout").Ratio(3), new Layout("moonLayout").Ratio(2));

        layout["sysInfoLayout"].Update(_widgets.First(w => w.Title.Equals("sysInfo")).Render());
        layout["moonLayout"].Update(_widgets.First(w => w.Title.Equals("moon")).Render());
        layout["right"].Update(_widgets.First(w => w.Title.Equals("tarot")).Render());
        layout["placeholder"].Update(new Panel("").NoBorder());

        var container = new Panel(layout) { Height = 14 }.NoBorder();

        AnsiConsole.Write(container);
    }
}
