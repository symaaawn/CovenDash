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
    var text = new Text
      (
        $"{_cardOfTheDay.Numeral}\n" + 
        $"{_cardOfTheDay.Name}\n\n" +
        $"{reading}"
      )
      .Centered()
      .Overflow(Overflow.Fold);

    return new Panel(text) { Width = 20 }
      .Header("Tarot")
      .Border(BoxBorder.Rounded)
      .BorderColor(Spectre.Console.Color.Yellow);
  }
}
