using CovenDash.CovenDash.Core.Interfaces;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace CovenDash.CovenDash.Widgets;

public class MoonWidget(IMoonPhaseService service) : IDashboardWidget
{
    private readonly IMoonPhaseService _service = service;

    public string Title => "moon";

    public IRenderable Render()
    {
        var now = DateTime.UtcNow;
        var symbol = _service.GetMoonSymbol(now);
        var phaseName = _service.GetMoonPhaseName(now);

        return new Panel($"{symbol}  {phaseName}")
            .Header("Mond")
            .Border(BoxBorder.Rounded)
            .BorderColor(Color.Purple)
            .Expand();
    }
}
