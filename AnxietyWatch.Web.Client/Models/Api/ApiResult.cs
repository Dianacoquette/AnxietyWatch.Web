namespace AnxietyWatch.Web.Client.Models.Api;

/// <summary>
/// <see href="https://en.wikipedia.org/wiki/Result_pattern">Result pattern</see> estandarizado
/// para que la UI lea de forma simple el éxito o el fallo de una llamada a la API.
/// </summary>
public class ApiResult
{
    public bool IsSuccess { get; init; }
    public ApiProblemDetails? Problem { get; init; }
    public int? RetryAfterSeconds { get; init; }

    public static ApiResult Success() => new() { IsSuccess = true };

    public static ApiResult Failure(ApiProblemDetails problem, int? retryAfterSeconds = null) =>
        new() { IsSuccess = false, Problem = problem, RetryAfterSeconds = retryAfterSeconds };
}

public class ApiResult<T> : ApiResult
{
    public T? Data { get; init; }

    public static ApiResult<T> Success(T data) => new() { IsSuccess = true, Data = data };
}