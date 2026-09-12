using CovenDash.CovenDash.Core.Models;

namespace CovenDash.CovenDash.Core.Interfaces;

public interface ITarotService
{
    public TarotCard CardOfTheDay { get; }
}