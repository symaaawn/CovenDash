using System.Reflection;
using System.Text.Json;
using CovenDash.Core.Data;
using CovenDash.Core.Models;

namespace CovenDash.Core.Services;

public class TarotService
{
    public TarotCard CardOfTheDay { get; }

    public TarotService()
    {
        var assembly = Assembly.GetExecutingAssembly();

        var resourceName = "CovenDash.CovenDash.Core.Data.tarot.json";
        using var stream = assembly.GetManifestResourceStream(resourceName);
        using var reader = new StreamReader(stream!);
        var json = reader.ReadToEnd();

        var deck = JsonSerializer.Deserialize
        (
            json,
            AppJsonContext.Default.ListTarotCard
        );

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
