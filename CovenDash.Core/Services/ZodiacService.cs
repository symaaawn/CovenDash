using System.Reflection;
using System.Text.Json;
using CovenDash.CovenDash.Core.Data;
using CovenDash.CovenDash.Core.Interfaces;
using CovenDash.CovenDash.Core.Models;

namespace CovenDash.CovenDash.Core.Services;

public class ZodiacService : IZodiacService
{
    public SunSign TransitingSunSign { get; }

    public ZodiacService()
    {
        var assembly = Assembly.GetExecutingAssembly();

        var resourceName = "CovenDash.CovenDash.Core.Data.sunSigns.json";
        using var stream = assembly.GetManifestResourceStream(resourceName);
        using var reader = new StreamReader(stream!);
        var json = reader.ReadToEnd();

        var sunSigns = JsonSerializer.Deserialize
        (
            json,
            AppJsonContext.Default.ListSunSign
        );

        if (sunSigns == null || sunSigns.Count == 0)
        {
            throw new Exception("Zodiac data not found or empty.");
        }

        var currentDate = DateTime.Today;
        var currentMonth = currentDate.Month;
        var currentDay = currentDate.Day;

        sunSigns = sunSigns.OrderBy(s => s.StartDate).ToList();

        foreach (var sign in sunSigns)
        {
            var startDateMonth = int.Parse(sign.StartDate.Split('-')[0]);
            var startDateDay = int.Parse(sign.StartDate.Split('-')[1]);

            var endDateMonth = int.Parse(sign.EndDate.Split('-')[0]);
            var endDateDay = int.Parse(sign.EndDate.Split('-')[1]);

            if ((currentMonth == startDateMonth && currentDay >= startDateDay) ||
                (currentMonth == endDateMonth && currentDay <= endDateDay) ||
                (currentMonth > startDateMonth && currentMonth < endDateMonth) ||
                (startDateMonth > endDateMonth && (currentMonth > startDateMonth || currentMonth < endDateMonth)))
            {
                TransitingSunSign = sign;
                return;
            }
        }
        
        TransitingSunSign = sunSigns[0];
    }
}