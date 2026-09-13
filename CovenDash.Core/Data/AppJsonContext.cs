using System.Text.Json.Serialization;
using CovenDash.CovenDash.Core.Models;

namespace CovenDash.CovenDash.Core.Data;

[JsonSerializable(typeof(List<TarotCard>))]
[JsonSerializable(typeof(List<SunSign>))]
internal partial class AppJsonContext : JsonSerializerContext
{
}