using Spectre.Console.Rendering;

namespace CovenDash.Widgets;

public interface IDashboardWidget
{
    string Id { get; }
    int Order { get; }

    IRenderable Render();
}
