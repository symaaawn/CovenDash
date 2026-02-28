using Spectre.Console;
using Spectre.Console.Rendering;
using CovenDash.Widgets;

namespace CovenDash.Dashboard;

public class DashboardApp
{
    private readonly List<IDashboardWidget> _widgets;

    public DashboardApp(IEnumerable<IDashboardWidget> widgets)
    {
        _widgets = widgets.ToList();
    }

    public void Render()
    {
        if (_widgets.Count == 0)
        {
            AnsiConsole.MarkupLine("[red]No widgets to display![/]");
            return;
        }

        var panels = _widgets.Select(w => w.Render()).ToList();

        if (panels.Count > 1)
        {
            var grid = new Grid();

            grid.AddColumn();
            grid.AddColumn();

            for (int i = 0; i < panels.Count; i += 2)
            {
                if (i + 1 < panels.Count)
                    grid.AddRow(panels[i], panels[i + 1]);
                else
                    grid.AddRow(panels[i]);
            }

            AnsiConsole.Write(grid);
        }
        else
        {
            AnsiConsole.Write(panels[0]);
        }
    }
}
