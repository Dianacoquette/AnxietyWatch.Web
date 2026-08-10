using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AnxietyWatch.Web.Client.Models.Auth;

public sealed class ForgotPasswordRequest
{
    [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
    [EmailAddress(ErrorMessage = "Introduce un correo electrónico válido.")]
    [JsonPropertyName("email")]
    public string Email { get; set; } = string.Empty;
}

public sealed class ResetPasswordRequest
{
    [Required(ErrorMessage = "El token de recuperación es obligatorio.")]
    [JsonPropertyName("token")]
    public string Token { get; set; } = string.Empty;

    [Required(ErrorMessage = "La nueva contraseña es obligatoria.")]
    [StringLength(30, MinimumLength = 8, ErrorMessage = "La contraseña debe tener entre 8 y 30 caracteres.")]
    [JsonPropertyName("newPassword")]
    public string NewPassword { get; set; } = string.Empty;
}

public sealed class AuthMessageResponse
{
    [JsonPropertyName("message")]
    public string Message { get; set; } = string.Empty;
}

public sealed class EmailVerificationStatusResponse
{
    [JsonPropertyName("emailVerified")]
    public bool EmailVerified { get; set; }
}
