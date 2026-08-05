using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AnxietyWatch.Web.Client.Models.Auth;

public class LoginRequest
{
    [Required(ErrorMessage = "El correo es obligatorio.")]
    [EmailAddress(ErrorMessage = "Ingresa un correo electrónico válido.")]
    [JsonPropertyName("email")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "La contraseña es obligatoria.")]
    [JsonPropertyName("password")]
    public string Password { get; set; } = string.Empty;
}
