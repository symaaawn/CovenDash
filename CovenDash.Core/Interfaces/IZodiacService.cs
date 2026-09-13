using CovenDash.CovenDash.Core.Models;

namespace CovenDash.CovenDash.Core.Interfaces;

public interface IZodiacService
{
    public SunSign TransitingSunSign { get; }
}