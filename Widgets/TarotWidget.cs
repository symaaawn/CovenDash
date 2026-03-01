using Spectre.Console;
using Spectre.Console.Rendering;
using CovenDash.Services;
using CovenDash.Models;

namespace CovenDash.Widgets;

public class TarotWidget : IDashboardWidget
{
  private readonly TarotService _service;
  private readonly TarotCard _cardOfTheDay;

  public string Title => "tarot";

  public TarotWidget(TarotService service)
  {
    _service = service;
    _cardOfTheDay = _service.CardOfTheDay;
  }

  public IRenderable Render()
  {
    var reading = _cardOfTheDay.Upright ? _cardOfTheDay.MeaningUpright : _cardOfTheDay.MeaningReverse;
    var orientation = _cardOfTheDay.Upright ? "Upright" : "Reversed";

    var card = new Text(
        $"{_cardOfTheDay.Numeral}\n" + 
        $"{_cardOfTheDay.Name}\n" +
        $"{orientation}\n"
      )
      .Centered()
      .Overflow(Overflow.Fold);

    var meaning = new Text(
       $"{reading}"
      )
      .LeftJustified()
      .Overflow(Overflow.Fold);

    var rows = new Rows(card, meaning);

    return new Panel(rows) { Width = 20 }
      .Header("Tarot")
      .Border(BoxBorder.Rounded)
      .BorderColor(Spectre.Console.Color.Yellow);
  }
}
