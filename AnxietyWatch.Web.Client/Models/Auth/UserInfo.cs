using System.Text.Json.Serialization;

namespace AnxietyWatch.Web.Client.Models.Auth;

public class UserInfo
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("fullName")]
    public string FullName { get; set; } = string.Empty;

    [JsonPropertyName("email")]
    public string Email { get; set; } = string.Empty;

    [JsonPropertyName("planId")]
    public string PlanId { get; set; } = string.Empty;
}
