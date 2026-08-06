using System.Net.Http.Json;
using System.Text.Json;
using AnxietyWatch.Web.Client.Models.Api;

namespace AnxietyWatch.Web.Client.Services;

/// <summary>
/// Extensiones para peticiones a la API: leen la respuesta como
/// <see cref="ApiResult{T}"/> o lanzan <see cref="ApiException"/> ante
/// errores 400/401/403/404/409/410/429.
/// </summary>
public static class HttpApiExtensions
{
    public static async Task<ApiResult<T>> ReadApiResultAsync<T>(
        this HttpResponseMessage response,
        JsonSerializerOptions? options = null,
        CancellationToken cancellationToken = default) {
        if (response.IsSuccessStatusCode) {
            var data = await response.Content
                .ReadFromJsonAsync<T>(options, cancellationToken);
            return ApiResult<T>.Success(data!);
        }

        var problem = await ReadProblemAsync(response, options, cancellationToken);
        var retryAfter = response.Headers.RetryAfter?.Delta is { } retry
            ? (int)retry.TotalSeconds
            : (int?)null;
        return ApiResult<T>.Failure(problem, retryAfter);
    }

    /// <summary>Lee un tipo deserializado o lanza <see cref="ApiException"/> ante un estado no exitoso.</summary>
    public static async Task<T> ReadApiAsync<T>(
        this HttpResponseMessage response,
        JsonSerializerOptions? options = null,
        CancellationToken cancellationToken = default) {
        if (response.IsSuccessStatusCode) {
            return await response.Content
                       .ReadFromJsonAsync<T>(options, cancellationToken)
                   ?? throw new ApiException(
                       new ApiProblemDetails
                       {
                           Status = (int)response.StatusCode,
                           Title = "La respuesta del servidor está vacía."
                       },
                       (int)response.StatusCode);
        }

        var problem = await ReadProblemAsync(response, options, cancellationToken);
        var retryAfter = response.Headers.RetryAfter?.Delta is { } retry
            ? (int)retry.TotalSeconds
            : null;
        throw new ApiException(problem, problem.StatusCode, retryAfter);
    }

    private static async Task<ApiProblemDetails> ReadProblemAsync(
        HttpResponseMessage response,
        JsonSerializerOptions? options,
        CancellationToken cancellationToken) {
        try {
            return await response.Content
                       .ReadFromJsonAsync<ApiProblemDetails>(options, cancellationToken)
                   ?? new ApiProblemDetails { Status = (int)response.StatusCode };
        }
        catch (JsonException) {
            return new ApiProblemDetails { Status = (int)response.StatusCode };
        }
    }
}