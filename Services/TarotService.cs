using System.Text.Json;
using System. Reflection;
using CovenDash.Models;
using CovenDash.Infrastructure;

namespace CovenDash.Services;

public class TarotService
{
  public TarotCard CardOfTheDay { get; }

  public TarotService ()
  {
    var assembly = Assembly.GetExecutingAssembly();
    
    using var stream = assembly.GetManifestResourceStream("CovenDash.tarot.json");
    using var reader = new StreamReader(stream!);
    var json = reader.ReadToEnd();

    var deck = JsonSerializer.Deserialize
      (
        json,
        TarotJsonContext.Default.ListTarotCard
      );

    int seed = DateTime.Today.Day + DateTime.Today.Month + DateTime.Today.Year;
    var random = new Random(seed);

    if(deck != null)
    {
      var card = deck[random.Next(22)];
      CardOfTheDay = card;
      CardOfTheDay.Upright = random.Next(2) % 2 == 0;
    }
    else
    {
      CardOfTheDay = new TarotCard("", "Cards not found", "", "");
    }
  }
}
