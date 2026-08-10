using System.Text.Json.Serialization;

namespace AnxietyWatch.Web.Client.Models.Api;

public sealed class FaqDto
{
    [JsonPropertyName("question")]
    public string Question { get; init; } = string.Empty;

    [JsonPropertyName("answer")]
    public string Answer { get; init; } = string.Empty;
}

// The backend currently returns an empty object array and does not define an item contract.
public sealed class TestimonialDto
{
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("role")]
    public string? Role { get; init; }

    [JsonPropertyName("quote")]
    public string? Quote { get; init; }

    [JsonPropertyName("avatarUrl")]
    public string? AvatarUrl { get; init; }
}
