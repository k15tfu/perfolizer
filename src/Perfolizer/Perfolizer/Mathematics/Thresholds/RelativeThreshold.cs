using System.Diagnostics.CodeAnalysis;

namespace Perfolizer.Mathematics.Thresholds;

public class RelativeThreshold : Threshold, IEquatable<RelativeThreshold?>
{
    public static readonly Threshold Zero = new RelativeThreshold(0);
    public static readonly Threshold Default = new RelativeThreshold(0.01);

    private readonly double ratio;

    public RelativeThreshold(double ratio) => this.ratio = ratio;

    public override double Value(IReadOnlyList<double> values) => values.Average() * ratio;

    public override bool IsZero() => Math.Abs(ratio) < 1e-9;

    public override string ToString() => ratio * 100 + ThresholdUnit.Ratio.ToShortName();

    public bool Equals([NotNullWhen(true)] RelativeThreshold? other) => other != null && ratio.Equals(other.ratio);

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is RelativeThreshold other && Equals(other);

    public override int GetHashCode() => ratio.GetHashCode();
}