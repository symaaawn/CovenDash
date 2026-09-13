using CovenDash.CovenDash.Core.Interfaces;
using CovenDash.CovenDash.Core.Models;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace CovenDash.CovenDash.Widgets;

public class ZodiacWidget(IZodiacService service) : IDashboardWidget
{
    private readonly SunSign _transitingSunSign = service.TransitingSunSign;

    public string Title => "zodiac";

    public IRenderable Render()
    {
        //var icon = _transitingSunSign.Icon.ToLower();

        var zodiacHeader = new Text(
            $"{_transitingSunSign.Name}\n" + 
            //$"{icon}\n" + 
            $"{_transitingSunSign.StartDate} - {_transitingSunSign.EndDate}"
        )
            .Centered()
            .Overflow(Overflow.Fold);

        return new Panel(zodiacHeader)
            .Header("Transiting Zodiac")
            .Border(BoxBorder.Rounded)
            .BorderColor(Color.Magenta)
            .Padding(0, 0)
            .Expand();
    }
}