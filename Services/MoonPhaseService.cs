namespace CovenDash.Services;

public class MoonPhaseService
{
    private readonly DateTime _refNewMoon = new DateTime(2000, 1, 6, 18, 14, 0, DateTimeKind.Utc);

    private readonly string[] _moonSymbols = new string[]
    {
        "🌑","🌒","🌓","🌔","🌕","🌖","🌗","🌘",
        "🌑","🌒","🌓","🌔","🌕","🌖","🌗","🌘",
        "🌑","🌒","🌓","🌔","🌕","🌖","🌗","🌘"
    };

    private double GetPhaseFraction(DateTime date)
    {
        double synodicMonth = 29.53058867;
        double daysSinceNew = (date.ToUniversalTime() - _refNewMoon).TotalDays;
        double phase = (daysSinceNew % synodicMonth) / synodicMonth;
        if (phase < 0) phase += 1.0;
        return phase;
    }

    public string GetMoonSymbol(DateTime date)
    {
        double phase = GetPhaseFraction(date);
        int index = (int)(phase * _moonSymbols.Length) % _moonSymbols.Length;
        return _moonSymbols[index];
    }

    public string GetMoonPhaseName(DateTime date)
    {
        double phase = GetPhaseFraction(date);

        if (phase < 0.03 || phase > 0.97) return "Neumond";
        if (phase < 0.22) return "Zunehmender Sichelmond";
        if (phase < 0.28) return "Erstes Viertel";
        if (phase < 0.47) return "Zunehmender Mond";
        if (phase < 0.53) return "Vollmond";
        if (phase < 0.72) return "Abnehmender Mond";
        if (phase < 0.78) return "Letztes Viertel";
        return "Abnehmende Sichel";
    }
}
