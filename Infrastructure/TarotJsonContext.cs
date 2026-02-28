using System.Text.Json.Serialization;
using CovenDash.Models;

namespace CovenDash.Infrastructure;

[JsonSerializable(typeof(List<TarotCard>))]
internal partial class TarotJsonContext : JsonSerializerContext
{
}
