using System.Text.Json.Serialization;

namespace AnxietyWatch.Web.Client.Models.Api;

public sealed class SuccessResponse
{
    [JsonPropertyName("success")]
    public bool Success { get; init; }
}

public sealed class MessageResponse
{
    [JsonPropertyName("message")]
    public string Message { get; init; } = string.Empty;
}

public sealed class SentResponse
{
    [JsonPropertyName("sent")]
    public bool Sent { get; init; }
}
