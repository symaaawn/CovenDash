using System.Reflection;
using System.Text.Json;
using CovenDash.Core.Models;

namespace CovenDash.Core.Services;

public class TarotService
{
    public TarotCard CardOfTheDay { get; }

    public TarotService()
    {
        var assembly = Assembly.GetExecutingAssembly();

        var jsonPath = Path.Combine(
            AppContext.BaseDirectory,
            "CovenDash.Core",
            "Data",
            "tarot.json"
        );
        var json = File.ReadAllText(jsonPath);
        //var deck = JsonSerializer.Deserialize(json, TarotJsonContext.Default.ListTarotCard);
        var deck = JsonSerializer.Deserialize<TarotCard[]>(json);

        int seed = DateTime.Today.Day + DateTime.Today.Month + DateTime.Today.Year;
        var random = new Random(seed);

        if (deck != null)
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
