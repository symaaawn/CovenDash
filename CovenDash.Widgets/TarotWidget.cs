using CovenDash.CovenDash.Core.Interfaces;
using CovenDash.CovenDash.Core.Models;
using CovenDash.CovenDash.Core.Services;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace CovenDash.CovenDash.Widgets;

public class TarotWidget(ITarotService service) : IDashboardWidget
{
    private readonly ITarotService _service = service;
    private readonly TarotCard _cardOfTheDay = service.CardOfTheDay;


    public string Title => "tarot";

    public IRenderable Render()
    {
        var reading = _cardOfTheDay.Upright
            ? _cardOfTheDay.MeaningUpright
            : _cardOfTheDay.MeaningReverse;
        var orientation = _cardOfTheDay.Upright ? "Upright" : "Reversed";

        var card = new Text(
            $"{_cardOfTheDay.Numeral}\n" + $"{_cardOfTheDay.Name}\n" + $"{orientation}\n"
        )
            .Centered()
            .Overflow(Overflow.Fold);

        var meaning = new Text($"{reading}").LeftJustified().Overflow(Overflow.Fold);

        var rows = new Rows(card, meaning);

        return new Panel(rows)
            .Header("Tarot")
            .Border(BoxBorder.Rounded)
            .BorderColor(Spectre.Console.Color.Yellow)
            .Expand();
    }
}
