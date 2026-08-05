using System.Text.Json.Serialization;

namespace AnxietyWatch.Web.Client.Models.Auth;

public class AuthResponse
{
    [JsonPropertyName("token")]
    public string Token { get; set; } = string.Empty;

    [JsonPropertyName("user")]
    public UserInfo User { get; set; } = null!;
}
