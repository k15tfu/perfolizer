namespace Perfolizer.Mathematics.Thresholds;

public enum ThresholdUnit
{
    Ratio,
    Nanoseconds,
    Microseconds,
    Milliseconds,
    Seconds,
    Minutes
}

public static class ThresholdUnitExtensions
{
    private static readonly IReadOnlyDictionary<ThresholdUnit, string> UnitToShortName = new Dictionary<ThresholdUnit, string>()
    {
        { ThresholdUnit.Ratio, "%" },
        { ThresholdUnit.Nanoseconds, "ns" },
        { ThresholdUnit.Microseconds, "\u03BCs" },
        { ThresholdUnit.Milliseconds, "ms" },
        { ThresholdUnit.Seconds, "s" },
        { ThresholdUnit.Minutes, "m" },
    };

    internal static readonly IReadOnlyDictionary<string, ThresholdUnit> ShortNameToUnit = UnitToShortName.ToDictionary(pair => pair.Value, pair => pair.Key);

    public static string ToShortName(this ThresholdUnit thresholdUnit) => UnitToShortName[thresholdUnit];
}