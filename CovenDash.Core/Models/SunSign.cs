namespace CovenDash.CovenDash.Core.Models;

public class SunSign(string name, string icon, int house, string startDate, string endDate, 
    string element, string modality, string rulingPlanet)
{
    public string Name { get; } = name;
    public string Icon { get; } = icon;
    public int House { get; } = house;
    public string StartDate { get; } = startDate;
    public string EndDate { get; } = endDate;
    public string Element { get; } = element;
    public string Modality { get; } = modality;
    public string RulingPlanet { get; } = rulingPlanet;
}