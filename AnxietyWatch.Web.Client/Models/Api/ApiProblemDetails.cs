using System.Text.Json.Serialization;

namespace AnxietyWatch.Web.Client.Models.Api;

/// <summary>
/// Mapea la estructura <c>application/problem+json</c> que devuelve la API backend
/// ante respuestas no exitosas (RFC 7807).
/// </summary>
public class ApiProblemDetails
{
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("status")]
    public int? Status { get; set; }

    [JsonPropertyName("traceId")]
    public string? TraceId { get; set; }

    public int StatusCode => Status ?? 0;
}