using AnxietyWatch.Web.Client.Models.Api;

namespace AnxietyWatch.Web.Client.Services;

/// <summary>
/// Excepción lanzada cuando la API responde con un estado no exitoso.
/// Expone el detalle <c>problem+json</c> y el tiempo de reintento (429).
/// </summary>
public class ApiException : Exception
{
    public ApiException(ApiProblemDetails problem, int statusCode, int? retryAfterSeconds = null)
        : base(problem.Title ?? $"Error {statusCode}") =>
        (Problem, StatusCode, RetryAfterSeconds) = (problem, statusCode, retryAfterSeconds);

    public ApiProblemDetails Problem { get; }
    public int StatusCode { get; }
    public int? RetryAfterSeconds { get; }
}