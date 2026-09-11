using Spectre.Console.Rendering;

namespace CovenDash.CovenDash.Widgets;

public interface IDashboardWidget
{
    string Title { get; }
    IRenderable Render();
}
