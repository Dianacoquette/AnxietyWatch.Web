using System.Text.Json.Serialization;

namespace AnxietyWatch.Web.Client.Models.Auth;

/// <summary>Respuesta de login/registro/sesión: token, vencimiento y usuario.</summary>
public class AuthResponse
{
    [JsonPropertyName("token")]
    public string Token { get; set; } = string.Empty;

    [JsonPropertyName("expiresAt")]
    public DateTimeOffset ExpiresAt { get; set; }

    [JsonPropertyName("user")]
    public UserDto User { get; set; } = null!;
}