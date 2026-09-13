namespace CovenDash.CovenDash.Core.Models;

public class TarotCard(string numeral, string name, string meaningUpright, string meaningReverse)
{
    public string Numeral { get; } = numeral;
    public string Name { get; } = name;
    public string MeaningUpright { get; } = meaningUpright;
    public string MeaningReverse { get; } = meaningReverse;
    public bool Upright { get; set; } = true;
}
