using System.Text.Json.Serialization;

namespace AnxietyWatch.Web.Client.Models.Api;

public sealed class DashboardSummaryDto
{
    [JsonPropertyName("anxietyLevel")]
    public AnxietyLevelDto AnxietyLevel { get; init; } = new();

    [JsonPropertyName("weeklyRecords")]
    public WeeklyRecordsDto WeeklyRecords { get; init; } = new();

    [JsonPropertyName("streakDays")]
    public int StreakDays { get; init; }

    [JsonPropertyName("exercisesCompleted")]
    public int ExercisesCompleted { get; init; }
}

public sealed class AnxietyLevelDto
{
    [JsonPropertyName("current")]
    public int Current { get; init; }

    [JsonPropertyName("trend")]
    public string Trend { get; init; } = string.Empty;
}

public sealed class WeeklyRecordsDto
{
    [JsonPropertyName("used")]
    public int Used { get; init; }

    [JsonPropertyName("limit")]
    public int? Limit { get; init; }
}
