using System.Text.Json.Serialization;

namespace AnxietyWatch.Web.Client.Models.Api;

public sealed class UpdateSettingsRequest
{
    [JsonPropertyName("anxietyThreshold")]
    public int AnxietyThreshold { get; init; }

    [JsonPropertyName("pushNotifications")]
    public bool PushNotifications { get; init; }

    [JsonPropertyName("privateMode")]
    public bool PrivateMode { get; init; }
}

public sealed class SettingsResponse
{
    [JsonPropertyName("anxietyThreshold")]
    public int AnxietyThreshold { get; init; }

    [JsonPropertyName("pushNotifications")]
    public bool PushNotifications { get; init; }

    [JsonPropertyName("privateMode")]
    public bool PrivateMode { get; init; }
}
