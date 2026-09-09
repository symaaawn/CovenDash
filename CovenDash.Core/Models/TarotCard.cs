namespace CovenDash.Core.Models;

public class TarotCard
{
    public string Numeral { get; }
    public string Name { get; }
    public string MeaningUpright { get; }
    public string MeaningReverse { get; }
    public bool Upright { get; set; } = true;

    public TarotCard(string numeral, string name, string meaningUpright, string meaningReverse)
    {
        Numeral = numeral;
        Name = name;
        MeaningUpright = meaningUpright;
        MeaningReverse = meaningReverse;
    }
}
