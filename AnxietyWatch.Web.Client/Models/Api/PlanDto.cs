using System.Text.Json.Serialization;

namespace AnxietyWatch.Web.Client.Models.Api;

public sealed class PlanDto
{
    [JsonPropertyName("id")]
    public string Id { get; init; } = string.Empty;

    [JsonPropertyName("name")]
    public string Name { get; init; } = string.Empty;

    [JsonPropertyName("priceMonthly")]
    public decimal PriceMonthly { get; init; }

    [JsonPropertyName("priceYearly")]
    public decimal PriceYearly { get; init; }

    [JsonPropertyName("features")]
    public IReadOnlyList<string> Features { get; init; } = [];

    [JsonPropertyName("limitations")]
    public IReadOnlyList<string> Limitations { get; init; } = [];

    [JsonPropertyName("idealFor")]
    public string IdealFor { get; init; } = string.Empty;
}
