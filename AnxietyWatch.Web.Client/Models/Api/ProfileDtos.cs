using System.Text.Json.Serialization;

namespace AnxietyWatch.Web.Client.Models.Api;

public sealed class UpdateProfileRequest
{
    [JsonPropertyName("fullName")]
    public string FullName { get; init; } = string.Empty;

    [JsonPropertyName("avatarUrl")]
    public string? AvatarUrl { get; init; }
}

public sealed class ProfileResponse
{
    [JsonPropertyName("fullName")]
    public string FullName { get; init; } = string.Empty;

    [JsonPropertyName("avatarUrl")]
    public string? AvatarUrl { get; init; }
}

public sealed class ChangePasswordRequest
{
    [JsonPropertyName("currentPassword")]
    public string CurrentPassword { get; init; } = string.Empty;

    [JsonPropertyName("newPassword")]
    public string NewPassword { get; init; } = string.Empty;
}
