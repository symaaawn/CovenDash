using Spectre.Console;
using Spectre.Console.Rendering;
using CovenDash.Services;
using CovenDash.Widgets;

namespace CovenDash.Widgets;

public class MoonWidget : IDashboardWidget
{
    private readonly MoonPhaseService _service;

    public string Title => "moon";

    public MoonWidget(MoonPhaseService service)
    {
        _service = service;
    }

    public IRenderable Render()
    {
        var now = DateTime.UtcNow;
        var symbol = _service.GetMoonSymbol(now);
        var phaseName = _service.GetMoonPhaseName(now);

        return new Panel($"{symbol}  {phaseName}")
            .Header("Mond")
            .Border(BoxBorder.Rounded)
            .BorderColor(Spectre.Console.Color.Purple);
    }
}
