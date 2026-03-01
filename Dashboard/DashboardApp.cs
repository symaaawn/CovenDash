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

    var layout = new Layout("root")
      .SplitColumns(
          new Layout("left").Ratio(1),
          new Layout("right").Ratio(1),
          new Layout("placeholder").Ratio(3)
          );
    
    layout["left"].SplitRows(
        new Layout("sysInfoLayout").Ratio(3),
        new Layout("moonLayout").Ratio(1)
        );

    layout["sysInfoLayout"].Update(
        _widgets.First(w => w.Title.Equals("sysInfo")).Render());
    layout["moonLayout"].Update(
        _widgets.First(w => w.Title.Equals("moon")).Render());
    layout["right"].Update(
        _widgets.First(w => w.Title.Equals("tarot")).Render());
    layout["placeholder"].Update(new Panel("").NoBorder());

    var container = new Panel(layout)
    {
      Height = 12
    }
      .NoBorder();

    AnsiConsole.Write(container);
    /*var panels = _widgets.Select(w => w.Render()).ToList();
        
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
          
      grid.Expand();
      grid.Width = 80;

      AnsiConsole.Write(grid);
    }
    else
    {
      AnsiConsole.Write(panels[0]);
    }*/
  }
}
