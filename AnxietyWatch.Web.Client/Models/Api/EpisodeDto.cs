using System.Text.Json.Serialization;

namespace AnxietyWatch.Web.Client.Models.Api;

public sealed class EpisodeDto
{
    [JsonPropertyName("id")]
    public string Id { get; init; } = string.Empty;

    [JsonPropertyName("date")]
    public DateTimeOffset Date { get; init; }

    [JsonPropertyName("intensity")]
    public int Intensity { get; init; }

    [JsonPropertyName("symptoms")]
    public IReadOnlyList<string> Symptoms { get; init; } = [];

    [JsonPropertyName("notes")]
    public string? Notes { get; init; }
}

public sealed class CreateEpisodeRequest
{
    [JsonPropertyName("intensity")]
    public int Intensity { get; init; }

    [JsonPropertyName("symptoms")]
    public IReadOnlyList<string> Symptoms { get; init; } = [];

    [JsonPropertyName("notes")]
    public string? Notes { get; init; }
}
