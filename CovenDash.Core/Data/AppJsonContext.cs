using System.Text.Json.Serialization;
using CovenDash.Core.Models;

namespace CovenDash.Core.Data;

[JsonSerializable(typeof(List<TarotCard>))]
internal partial class AppJsonContext : JsonSerializerContext
{
}