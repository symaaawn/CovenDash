namespace CovenDash.CovenDash.Core.Interfaces;

public interface IMoonPhaseService
{
    public string GetMoonSymbol(DateTime date);
    public string GetMoonPhaseName(DateTime date);
}