using Spectre.Console.Rendering;

namespace CovenDash.Widgets;

public interface IDashboardWidget
{
    string Title { get; }
    IRenderable Render();
}
