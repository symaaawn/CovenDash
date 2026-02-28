using System.Text.Json;
using CovenDash.Models;
using CovenDash.Infrastructure;

namespace CovenDash.Services;

public class TarotService
{
  public TarotCard CardOfTheDay { get; }

  public TarotService ()
  {
    var json = File.ReadAllText("tarot.json");
    var deck = JsonSerializer.Deserialize
      (
        json,
        TarotJsonContext.Default.ListTarotCard
      );

    int seed = DateTime.Today.Day + DateTime.Today.Month + DateTime.Today.Year;
    var random = new Random(seed);

    if(deck != null)
    {
      var card = deck[random.Next(21)];
      CardOfTheDay = card;
      CardOfTheDay.Upright = random.Next(2) % 2 == 0;
    }
    else
    {
      CardOfTheDay = new TarotCard("", "Cards not found", "", "");
    }
  }
}
