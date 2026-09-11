using System.Text.Json.Serialization;
using CovenDash.CovenDash.Core.Models;

namespace CovenDash.CovenDash.Core.Data;

[JsonSerializable(typeof(List<TarotCard>))]
internal partial class AppJsonContext : JsonSerializerContext
{
}