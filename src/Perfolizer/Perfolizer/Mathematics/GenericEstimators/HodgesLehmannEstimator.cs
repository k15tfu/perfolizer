using Perfolizer.Common;
using Perfolizer.Mathematics.Common;
using Perfolizer.Mathematics.Distributions.DiscreteDistributions;
using Perfolizer.Mathematics.QuantileEstimators;

namespace Perfolizer.Mathematics.GenericEstimators;

/// <summary>
/// Based on:
/// Hodges, J. L., and E. L. Lehmann. 1963. Estimates of location based on rank tests.
/// The Annals of Mathematical Statistics 34 (2):598–611.  
/// DOI: 10.1214/aoms/1177704172
/// </summary>
public class HodgesLehmannEstimator : ILocationShiftEstimator, IMedianEstimator
{
    public static readonly HodgesLehmannEstimator Instance = new();

    public double LocationShift(Sample x, Sample y)
    {
        Assertion.NonWeighted(nameof(x), x);
        Assertion.NonWeighted(nameof(y), y);

        double[] diffs = new double[x.Count * y.Count];
        int k = 0;
        for (int i = 0; i < x.Count; i++)
        for (int j = 0; j < y.Count; j++)
            diffs[k++] = x.Values[j] - y.Values[i];
        Array.Sort(diffs);
        return SimpleQuantileEstimator.Instance.Median(new Sample(diffs));
    }

    public double Median(Sample x)
    {
        Assertion.NonWeighted(nameof(x), x);

        double[] diffs = BuildDiffs(x);
        return SimpleQuantileEstimator.Instance.Median(new Sample(diffs));
    }

    public ConfidenceInterval MedianConfidenceInterval(Sample x, ConfidenceLevel confidenceLevel)
    {
        Assertion.NonWeighted(nameof(x), x);

        int n = x.Count;

        double[] diffs = BuildDiffs(x);
        double alpha = 1 - confidenceLevel;
        var distribution = new SignedRankDistribution(n);
        int d = Max(distribution.Quantile(alpha / 2), 1);
        int u = n * (n + 1) / 2 - d;
        double median = SimpleQuantileEstimator.Instance.Median(new Sample(diffs));

        return new ConfidenceInterval(median, diffs[d - 1], diffs[u], confidenceLevel);
    }

    private static double[] BuildDiffs(Sample x)
    {
        int n = x.Count;
        double[] diffs = new double[n * (n + 1) / 2];
        for (int i = 0, k = 0; i < n; i++)
        for (int j = i; j < n; j++)
            diffs[k++] = (x.Values[i] + x.Values[j]) / 2;
        Array.Sort(diffs);
        return diffs;
    }
}